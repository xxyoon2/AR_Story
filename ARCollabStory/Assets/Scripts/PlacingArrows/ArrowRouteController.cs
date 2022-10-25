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

    //�������� �ϳ��� �ִ� ��Ʈ��
    private GameObject StartRoute;
    private GameObject Secondroute;
    private GameObject ThirdRoute;


    //������ �����ϸ� ��ŸƮ ��Ʈ Ȱ��ȭ(WebRoderr) -> ȭ��ǥ�� ������ ���Y��ȭ ����
    //

    private void Awake()
    {
        StartRoute = StartRoutes.GetComponent<Transform>().GetChild(0).gameObject;
        Secondroute = StartRoutes.GetComponent<Transform>().GetChild(1).gameObject;
        ThirdRoute = StartRoutes.GetComponent<Transform>().GetChild(2).gameObject;

        //�÷��̾ �������� ���� �ȴ� �ñ����� �ƴ��� ���ӸŴ������� �޾ƿ;� ��
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
        if (_destinationObject.IsQuestEnd && !Secondroute.activeSelf) // �ι�° ��Ʈ Ȱ��ȭ
        {
            StartRoute.SetActive(false);
            Secondroute?.SetActive(true);
        }
        else if (_destinationObject.IsQuestStart && Secondroute.activeSelf)//����° ��Ʈ Ȱ��ȭ
        {
            Secondroute?.SetActive(false);
            ThirdRoute?.SetActive(true);
        }
    }
}