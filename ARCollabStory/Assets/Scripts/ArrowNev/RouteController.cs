using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    //Stage1에 있는 루트들
    private GameObject StartRoute;
    private GameObject Secondroute;
    private GameObject ThirdRoute;

    private void Awake()
    {
        StartRoute = transform.GetChild(0).gameObject;
        Secondroute = transform.GetChild(1).gameObject;
        ThirdRoute = transform.GetChild(2).gameObject;
    }

    private void OnEnable()
    {
        //프로토타입 이후 주석 해제할 것
        //StartRoute.SetActive(false);
        //Secondroute.SetActive(false);
        //ThirdRoute.SetActive(false);
    }

    /// <summary>
    /// 루트를 키는 함수
    /// </summary>
    /// <param name="RouteName"></param>
    public void OnRoute(string RouteName)
    {
        switch(RouteName)
        {
            case "StartRoute":
                StartRoute.SetActive(true);
                break;
            case "Secondroute":
                Secondroute.SetActive(true);
                break;
            case "ThirdRoute":
                ThirdRoute.SetActive(true);
                break;
        }
    }

    /// <summary>
    /// 루트를 끄는 함수
    /// </summary>
    /// <param name="RouteName"></param>
    public void OffRoute(string RouteName)
    {
        switch (RouteName)
        {
            case "StartRoute":
                StartRoute.SetActive(false);
                break;
            case "Secondroute":
                Secondroute.SetActive(false);
                break;
            case "ThirdRoute":
                ThirdRoute.SetActive(false);
                break;
        }
    }
}
