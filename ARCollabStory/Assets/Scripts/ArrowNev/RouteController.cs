using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    //Stage1에 있는 루트들
    private GameObject _startRoute;
    private GameObject _secondRoute;
    private GameObject _thirdRoute;

    private void Awake()
    {
        _startRoute = transform.GetChild(0).gameObject;
        _secondRoute = transform.GetChild(1).gameObject;
        _thirdRoute = transform.GetChild(2).gameObject;
    }

    private void OnEnable()
    {
        _startRoute.SetActive(false);
        _secondRoute.SetActive(false);
        _thirdRoute.SetActive(false);
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
                _startRoute.SetActive(true);
                Debug.Log($"{_startRoute} 루트 {_startRoute.activeSelf} 상태로 변경");
                break;
            case "Secondroute":
                _secondRoute.SetActive(true);
                Debug.Log($"{_secondRoute} 루트 {_secondRoute.activeSelf} 상태로 변경");
                break;
            case "ThirdRoute":
                _thirdRoute.SetActive(true);
                Debug.Log($"{_thirdRoute} 루트 {_thirdRoute.activeSelf} 상태로 변경");
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
                _startRoute.SetActive(false);
                Debug.Log($"{_startRoute} 루트 {_startRoute.activeSelf} 상태로 변경");
                break;
            case "Secondroute":
                _secondRoute.SetActive(false);
                Debug.Log($"{_secondRoute} 루트 {_secondRoute.activeSelf} 상태로 변경");
                break;
            case "ThirdRoute":
                _thirdRoute.SetActive(false);
                Debug.Log($"{_thirdRoute} 루트 {_thirdRoute.activeSelf} 상태로 변경");
                break;
        }
    }
}
