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
        Debug.Log("csv파일 가져와볼게요");
        TextAsset locationTextAsset = Resources.Load<TextAsset>("LocationsInfo2");
        List<LocationRecord> locationRecords = new List<LocationRecord>();
        locationRecords.Add(null);
        Debug.Log("리스트에 빈 공간 추가");
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
        Debug.Log("파싱 완료");
        return locationRecords;
    }
}
