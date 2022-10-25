using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionsInfo : MonoBehaviour
{
    // 목적지 개수만큼 생성해 둔 버튼 ui를 csv 파일에서 파싱한 각각의 위치 데이터와 연동하는 스크립트
    private Locations[] _directionAreas;
    private int _areaCount;

    private void OnEnable()
    {
        GameManager.Instance.SetCSVData.AddListener(SetInfoObjects);
    }
    void SetInfoObjects()
    {
        // 목적지의 수만큼 위치 정보를 담을 배열 생성
        _areaCount = transform.childCount;
        _directionAreas = GetComponentsInChildren<Locations>();
        
        Debug.Log($"LocationRecords is exist? {GameManager.Instance.LocationRecords != null}");
        for(int i = 0; i < _areaCount; i++)
        {
            _directionAreas[i].OrderIndex = GameManager.Instance.LocationRecords[i + 2].DirectionIndex;
        }
        // 목적지의 상태에 따라 버튼 ui의 색상을 바꿔주는 함수 실행
        Invoke("ButtonColorChange", 1f);
    }

    void ButtonColorChange()
    {
        // 목적지 상태를 업데이트하는 이벤트 실행
        GameManager.Instance.StatusUpdateAlarm();
    }
}
