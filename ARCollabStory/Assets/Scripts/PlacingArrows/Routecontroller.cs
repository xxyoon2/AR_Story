using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteController : MonoBehaviour
{
    private GameObject Stage1Routes;
    //Stage1�� �ִ� ��Ʈ��
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
        //������Ÿ�Կ����� �ּ� ���� �� ��
        //StartRoute.SetActive(false);
        //Secondroute.SetActive(false);
        //ThirdRoute.SetActive(false);
    }

    /// <summary>
    /// ��Ʈ�� Ű�� �Լ�
    /// 0 :���۷�Ʈ, 1: �ι�° ��Ʈ, 2: ����° ��Ʈ
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
    /// ��Ʈ�� ���� �Լ�
    /// 0 :���۷�Ʈ, 1: �ι�° ��Ʈ, 2: ����° ��Ʈ
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
