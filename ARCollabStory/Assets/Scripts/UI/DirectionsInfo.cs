using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionsInfo : MonoBehaviour
{
    private Locations[] _directionAreas;
    private int _areaCount;
    
    void Start()
    {
        _areaCount = transform.childCount;
        _directionAreas = new Locations[_areaCount];
        Debug.Log("목적지배열만듦");

        for(int i = 0; i < _areaCount; i++)
        {
            _directionAreas[i] = transform.GetChild(i).gameObject.GetComponent<Locations>();
            Debug.Log("받아옴");
            _directionAreas[i].OrderIndex = GameManager.Instance.LocationRecords[i + 1].DirectionIndex;
            Debug.Log("버튼연결해요");
        }

        Invoke("ButtonColorChange", 2f);
    }

    void ButtonColorChange()
    {
        GameManager.Instance.StatusUpdateAlarm();
    }
}
