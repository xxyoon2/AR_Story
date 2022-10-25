using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestinationObjectController : MonoBehaviour
{
    private GameObject DestinationObjects;

    private void Awake()
    {
        DestinationObjects = GameObject.Find("DestinationObjects");
    }
}