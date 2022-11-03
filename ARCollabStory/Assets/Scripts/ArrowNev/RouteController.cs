using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    //Stage1�� �ִ� ��Ʈ��
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
    /// ��Ʈ�� Ű�� �Լ�
    /// </summary>
    /// <param name="RouteName"></param>
    public void OnRoute(string RouteName)
    {
        switch(RouteName)
        {
            case "StartRoute":
                StartRoute.SetActive(true);
                Debug.Log($"{StartRoute} ��Ʈ {StartRoute.activeSelf} ���·� ����");
                break;
            case "Secondroute":
                SecondRoute.SetActive(true);
                Debug.Log($"{SecondRoute} ��Ʈ {SecondRoute.activeSelf} ���·� ����");
                break;
            case "ThirdRoute":
                ThirdRoute.SetActive(true);
                Debug.Log($"{ThirdRoute} ��Ʈ {ThirdRoute.activeSelf} ���·� ����");
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
                StartRoute.SetActive(false);
                Debug.Log($"{StartRoute} ��Ʈ {StartRoute.activeSelf} ���·� ����");
                break;
            case "Secondroute":
                SecondRoute.SetActive(false);
                Debug.Log($"{SecondRoute} ��Ʈ {SecondRoute.activeSelf} ���·� ����");
                break;
            case "ThirdRoute":
                ThirdRoute.SetActive(false);
                Debug.Log($"{ThirdRoute} ��Ʈ {ThirdRoute.activeSelf} ���·� ����");
                break;
        }
    }
}
