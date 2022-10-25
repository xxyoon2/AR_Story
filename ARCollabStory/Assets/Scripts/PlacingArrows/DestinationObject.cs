using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TypeOfDestinationObject
{
    StartQuestDestination,
    EndQuestDestination,
    StartMiniGameDestination,
    EndMiniGameDestination
}

public class DestinationObject : MonoBehaviour
{
    public TypeOfDestinationObject TypeOfDestination;
    public float Distance = 0.01f;

    public GameObject Stage1Routes;
    //�������� �ϳ��� �ִ� ��Ʈ��
    private GameObject StartRoute;
    private GameObject Secondroute;
    private GameObject ThirdRoute;

    private GameObject _mainCamera;
  
    private void Awake()
    {
        _mainCamera = GameObject.Find("AR Camera");

        StartRoute = Stage1Routes.GetComponent<Transform>().GetChild(0).gameObject;
        Secondroute = Stage1Routes.GetComponent<Transform>().GetChild(1).gameObject;
        ThirdRoute = Stage1Routes.GetComponent<Transform>().GetChild(2).gameObject;
    }

    private void Update()
    {

        double distanceToPlayer = Vector3.Distance(transform.position, _mainCamera.transform.position);

        //�������� �÷��̾�� �Ÿ��� ��������� �� ���� ���� ����
        //"�������� �������� ��"�� ��� ���� �� �ڵ忡�� �ϸ� ��
        if (distanceToPlayer < Distance)
        {
            //   
        }
    }


}