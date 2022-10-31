using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SetDestinations : MonoBehaviour
{
    private DestinationsBehaviour[] destinations;
    private int currentIndex;
    
    void Start()
    {
        int destinationCount = transform.childCount;
        destinations = new DestinationsBehaviour[destinationCount];
        GameManager.Instance.DirectionsStatusUpdate.AddListener(RenewalStatus);
        GameManager.Instance.ChangeStatus.AddListener(ChangeStatus);
        
        // 목적지 오브젝트들 받아오고 각각 csv 파일의 미션타입과 연동
        for (int i = 0; i < destinationCount; i++)
        {
            destinations[i] = transform.GetChild(i).GetComponent<DestinationsBehaviour>();
            destinations[i].MissionType = GameManager.Instance.LocationRecords[i + 1].MissionTypeInfo;
            Debug.Log($"{destinations[i].MissionType}");
        }
    }

    // 각 목적지의 진행 상황에 따라 현 목적지 변경
    void RenewalStatus(int index)
    {
        destinations[index].MissionStatus = GameManager.Instance.LocationRecords[index + 1].MissionStatus;
        if(destinations[index].MissionStatus == "InProgress")
        {
            GameManager.Instance.CurrentDestination = destinations[index];
            currentIndex = index;
        }
    }

    // 진행중이던 목적지 상태를 완료로 바꾸고 다음 목적지를 진행중으로 변경, 코드 수정 가능성 o
    void ChangeStatus()
    {
        if (GameManager.Instance.LocationRecords[currentIndex].MissionStatus != "Done")
        {
            GameManager.Instance.LocationRecords[currentIndex].MissionStatus = "Done";
            GameManager.Instance.LocationRecords[currentIndex + 1].MissionStatus = "InProgress";
            GameManager.Instance.StatusUpdateAlarm(currentIndex - 1);
            GameManager.Instance.StatusUpdateAlarm(currentIndex);
        }
    }
}
