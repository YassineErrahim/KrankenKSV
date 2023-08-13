using CSharpFunctionalExtensions;
using CsvHelper;
using CsvHelper.Configuration;
using KrankenKSV.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrankenKSV.Services
{
    public static class CSVReaderService
    {

        public static async Task<Result<List<Krankenkasse>>> ParseData(byte[] data)
        {
            List<Krankenkasse> importedObjects = new List<Krankenkasse>();

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture) {
                Encoding = Encoding.UTF8, // Our file uses UTF-8 encoding.
                Delimiter = ";",// The delimiter is a comma.
                HasHeaderRecord = false

            };
            try {
                using (MemoryStream fs = new MemoryStream(data)) {
                    using (var textReader = new StreamReader(fs, Encoding.UTF8))
                    using (var csv = new CsvReader(textReader, configuration)) {
                        csv.Context.RegisterClassMap<KrankenkasseMapper>();
                        var krankenkasseRecords = csv.GetRecords<Krankenkasse>();
                        foreach (var kk in krankenkasseRecords) {
                            importedObjects.Add(kk);
                        }
                    }
                }
                return Result.Success(importedObjects);
            }
            catch (Exception e) {
                return Result.Failure<List<Krankenkasse>>($"Error While Reading The CSV File : {e.Message}");
            }
        }
    }
}
