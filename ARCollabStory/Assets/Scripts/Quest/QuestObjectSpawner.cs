using Google.XR.ARCoreExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class QuestObjectSpawner : MonoBehaviour
{
    public GameObject QuestObjectPrefab;
    public string JsonFileName;

    private ARAnchorManager _arAnchorManager;
    private AnchorDataManager _anchorDataManager;
    private GameObject[] _questObjects;

    private int _objectCatchCount = 0;
    private int _objectMaxCount;
    private bool _questComplete = false;

    private void Awake()
    {
        _arAnchorManager = GetComponent<ARAnchorManager>();
        _anchorDataManager = GetComponent<AnchorDataManager>();

        _anchorDataManager.Load(JsonFileName);
    }

    private void Update()
    {
        if (_questComplete)
        {
            // 여기에 다른 곳으로 넘어가는 무언가 넣기
        }
    }

    /// <summary>
    /// anchor ID를 이용해 지정 좌표에 오브젝트를 생성하는 메서드
    /// </summary>
    public void Create()
    {
        int anchorCount = _anchorDataManager.CountAnchorData();
        // 앵커가 하나도 없다면
        if (anchorCount == 0)
        {
            Debug.Log("저장된 데이터가 없습니다.");
            return;
        }

        _questObjects = new GameObject[anchorCount];
        _objectMaxCount = anchorCount;

        for (int i = 0; i < anchorCount; i++)               
        {
            // anchorID를 사용해 arCloudAnchor 반환
            string anchorID = _anchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = _arAnchorManager.ResolveCloudAnchorId(anchorID);

            // 앵커 위치에 생성
            _questObjects[i] = Instantiate(QuestObjectPrefab, arCloudAnchor.transform);
        }

        Debug.Log("생성 완료");
    }

    /// <summary>
    /// 오브젝트를 잡을 때마다 count를 세주는 메서드
    /// </summary>
    public void CatchQuestObject()
    {
        _objectCatchCount++;
        if (_objectCatchCount == _objectMaxCount)
        {
            _questComplete = true;
            Debug.Log("끝");
        }
    }
}
