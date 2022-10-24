using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locations : MonoBehaviour
{
    private string _directionStatus;
    private int _orderIndex;
    private bool _canInteract;
    public int OrderIndex
    {
        get { return _orderIndex; }
        set { _orderIndex = value; }
    }

    private ColorBlock _colorBlock;
    private Button _button;
    private void Start()
    {
        _button = transform.GetComponent<Button>();
        _colorBlock = _button.colors;
        GameManager.Instance.DirectionsStatusUpdate.AddListener(ChangeStatus);
    }

    private void ChangeStatus()
    {
        _directionStatus = GameManager.Instance.LocationRecords[_orderIndex].MissionStatus;

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
