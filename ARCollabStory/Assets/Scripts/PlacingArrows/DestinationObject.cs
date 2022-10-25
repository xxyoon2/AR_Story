using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum TypeOfDestinationObject
{
    StartQuestDestination,
    StartMiniGameDestination,
    EndQuestDestination
}

public class DestinationObject : MonoBehaviour
{
    public float Distance = 0.01f;

    private GameObject _mainCamera;

    private TypeOfDestinationObject _typeOfDestinationObject;
    private bool _isQuestStart;
    private bool _isQuestEnd;
    private bool _isMiniGameStart;
    public bool IsQuestStart
    {
        get
        {
            return _isQuestStart;
        }
        set
        {
            _isQuestStart = value;
        }
    }
    public bool IsQuestEnd
    {
        get
        {
            return _isQuestEnd;
        }
        set
        {
            _isQuestEnd = value;
        }
    }

    public bool IsMiniGameStart
    {
        get
        {
            return _isMiniGameStart;
        }
        set
        {
            _isMiniGameStart = value;
        }
    }

    private void Awake()
    {
        _isQuestStart = false;
        _isMiniGameStart = false;
        _isQuestEnd = false;
        _mainCamera = GameObject.Find("AR Camera");
    }

    private void Update()
    {
        double distanceToPlayer = Vector3.Distance(transform.position, _mainCamera.transform.position);

        //목적지와 플레이어와 거리가 가까워졌을 때 게임 상태 변형
        //"목적지에 도착했을 때"를 얻는 것은 이 코드에서 하면 됨
        if (distanceToPlayer < Distance)
        {
            if (!_isMiniGameStart && _typeOfDestinationObject == TypeOfDestinationObject.StartMiniGameDestination)
            {
                _isMiniGameStart = true;
            }
            else if (!_isQuestStart && _typeOfDestinationObject == TypeOfDestinationObject.StartQuestDestination)
            {
                _isQuestStart = true;
            }
            else if (_typeOfDestinationObject == TypeOfDestinationObject.EndQuestDestination)
            {
                _isQuestEnd = true;
            }

        }
    }

}