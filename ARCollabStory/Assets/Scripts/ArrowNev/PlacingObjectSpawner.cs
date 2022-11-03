using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Google.XR.ARCoreExtensions;

public class PlacingObjectSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _prefab;
    private GameObject[] _prefabs;
    
    private AnchorDataManager _anchorDataManager;
    private ARAnchorManager _arAnchorManager;

    private void Awake()
    {
        _anchorDataManager = GetComponent<AnchorDataManager>();
        _arAnchorManager = GetComponent<ARAnchorManager>();
    }

    /// <summary>
    /// 목적지 오브젝트를 DestinationAnchorDB​.json 앵커 데이터를 바탕으로 생성하여 배치
    /// Awake에서 생성할 경우 오류가 발생하므로 임시로 버튼을 누를 때 생성하여 테스트함
    /// </summary>
    public void Create()
    {
        _anchorDataManager.Load("DestinationAnchorDB​.json");

        int CountAnchors = _anchorDataManager.CountAnchorData();
        _prefabs = new GameObject[CountAnchors]; 

        for(int i = 0; i < CountAnchors; i++)
        {
            string anchorID = _anchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = _arAnchorManager.ResolveCloudAnchorId(anchorID);

            _prefabs[i] = Instantiate(_prefab, arCloudAnchor.transform);
            //프리팹 생성할 때 DestinationInfo의 정보를 넣어야함
        }
    }
}