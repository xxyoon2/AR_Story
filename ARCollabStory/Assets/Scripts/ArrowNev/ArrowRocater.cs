using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRocater : MonoBehaviour
{
    private Vector3 _playerPos;
    private Vector3 _destinationPos;

    private void Awake()
    {
        _playerPos = GameManager.Instance.PlayerPos;
        // 나중에 CSV 양식에 따라 수정 가능성 있음
        _destinationPos = GameManager.Instance.CurrentDestination.transform.position;
    }

    /// <summary>
    /// 플레이어를 중심으로 Y축으로만 목적지를 향해 회전하는 함수
    /// Update문에 넣어야 함
    /// </summary>
    private void UpdateArrowRocaterTransform()
    {
        transform.position = _playerPos;

        Vector3 targetPos = new Vector3(_destinationPos.x, transform.position.y, _destinationPos.z);
        transform.LookAt(targetPos);

    }

    /// <summary>
    /// 화살표 네비게이션을 끄고 키는 함수
    /// </summary>
    /// <param name="On">true : 킴 , false : 끔</param>
    public void SetActiveArrowRocater(bool isActive)
    {
       GetComponentInChildren<Transform>().gameObject.SetActive(isActive);
    }

}
