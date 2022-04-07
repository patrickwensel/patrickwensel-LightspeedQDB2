using QBD2.Models;
using System.Globalization;
using System.IO;
using OfficeOpenXml;
using System.Data;
using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using ExcelRow = QBD2.Models.ExcelRow;

namespace QBD2.Services
{
    public class ExcelUploadService
    {
        private readonly ApplicationDbContext _context;
        public ExcelUploadService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task ProcessExcelFile(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<ExcelRow> excelRows = new List<ExcelRow>();
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["As_Built"];
                if (workSheet != null)
                {
                    TrimLastEmptyRows(workSheet);
                    int colCount = workSheet.Dimension.End.Column;  //get Column Count
                    int rowCount = workSheet.Dimension.End.Row;     //get row count
                    for (int rowIterator = 2; rowIterator <= rowCount; rowIterator++)
                    {
                        var user = new Models.ExcelRow
                        {
                            ProductFamily = workSheet.Cells[rowIterator, 1].Value?.ToString(),
                            Date = workSheet.Cells[rowIterator, 2].Value?.ToString(),
                            PN = workSheet.Cells[rowIterator, 3].Value?.ToString(),
                            SN = workSheet.Cells[rowIterator, 4].Value?.ToString(),
                            PartDescription = workSheet.Cells[rowIterator, 5].Value?.ToString(),
                            PartNumber = workSheet.Cells[rowIterator, 6].Value?.ToString(),
                            SerialNumber = workSheet.Cells[rowIterator, 7].Value?.ToString(),
                        };
                        excelRows.Add(user);
                    }


                    List<Entities.MasterPart> masterPartsList = new List<Entities.MasterPart>();

                    var pnProductFamilyList = excelRows.Where(q => q.PN != null && q.ProductFamily != null).Select(m => new { m.PN, m.ProductFamily }).Distinct().ToList();
                    List<Entities.ProductFamily> productFamiliesList = _context.ProductFamilies.ToList();
                    foreach (var item in pnProductFamilyList)
                    {
                        int? productFamilyId = null;
                        if (!string.IsNullOrWhiteSpace(item.ProductFamily))
                        {
                            var productFamilies = productFamiliesList.Where(q => q.Name.ToLower() == item.ProductFamily.ToLower()).FirstOrDefault();
                            if (productFamilies != null)
                            {
                                productFamilyId = productFamilies.ProductFamilyId;
                            }
                        }
                        var isPartNumberAvailabe = _context.MasterParts.Any(p => p.ProductFamilyId == productFamilyId && p.PartNumber.ToLower() == item.PN.ToLower());
                        if (!isPartNumberAvailabe)
                        {
                            Entities.MasterPart masterPart = new Entities.MasterPart
                            {
                                PartNumber = item.PN.ToString(),
                                ProductFamilyId = productFamilyId,
                                Description = item.ProductFamily ?? String.Empty
                            };
                            masterPartsList.Add(masterPart);
                        }
                    }

                    var partNumberProductFamilyList = excelRows.Where(q => q.PartNumber != null).Select(m => new { m.PartNumber, m.PartDescription }).Distinct().ToList();
                    foreach (var item in partNumberProductFamilyList)
                    {
                        var isPartNumberAvailabe = _context.MasterParts.Any(p => p.PartNumber.ToLower() == item.PartNumber.ToLower());
                        if (!isPartNumberAvailabe)
                        {
                            Entities.MasterPart masterPart = new Entities.MasterPart
                            {
                                PartNumber = item.PartNumber,
                                ProductFamilyId = null,
                                Description = item.PartDescription ?? String.Empty
                            };
                            masterPartsList.Add(masterPart);
                        }
                    }
                    if (masterPartsList.Count > 0)
                    {
                        _context.MasterParts.AddRange(masterPartsList);
                        await _context.SaveChangesAsync();
                    }
                    var masterParts = _context.MasterParts.Include(q => q.ProductFamily).ToList();
                    foreach (var pnItem in pnProductFamilyList)
                    {
                        var pnSNList = excelRows.Where(q => q.SN != null && q.PN == pnItem.PN && q.ProductFamily == pnItem.ProductFamily).Select(q => q.SN).Distinct().ToList();
                        foreach (var item in pnSNList)
                        {
                            var partsList = new List<Entities.Part>();
                            var masterPart = masterParts.Where(p => p.PartNumber.ToLower() == pnItem.PN.ToLower() && p.ProductFamily != null && p.ProductFamily.Name.ToLower() == pnItem.ProductFamily.ToLower()).FirstOrDefault();
                            if (masterPart != null)
                            {
                                var part = _context.Parts.Where(p => p.SerialNumber.ToLower() == item.ToLower() && p.MasterPartId == masterPart.MasterPartId).FirstOrDefault();
                                if (part == null)
                                {
                                    part = new Entities.Part
                                    {
                                        SerialNumber = item,
                                        MasterPartId = masterPart.MasterPartId,
                                        ParentPartId = null
                                    };
                                    _context.Parts.Add(part);
                                    await _context.SaveChangesAsync();
                                }

                                var childParts = excelRows.Where(q => q.SN == item && q.PN == pnItem.PN && q.PartNumber != null && q.SerialNumber != null && q.ProductFamily == pnItem.ProductFamily).ToList();
                                foreach (var childItem in childParts)
                                {
                                    var childMasterPart = masterParts.Where(p => p.PartNumber.ToLower() == childItem.PartNumber.ToLower()).FirstOrDefault();
                                    if (childMasterPart != null)
                                    {
                                        var isSerialNumberAvailabe = _context.Parts.Any(p => p.MasterPartId == childMasterPart.MasterPartId && p.ParentPartId == part.PartId && p.SerialNumber.ToLower() == childItem.SerialNumber.ToLower());
                                        if (!isSerialNumberAvailabe)
                                        {
                                            var childPart = new Entities.Part
                                            {
                                                SerialNumber = childItem.SerialNumber,
                                                MasterPartId = childMasterPart.MasterPartId,
                                                ParentPartId = part.PartId
                                            };

                                            partsList.Add(childPart);
                                        }
                                    }
                                }
                                if (partsList.Count > 0)
                                {
                                    _context.Parts.AddRange(partsList);
                                    await _context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
            }
        }

        public void TrimLastEmptyRows(ExcelWorksheet worksheet)
        {
            while (IsLastRowEmpty(worksheet))
                worksheet.DeleteRow(worksheet.Dimension.End.Row);
        }

        public bool IsLastRowEmpty(ExcelWorksheet worksheet)
        {
            var empties = new List<bool>();

            for (int i = 1; i <= worksheet.Dimension.End.Column; i++)
            {
                var rowEmpty = worksheet.Cells[worksheet.Dimension.End.Row, i].Value == null ? true : false;
                empties.Add(rowEmpty);
            }

            return empties.All(e => e);
        }
    }

}
