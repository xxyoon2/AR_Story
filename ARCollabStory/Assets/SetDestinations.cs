using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SetDestinations : MonoBehaviour
{
    private DestinationsBehaviour[] destinations;
    private int currentIndex;
    private int destinationCount;
    void Start()
    {
        destinationCount = transform.childCount;
        destinations = new DestinationsBehaviour[destinationCount];
        GameManager.Instance.DirectionsStatusUpdate.AddListener(RenewalStatus);
        GameManager.Instance.ChangeStatus.AddListener(ChangeStatus);
        Invoke("Initializing", 0.5f);
    }

    void Initializing()
    {
        for (int i = 0; i < destinationCount; i++)
        {
            destinations[i] = transform.GetChild(i).GetComponent<DestinationsBehaviour>();
            destinations[i].MissionType = GameManager.Instance.LocationRecords[i + 1].MissionTypeInfo;
            Debug.Log($"{destinations[i].MissionType}");
        }
    }

    void RenewalStatus(int index)
    {
        destinations[index].MissionStatus = GameManager.Instance.LocationRecords[index + 1].MissionStatus;
        if(destinations[index].MissionStatus == "InProgress")
        {
            GameManager.Instance.CurrentDestination = destinations[index];
            currentIndex = index;
        }
    }

    void ChangeStatus()
    {
        GameManager.Instance.LocationRecords[currentIndex].MissionStatus = "Done";
        GameManager.Instance.LocationRecords[currentIndex + 1].MissionStatus = "InProgress";
        GameManager.Instance.StatusUpdateAlarm(currentIndex - 1);
        GameManager.Instance.StatusUpdateAlarm(currentIndex);
    }
}
