using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locations : MonoBehaviour
{
    // 각각의 목적지를 csv데이터와 연동하고 상태를 저장하는 스크립트
    private int _orderIndex;
    private string _previousStatus;
    public int OrderIndex
    {
        get { return _orderIndex; }
        set { _orderIndex = value; }
    }

    [SerializeField]
    private string _directionStatus;
    public string DirectionStatus
    {
        get { return _directionStatus; }
        set { _directionStatus = value; }
    }

    private bool _canInteract;

    // ui의 색상을 변경하기 위한 변수
    private Image _image;

    private void OnEnable()
    {
        _image = transform.GetComponent<Image>();
    }

    /// <summary>
    /// 목적지의 진행상황에 따라 ui의 색상과 상호작용 가능 여부를 수정한다
    /// 중복 코드는 차후 수정 예정
    /// </summary>
    public void ChangeColor()
    {
        _previousStatus = _directionStatus;
        switch (_directionStatus)
        {
            case "NotStarted":
                _image.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                _canInteract = false;
                break;
            case "InProgress":
                _image.color = new Color(0, 0, 1);
                _canInteract = true;
                break;
            case "Done":
                _image.color = new Color(1, 0, 0, 0.5f);
                _canInteract = true;
                Debug.Log("구역 활성화 해야됨");
                GameManager.Instance.AlarmQuestAreaInfo(_orderIndex);
                break;
        }
    }

    /// <summary>
    /// 사용자가 ui를 터치했을 때 상호작용 여부에 따라 다른 로그를 출력
    /// </summary>
    public void OnClick()
    {
        if(_canInteract && _directionStatus == "InProgress")
        {
            // 상호작용 가능한 버튼일 시 클릭 후 실행될 내용을 여기에 작성
        }
        else
        {
            // 현재 클릭해도 아무 기능을 수행하지 않는 버튼일 시 로그 출력
            Debug.Log("현재 비활성화 상태입니다");
        }
    }
}
