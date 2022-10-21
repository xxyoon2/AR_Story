using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public UnityEvent DirectionsStatusUpdate = new UnityEvent();
    private List<LocationRecord> _locationRecords;
    void Start()
    {
        _locationRecords = CSVParser.GetLocationInfos();
    }
}