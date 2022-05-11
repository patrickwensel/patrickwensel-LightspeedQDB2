using QBD2.Models;
using System.Globalization;
using System.IO;
using System.Data;
using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using ExcelRow = QBD2.Models.ExcelRow;
using ExcelDataReader;
using QBD2.Entities;

namespace QBD2.Services
{
    public class ExcelUploadService
    {
        private readonly ApplicationDbContext _context;
        private readonly PartService _partService;
        public ExcelUploadService(ApplicationDbContext context, PartService partService)
        {
            _context = context;
            _partService = partService;
        }

        public async Task<List<AddPartsToDeviationError>> ProcessSerialNumberExcelFile(string fileName, Deviation deviation)
        {
            List<AddPartsToDeviationError> addPartsToDeviationErrors = new List<AddPartsToDeviationError>();
            List<string> excelRows = new List<string>();
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                DataSet dsexcelRecords = new DataSet();
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    dsexcelRecords = reader.AsDataSet();

                    if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                    {
                        DataTable dtRecords = dsexcelRecords.Tables[0];
                        if (dtRecords.Rows.Count > 1)
                        {
                            for (int i = 1; i < dtRecords.Rows.Count; i++)
                            {
                                excelRows.Add(Convert.ToString(dtRecords.Rows[i][0]));
                            }
                        }
                    }
                }
            }

            if (excelRows.Count > 0)
            {
                addPartsToDeviationErrors = await _partService.AddPartsToDeviationByList(deviation, excelRows);
            }

            return addPartsToDeviationErrors;

        }

        public async Task ProcessExcelFile(string fileName)
        {
            List<ExcelRow> excelRows = new List<ExcelRow>();
            if (fileName.EndsWith(".xls"))
            {
                using (FileStream FileStream = File.OpenRead(fileName))
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    DataSet dsexcelRecords = new DataSet();
                    IExcelDataReader reader = null;
                    //if (fileName.EndsWith(".xls"))
                    reader = ExcelReaderFactory.CreateBinaryReader(FileStream);
                    //else if (fileName.EndsWith(".xlsx"))
                    //    reader = ExcelReaderFactory.CreateOpenXmlReader(FileStream);

                    dsexcelRecords = reader.AsDataSet();
                    if (reader != null)
                    {
                        reader.Close();
                    }

                    if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                    {
                        DataTable dtRecords = dsexcelRecords.Tables[0];
                        if (dtRecords.Rows.Count > 1 && dtRecords.TableName == "As_Built")
                        {
                            for (int i = 1; i < dtRecords.Rows.Count; i++)
                            {
                                var user = new Models.ExcelRow
                                {
                                    ProductFamily = Convert.ToString(dtRecords.Rows[i][0]),
                                    Date = Convert.ToString(dtRecords.Rows[i][1]),
                                    PN = Convert.ToString(dtRecords.Rows[i][2]),
                                    SN = Convert.ToString(dtRecords.Rows[i][3]),
                                    PartDescription = Convert.ToString(dtRecords.Rows[i][4]),
                                    PartNumber = Convert.ToString(dtRecords.Rows[i][5]),
                                    SerialNumber = Convert.ToString(dtRecords.Rows[i][6]),
                                };
                                excelRows.Add(user);
                            }
                        }
                    }
                }
            }

            if (excelRows.Count > 0)
            {
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

}
