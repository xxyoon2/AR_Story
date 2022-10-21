using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using TMPro;

public class LocationRecord
{
    public int DirectionIndex { get; set; }
    public string MissionTypeInfo { get; set; }
    public string MissionStatus { get; set; }
    public double Latitude { get; set; }
    public double Longuitude { get; set; }
}


public class CSVParser
{
    public static List<LocationRecord> GetLocationInfos()
    {
        TextAsset locationTextAsset = Resources.Load<TextAsset>("Csv/LocationsInfo");

        List<LocationRecord> locationRecords = new List<LocationRecord>();
        locationRecords.Add(null);

        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "|",
            NewLine = Environment.NewLine
        };


        using (StringReader csvString = new StringReader(locationTextAsset.text))
        {
            using (CsvReader csv = new CsvReader(csvString, config))
            {
                IEnumerable<LocationRecord> records = csv.GetRecords<LocationRecord>();
                foreach (LocationRecord record in records)
                { 
                    locationRecords.Add(record);
                }
            }
        }

        return locationRecords;
    }
}
