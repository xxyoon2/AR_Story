using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locations : MonoBehaviour
{
    // 각각의 목적지를 csv데이터와 연동하고 상태를 저장하는 스크립트
    private int _orderIndex;
    public int OrderIndex
    {
        get { return _orderIndex; }
        set { _orderIndex = value; }
    }
    private string _directionStatus;
    private bool _canInteract;

    // ui의 색상을 변경하기 위한 변수
    private ColorBlock _colorBlock;
    private Button _button;

    private void Start()
    {
        _button = transform.GetComponent<Button>();
        _colorBlock = _button.colors;
        GameManager.Instance.DirectionsStatusUpdate.AddListener(ChangeStatus);
    }

    /// <summary>
    /// 목적지의 진행상황에 따라 ui의 색상과 상호작용 가능 여부를 수정한다
    /// 중복 코드는 차후 수정 예정
    /// </summary>
    private void ChangeStatus()
    {
        _directionStatus = GameManager.Instance.LocationRecords[_orderIndex + 1].MissionStatus;

        switch(_directionStatus)
        {
            case "NotStarted":
                _colorBlock.normalColor = Color.gray;
                _button.colors = _colorBlock;
                _canInteract = false;
                break;
            case "InProgress":
                _colorBlock.normalColor = Color.blue;
                _button.colors = _colorBlock;
                _canInteract = true;
                break;
            case "Done":
                _colorBlock.normalColor = Color.red;
                _button.colors = _colorBlock;
                _canInteract = true;
                break;
        }
    }

    /// <summary>
    /// 사용자가 ui를 터치했을 때 상호작용 여부에 따라 다른 로그를 출력
    /// </summary>
    public void OnClick()
    {
        if(_canInteract)
        {
            Debug.Log("상호작용 가능");
        }
        else
        {
            Debug.Log("현재 비활성화 상태입니다");
        }
    }
}
