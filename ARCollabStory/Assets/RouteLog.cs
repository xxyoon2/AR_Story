using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteLog : MonoBehaviour
{
    public GameObject Stage1Routes;
    
    private Text RouteStateText;

    //Stage1�� �ִ� ��Ʈ��
    private GameObject StartRoute;
    private GameObject Secondroute;
    private GameObject ThirdRoute;

    private void Awake()
    {
        RouteStateText = gameObject.GetComponent<Text>();

        StartRoute = Stage1Routes.transform.GetChild(0).gameObject;
        Secondroute = Stage1Routes.transform.GetChild(1).gameObject;
        ThirdRoute = Stage1Routes.transform.GetChild(2).gameObject;
    }

    private void Update()
    {
        RouteStateText.text = $"ù��° ��Ʈ ����: {StartRoute.activeSelf}\n�ι�° ��Ʈ ���� : {Secondroute.activeSelf}\n����° ��Ʈ ���� : {ThirdRoute.activeSelf}";
    }

}
