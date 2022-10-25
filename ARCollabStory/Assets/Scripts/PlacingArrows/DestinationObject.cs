using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TypeOfDestinationObject
{
    StartQuestDestination,
    EndQuestDestination,
    StartMiniGameDestination,
    EndMiniGameDestination
}

public class DestinationObject : MonoBehaviour
{
    public TypeOfDestinationObject TypeOfDestination;
    public float Distance = 0.01f;

    public GameObject Stage1Routes;
    //스테이지 하나에 있는 루트들
    private GameObject StartRoute;
    private GameObject Secondroute;
    private GameObject ThirdRoute;

    private GameObject _mainCamera;
  
    private void Awake()
    {
        _mainCamera = GameObject.Find("AR Camera");

        StartRoute = Stage1Routes.GetComponent<Transform>().GetChild(0).gameObject;
        Secondroute = Stage1Routes.GetComponent<Transform>().GetChild(1).gameObject;
        ThirdRoute = Stage1Routes.GetComponent<Transform>().GetChild(2).gameObject;
    }

    private void Update()
    {

        double distanceToPlayer = Vector3.Distance(transform.position, _mainCamera.transform.position);

        //목적지와 플레이어와 거리가 가까워졌을 때 게임 상태 변형
        //"목적지에 도착했을 때"를 얻는 것은 이 코드에서 하면 됨
        if (distanceToPlayer < Distance)
        {
            //   
        }
    }


}