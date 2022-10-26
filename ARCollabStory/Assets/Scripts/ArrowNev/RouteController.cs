using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    private GameObject Stage1Routes;
    //Stage1에 있는 루트들
    private GameObject StartRoute;
    private GameObject Secondroute;
    private GameObject ThirdRoute;

    private void Awake()
    {
        Stage1Routes = GameObject.Find("Stage1Routes");

        StartRoute = Stage1Routes.GetComponent<Transform>().GetChild(0).gameObject;
        Secondroute = Stage1Routes.GetComponent<Transform>().GetChild(1).gameObject;
        ThirdRoute = Stage1Routes.GetComponent<Transform>().GetChild(2).gameObject;
    }

    private void Start()
    {
        //프로토타입에서는 주석 해제 할 것
        //StartRoute.SetActive(false);
        //Secondroute.SetActive(false);
        //ThirdRoute.SetActive(false);
    }

    /// <summary>
    /// 루트를 키는 함수
    /// 0 :시작루트, 1: 두번째 루트, 2: 세번째 루트
    /// </summary>
    /// <param name="routeNum"></param>
    public void OnRoute(int routeNum)
    {
        switch(routeNum)
        {
            case 0:
                StartRoute.SetActive(true);
                break;
            case 1:
                Secondroute.SetActive(true);
                break;
            case 2:
                ThirdRoute.SetActive(true);
                break;
        }
    }

    /// <summary>
    /// 루트를 끄는 함수
    /// 0 :시작루트, 1: 두번째 루트, 2: 세번째 루트
    /// </summary>
    /// <param name="routeNum"></param>
    public void OffRoute(int routeNum)
    {
        switch (routeNum)
        {
            case 0:
                StartRoute.SetActive(false);
                break;
            case 1:
                Secondroute.SetActive(false);
                break;
            case 2:
                ThirdRoute.SetActive(false);
                break;
        }
    }
}
