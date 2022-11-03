using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    //Stage1�� �ִ� ��Ʈ��
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
    /// ��Ʈ�� Ű�� �Լ�
    /// </summary>
    /// <param name="RouteName"></param>
    public void OnRoute(string RouteName)
    {
        switch(RouteName)
        {
            case "StartRoute":
                _startRoute.SetActive(true);
                Debug.Log($"{_startRoute} ��Ʈ {_startRoute.activeSelf} ���·� ����");
                break;
            case "Secondroute":
                _secondRoute.SetActive(true);
                Debug.Log($"{_secondRoute} ��Ʈ {_secondRoute.activeSelf} ���·� ����");
                break;
            case "ThirdRoute":
                _thirdRoute.SetActive(true);
                Debug.Log($"{_thirdRoute} ��Ʈ {_thirdRoute.activeSelf} ���·� ����");
                break;
        }
    }

    /// <summary>
    /// ��Ʈ�� ���� �Լ�
    /// </summary>
    /// <param name="RouteName"></param>
    public void OffRoute(string RouteName)
    {
        switch (RouteName)
        {
            case "StartRoute":
                _startRoute.SetActive(false);
                Debug.Log($"{_startRoute} ��Ʈ {_startRoute.activeSelf} ���·� ����");
                break;
            case "Secondroute":
                _secondRoute.SetActive(false);
                Debug.Log($"{_secondRoute} ��Ʈ {_secondRoute.activeSelf} ���·� ����");
                break;
            case "ThirdRoute":
                _thirdRoute.SetActive(false);
                Debug.Log($"{_thirdRoute} ��Ʈ {_thirdRoute.activeSelf} ���·� ����");
                break;
        }
    }
}
