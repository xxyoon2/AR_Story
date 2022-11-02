using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacingObjectBehaviour : MonoBehaviour
{
    public int ObjectNum
    {
        get
        {
            return _objectNum;
        }
        set
        {
            _objectNum = value;
        }
    }

    private int _objectNum;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            Debug.Log($"{ObjectNum}번째 오브젝트가 플레이어와 닿았다");
        } 
    }
}
