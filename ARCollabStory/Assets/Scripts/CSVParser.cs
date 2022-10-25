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


public static class CSVParser
{
    public static List<LocationRecord> GetLocationInfos()
    {
        System.Collections.Generic.List<LocationRecord> list = new List<LocationRecord>();
        TextAsset locationTextAsset = Resources.Load<TextAsset>("LocationsInfo");
        List<LocationRecord> locationRecords = new List<LocationRecord>();
        locationRecords.Add(null);
        using (StringReader csvString = new StringReader(locationTextAsset.text))
        {

            while(csvString.Peek() > -1)
            {
                string stringData = csvString.ReadLine();
                var dataValues = stringData.Split('|');
                LocationRecord parseData = new LocationRecord();
                if(int.TryParse(dataValues[0], out int intData)) parseData.DirectionIndex = int.Parse(dataValues[0]);
                parseData.MissionTypeInfo = dataValues[1];
                parseData.MissionStatus = dataValues[2];
                if(double.TryParse(dataValues[3], out double doubleData1)) parseData.Latitude = double.Parse(dataValues[3]);
                if(double.TryParse(dataValues[4], out double doubleData2)) parseData.Longuitude = double.Parse(dataValues[4]);
                locationRecords.Add(parseData);
            }
        }
        return locationRecords;
    }
}
