using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 목적지를 가리키는 배치된 오브젝트의 타입
/// </summary>
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

    private GameObject _mainCamera;
    private bool _isActived;
  
    private void Awake()
    {
        _mainCamera = GameObject.Find("AR Camera");
    }

    private void Update()
    {
        double distanceToPlayer = Vector3.Distance(transform.position, _mainCamera.transform.position);

        if(_isActived && distanceToPlayer < Distance)
        {
            gameObject.SetActive(false);
            return;
        }

        //목적지와 플레이어와 거리가 가까워졌을 때 게임 상태 변형
        //"목적지에 도착했을 때"를 얻는 것은 이 코드에서 하면 됨
        if (distanceToPlayer < Distance)
        {
            Debug.Log("목적지에 도착함");
            _isActived = true;
        }
    }
}