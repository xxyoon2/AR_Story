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


public static class CSVParser
{
    public static List<LocationRecord> GetLocationInfos()
    {
        Debug.Log("csv���� �����ͺ��Կ�");
        TextAsset locationTextAsset = Resources.Load<TextAsset>(Application.dataPath + "LocationsInfo");
        Debug.Log("��ġ���� ���� �ε���");
        List<LocationRecord> locationRecords = new List<LocationRecord>();
        locationRecords.Add(null);
        Debug.Log("����Ʈ�� �� ���� �߰�");
        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "|",
            NewLine = Environment.NewLine
        };
        Debug.Log("CSVconfiguration �Ϸ�");

        using (StringReader csvString = new StringReader(locationTextAsset.text))
        {
            using (CsvReader csv = new CsvReader(csvString, config))
            {
                IEnumerable<LocationRecord> records = csv.GetRecords<LocationRecord>();
                foreach (LocationRecord record in records)
                {
                    Debug.Log($"{record.DirectionIndex}");
                    locationRecords.Add(record);
                }
            }
        }
        Debug.Log("�Ľ� �Ϸ�");
        return locationRecords;
    }
}
