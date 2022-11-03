using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteLog : MonoBehaviour
{
    public GameObject Stage1Routes;
    
    private Text RouteStateText;

    //Stage1에 있는 루트들
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
        RouteStateText.text = $"첫번째 루트 상태: {StartRoute.activeSelf}\n두번째 루트 상태 : {Secondroute.activeSelf}\n세번째 루트 상태 : {ThirdRoute.activeSelf}";
    }

}
