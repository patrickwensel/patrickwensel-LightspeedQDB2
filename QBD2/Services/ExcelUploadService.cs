using QBD2.Models;
using System.Globalization;
using System.IO;
using System.Data;
using Microsoft.EntityFrameworkCore;
using QBD2.Data;
using ExcelRow = QBD2.Models.ExcelRow;
using ExcelDataReader;
using QBD2.Entities;
using Microsoft.Extensions.Options;
using static QBD2.Models.Enum;
using Microsoft.WindowsAzure.Storage.Blob;

namespace QBD2.Services
{
    public class ExcelUploadService
    {
        private readonly ApplicationDbContext _context;
        private readonly PartService _partService;
        private IOptions<ApplicationSettings> _appSettings;
        private BlobService _blobService;
        private SerialNumberService _serialNumberService;

        public ExcelUploadService(ApplicationDbContext context, PartService partService, IOptions<ApplicationSettings> appSettings, BlobService blobService, SerialNumberService serialNumberService)
        {
            _context = context;
            _partService = partService;
            _appSettings = appSettings;
            _blobService = blobService;
            _serialNumberService = serialNumberService;
        }

        public async Task<AddPartsToDeviationModel> ProcessSerialNumberExcelFile(string fileName, MasterPart masterPart)
        {
            AddPartsToDeviationModel addPartsToDeviationModel = new AddPartsToDeviationModel();
            List<string> excelRows = new List<string>();

            if (this._appSettings.Value.FileUploadType.ToLower() == FileUploadType.Azure.ToString().ToLower())
            {
                CloudBlob file = await this._blobService.DownloadFile(fileName, this._appSettings.Value.FileUploadContainer);

                if (await file.ExistsAsync())
                {
                    MemoryStream ms = new MemoryStream();
                    await file.DownloadToStreamAsync(ms);

                    DataSet dsexcelRecords = new DataSet();
                    using (var reader = ExcelReaderFactory.CreateReader(file.OpenReadAsync().Result))
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
            }
            else
            {
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
            }

            if (excelRows.Count > 0)
            {
                addPartsToDeviationModel = await _partService.AddPartsToDeviationByList(masterPart, excelRows);
            }

            return addPartsToDeviationModel;

        }

        public async Task<AddPartsToAlertModel> AlertProcessSerialNumberExcelFile(string fileName, MasterPart masterPart)
        {
            AddPartsToAlertModel addPartsToAlertModel = new AddPartsToAlertModel();
            List<string> excelRows = new List<string>();

            if (this._appSettings.Value.FileUploadType.ToLower() == FileUploadType.Azure.ToString().ToLower())
            {
                CloudBlob file = await this._blobService.DownloadFile(fileName, this._appSettings.Value.FileUploadContainer);

                if (await file.ExistsAsync())
                {
                    MemoryStream ms = new MemoryStream();
                    await file.DownloadToStreamAsync(ms);

                    DataSet dsexcelRecords = new DataSet();
                    using (var reader = ExcelReaderFactory.CreateReader(file.OpenReadAsync().Result))
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
            }
            else
            {
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
            }

            if (excelRows.Count > 0)
            {
                addPartsToAlertModel = await _partService.AddPartsToAlertByList(masterPart, excelRows);
            }
            return addPartsToAlertModel;
        }

        public async Task<AddPartsToExcelUploadModel> ProcessExcelFile(string fileName)
        {
            AddPartsToExcelUploadModel addPartsToExcelUploadModel = new AddPartsToExcelUploadModel();
            addPartsToExcelUploadModel.AddPartsToExcelUploadError = new List<AddPartsToExcelUploadError>();
            addPartsToExcelUploadModel.Parts = new List<Part>();
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
                //List<string> distinctMasterParts = new List<string>();
                var distinctMasterParts = excelRows.Select(m => new { m.PN }).Distinct().ToList();

                foreach (var part in distinctMasterParts)
                {
                    // is it in the Mater Parts table
                    MasterPart masterPart = _context.MasterParts.Where(p => p.PartNumber == part.PN).FirstOrDefault();

                    //if not, throw an error
                    if (masterPart == null)
                    {
                        AddPartsToExcelUploadError addPartsToExcelUploadError = new AddPartsToExcelUploadError
                        {
                            Error = "Master Part number: " + part.PN + " is not in Sage"
                        };

                        addPartsToExcelUploadModel.AddPartsToExcelUploadError.Add(addPartsToExcelUploadError);
                    }
                    else
                    {

                        //if it is, get a list of distinct PNs

                        var distinctPartSerialNumbers = excelRows.Where(z => z.PN == part.PN).Select(m => new { m.SN }).Distinct().ToList();

                        //loop over PNs and make sure they are in Sage with the correct ItemNum

                        foreach (var serialNumber in distinctPartSerialNumbers)
                        {
                            SerialNumberSearchResult serialNumberSearchResult = await _serialNumberService.GetSerialNumberFromSage(masterPart.Itemno, Convert.ToInt32(serialNumber.SN));
                            //If not, throw an error
                            if (serialNumberSearchResult.IsInSage == false)
                            {
                                AddPartsToExcelUploadError addPartsToExcelUploadError = new AddPartsToExcelUploadError
                                {
                                    Error = "Serial number: " + serialNumber.SN + " is not in Sage"
                                };

                                addPartsToExcelUploadModel.AddPartsToExcelUploadError.Add(addPartsToExcelUploadError);
                            }
                            else
                            {
                                // if they are in Sage, check if they are in the Parts list
                                var partFromQDB = _context.Parts.Where(p => p.SerialNumber.ToLower() == serialNumber.SN.ToLower() && p.MasterPartId == masterPart.MasterPartId).FirstOrDefault();
                                if (partFromQDB == null)
                                {
                                    //If not add them to the parts list
                                    partFromQDB = new Entities.Part
                                    {
                                        SerialNumber = serialNumber.SN,
                                        MasterPartId = masterPart.MasterPartId,
                                        PartStatusId = 1,
                                        ParentPartId = null,
                                        UpdateDate = DateTime.Now
                                    };
                                    _context.Parts.Add(partFromQDB);
                                    await _context.SaveChangesAsync();

                                    // Add Parts in to inspection record
                                    var station = await _context.Stations.Where(x => x.Name.ToLower() == "Seveco".ToLower()).FirstOrDefaultAsync();
                                    if (!_context.Inspections.Any(x => x.Pass == true && x.GeneralComments.ToLower() == "Seveco".ToLower() &&
                                         x.PartId == partFromQDB.PartId && x.StationId == station.StationId))
                                    {
                                        Entities.Inspection inspection = new Entities.Inspection();
                                        inspection.Pass = true;
                                        inspection.GeneralComments = "Seveco";
                                        inspection.PartId = partFromQDB.PartId;
                                        inspection.StationId = station.StationId;
                                        inspection.UpdateDate = DateTime.Now;
                                        _context.Inspections.Add(inspection);
                                        await _context.SaveChangesAsync();
                                    }
                                }

                                var childParts = excelRows.Where(q => q.SN == serialNumber.SN && q.PN == part.PN && q.PartNumber != null && q.SerialNumber != null).ToList();
                                var partsList = new List<Entities.Part>();
                                foreach (var childItem in childParts)
                                {
                                    // Loop over all the child parts and see if they are in the Parts table
                                    //Child parts do not need to be in Sage
                                    Part childPartFromQDB = _context.Parts.Where(p => p.SerialNumber.ToLower() == childItem.SerialNumber.ToLower() && p.MasterPartId == masterPart.MasterPartId  && p.ParentPartId == partFromQDB.PartId).FirstOrDefault();

                                    //If they are in the Parts table already, update the values
                                    if (childPartFromQDB == null)
                                    {
                                        //If they are not in the Parts table, add them
                                        var childPart = new Entities.Part
                                        {
                                            SerialNumber = childItem.SerialNumber,
                                            MasterPartId = masterPart.MasterPartId,
                                            PartStatusId = 1,
                                            ParentPartId = partFromQDB.PartId,
                                            UpdateDate = DateTime.Now
                                        };

                                        partsList.Add(childPart);

                                    }
                                }

                                if (partsList.Count > 0)
                                {
                                    _context.Parts.AddRange(partsList);
                                    await _context.SaveChangesAsync();

                                    foreach (var item in partsList)
                                    {
                                        // Add Parts in to inspection record
                                        var station = await _context.Stations.Where(x => x.Name.ToLower() == "Seveco".ToLower()).FirstOrDefaultAsync();
                                        if(!_context.Inspections.Any(x=>x.Pass == true && x.GeneralComments.ToLower() == "Seveco".ToLower() && 
                                        x.PartId == item.PartId && x.StationId == station.StationId))
                                        {
                                            Entities.Inspection inspection = new Entities.Inspection();
                                            inspection.Pass = true;
                                            inspection.GeneralComments = "Seveco";
                                            inspection.PartId = item.PartId;
                                            inspection.StationId = station.StationId;
                                            inspection.UpdateDate = DateTime.Now;
                                            _context.Inspections.Add(inspection);
                                            await _context.SaveChangesAsync();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return addPartsToExcelUploadModel;
        }

        public class AddPartsToExcelUploadError
        {
            public string Error { get; set; }
        }

        public class AddPartsToExcelUploadModel
        {
            public List<AddPartsToExcelUploadError> AddPartsToExcelUploadError { get; set; }
            public List<Part> Parts { get; set; }
        }
    }
}
