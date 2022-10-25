using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowRouteController : MonoBehaviour
{
    public GameObject StartRoutes;
    private DestinationObject _destinationObject;

    private bool _isGameStart;
    private bool _isArrivedQuest;

    //스테이지 하나에 있는 루트들
    private GameObject StartRoute;
    private GameObject Secondroute;
    private GameObject ThirdRoute;


    //게임이 시작하면 스타트 루트 활성화(WebRoderr) -> 화살표들 렌더러 비홠성화 상태
    //

    private void Awake()
    {
        StartRoute = StartRoutes.GetComponent<Transform>().GetChild(0).gameObject;
        Secondroute = StartRoutes.GetComponent<Transform>().GetChild(1).gameObject;
        ThirdRoute = StartRoutes.GetComponent<Transform>().GetChild(2).gameObject;

        //플레이어가 목적지를 향해 걷는 시기인지 아닌지 게임매니져에서 받아와야 함
        //_isWalkingDestination = GameManager.Instance.IsWalkingDestination;
    }
    private void Start()
    {
        StartRoute.SetActive(true);
        Secondroute.SetActive(false);
        ThirdRoute.SetActive(false);
    }

    private void Update()
    {
        if (_destinationObject.IsQuestEnd && !Secondroute.activeSelf) // 두번째 루트 활성화
        {
            StartRoute.SetActive(false);
            Secondroute?.SetActive(true);
        }
        else if (_destinationObject.IsQuestStart && Secondroute.activeSelf)//세번째 루트 활성화
        {
            Secondroute?.SetActive(false);
            ThirdRoute?.SetActive(true);
        }
    }
}