using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
        GameManager.Instance.DirectionsStatusUpdate.AddListener(UpdateDirectionsStatus);
        GameManager.Instance.SetVisibleQuestArea.AddListener(SetActiveQuestArea);
        // 목적지의 수만큼 위치 정보를 담을 배열 생성
        _areaCount = transform.childCount;
        _directionAreas = GetComponentsInChildren<Locations>();
    }

    /// <summary>
    /// 퀘스트 시작 지점에서 대화가 끝날 시 퀘스트 범위를 볼 수 있도록 맵에 표시
    /// </summary>
    /// <param name="indexInfo">맵에 표시할 범위 인덱스</param>
    public void SetActiveQuestArea(int indexInfo)
    {
        _directionAreas[indexInfo].gameObject.SetActive(true);
    }

    void SetInfoObjects()
    {
        for(int i = 0; i < _areaCount; i++)
        {
            _directionAreas[i].OrderIndex = GameManager.Instance.LocationRecords[i + 1].DirectionIndex;
            _directionAreas[i].MissionType = GameManager.Instance.LocationRecords[i + 1].MissionTypeInfo;
            _directionAreas[i].DirectionStatus = GameManager.Instance.LocationRecords[i + 1].MissionStatus;
            // 목적지 정보가 퀘스트 구역(수행 범위를 표시하기 위한 ui)일 시 비활성화

            GameManager.Instance.StatusUpdateAlarm(i);
            if (_directionAreas[i].MissionType == "QuestArea")
            {
                _directionAreas[i].gameObject.SetActive(false);
            }
        }
    }

    void UpdateDirectionsStatus(int index)
    {
        _directionAreas[index].DirectionStatus = GameManager.Instance.LocationRecords[index + 1].MissionStatus;
        _directionAreas[index].ChangeColor();
    }
}
