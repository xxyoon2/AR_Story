using Google.XR.ARCoreExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GrassSpawner : MonoBehaviour
{
    public GameObject GrassPrefab;

    private ARAnchorManager _arAnchorManager;
    private AnchorDataManager _anchorDataManager;
    private GameObject[] _grasses;

    private void Awake()
    {
        _arAnchorManager = GetComponent<ARAnchorManager>();
        _anchorDataManager = GetComponent<AnchorDataManager>();
    }

    /// <summary>
    /// cloud Anchor ID를 사용해서 anchor 위치에 풀덩이를 생성하는 메서드
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

        // 앵커의 개수만큼 오브젝트 생성
        _grasses = new GameObject[anchorCount];

        for (int i = 0; i < anchorCount; i++)
        {
            // anchorID를 사용해 arCloudAnchor 반환
            string anchorID = _anchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = _arAnchorManager.ResolveCloudAnchorId(anchorID);

            // 앵커 위치에 풀덩이 생성
            _grasses[i] = Instantiate(GrassPrefab, arCloudAnchor.transform);
            //_grasses[i].SetActive(false);
        }
    }
}
