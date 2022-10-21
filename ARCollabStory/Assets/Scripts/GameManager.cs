using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public UnityEvent DirectionsStatusUpdate = new UnityEvent();
    private List<LocationRecord> _locationRecords;
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
    void OnEnable()
    {
        _locationRecords = CSVParser.GetLocationInfos();
    }

    public void StatusUpdateAlarm()
    {
        DirectionsStatusUpdate.Invoke();
    }

}