using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Google.XR.ARCoreExtensions;

public class PlacingObjectSpawner : MonoBehaviour
{
    public AnchorDataManager AnchorDataManager;
    public GameObject Prefab;

    private ARAnchorManager ARAnchorManager;
    private GameObject[] _prefabs;

    private void Awake()
    {
        ARAnchorManager = GetComponent<ARAnchorManager>();
    }

    /// <summary>
    /// 목적지 오브젝트를 DestinationAnchorDB​.json 앵커 데이터를 바탕으로 생성하여 배치
    /// Awake에서 생성할 경우 오류가 발생하므로 임시로 버튼을 누를 때 생성하여 테스트함
    /// </summary>
    public void Create()
    {
        AnchorDataManager.Load("DestinationAnchorDB​.json");

        int CountAnchors = AnchorDataManager.CountAnchorData();
        _prefabs = new GameObject[CountAnchors]; 

        for(int i = 0; i < CountAnchors; i++)
        {
            string anchorID = AnchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = ARAnchorManager.ResolveCloudAnchorId(anchorID);

            _prefabs[i] = Instantiate(Prefab, arCloudAnchor.transform);
            //프리팹 생성할 때 DestinationInfo의 정보를 넣어야함
        }
    }
}