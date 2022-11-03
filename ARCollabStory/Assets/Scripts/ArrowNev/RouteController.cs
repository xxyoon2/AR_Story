using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    //Stage1에 있는 루트들
    private GameObject StartRoute;
    private GameObject SecondRoute;
    private GameObject ThirdRoute;

    private void Awake()
    {
        StartRoute = transform.GetChild(0).gameObject;
        SecondRoute = transform.GetChild(1).gameObject;
        ThirdRoute = transform.GetChild(2).gameObject;
    }

    private void OnEnable()
    {
        StartRoute.SetActive(false);
        SecondRoute.SetActive(false);
        ThirdRoute.SetActive(false);
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
                Debug.Log($"{StartRoute} 루트 {StartRoute.activeSelf} 상태로 변경");
                break;
            case "Secondroute":
                SecondRoute.SetActive(true);
                Debug.Log($"{SecondRoute} 루트 {SecondRoute.activeSelf} 상태로 변경");
                break;
            case "ThirdRoute":
                ThirdRoute.SetActive(true);
                Debug.Log($"{ThirdRoute} 루트 {ThirdRoute.activeSelf} 상태로 변경");
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
                Debug.Log($"{StartRoute} 루트 {StartRoute.activeSelf} 상태로 변경");
                break;
            case "Secondroute":
                SecondRoute.SetActive(false);
                Debug.Log($"{SecondRoute} 루트 {SecondRoute.activeSelf} 상태로 변경");
                break;
            case "ThirdRoute":
                ThirdRoute.SetActive(false);
                Debug.Log($"{ThirdRoute} 루트 {ThirdRoute.activeSelf} 상태로 변경");
                break;
        }
    }
}
