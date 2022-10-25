using System;
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
    public float Distance = 0.01f;
    public TypeOfDestinationObject ObjectType;

    private bool _isActive;
    private bool _isCloseToPlayer;
    private GameObject _mainCamera;

    public bool IsCloseToPlayer
    {
        get { return _isCloseToPlayer;}
        set { _isCloseToPlayer = value;}
    }

    private void Awake()
    {
        _mainCamera = GameObject.Find("AR Camera");
    }

    private void Update()
    {
        double distanceToPlayer = Vector3.Distance(transform.position, _mainCamera.transform.position);

        if (distanceToPlayer < Distance)
        {
            //도착했음을 알리는 이벤트 함수 필요 + DestinationObjectInfo()의 반환값을 받아야 함
            //반환되는 목적지의 타입에 따라 미니 퀘스트, 미니 게임 등을 실행하도록 만들 수 있음
            return;
        }
    }

    //목적지 오브젝트의 타입과 도착한적이 있는지, 없는지를 판별하는 bool값을 반환하는 함수
    Tuple<bool,TypeOfDestinationObject> DestinationObjectInfo()
    {
        bool isCloseToPlayer = _isCloseToPlayer;
        TypeOfDestinationObject objectType = ObjectType;
        
        return new Tuple<bool, TypeOfDestinationObject>(isCloseToPlayer, objectType);
    }
}