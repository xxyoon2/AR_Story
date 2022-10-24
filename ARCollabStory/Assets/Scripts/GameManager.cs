using System.Collections;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public UnityEvent DirectionsStatusUpdate = new UnityEvent();
    public UnityEvent SetCSVData = new UnityEvent();
    private List<LocationRecord> _locationRecords;

    // csv �Ľ��ؼ� ������ ����Ʈ
    public List<LocationRecord> LocationRecords
    {
        get 
        { 
            return _locationRecords; 
        }
        set 
        {
            _locationRecords = value;
        }
    }

    void Start()
    {
        Debug.Log("csv ����Ͷ�����");
        _locationRecords = CSVParser.GetLocationInfos();
        SetCSVData.Invoke();
    }

    public void StatusUpdateAlarm()
    {
        DirectionsStatusUpdate.Invoke();
    }

}