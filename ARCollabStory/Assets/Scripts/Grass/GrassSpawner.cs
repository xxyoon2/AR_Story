using Google.XR.ARCoreExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GrassSpawner : MonoBehaviour
{
    public GameObject GrassPrefab;
    public ARAnchorManager ARAnchorManager;

    private AnchorDataManager _anchorDataManager;
    private GameObject[] _grasses;

    public void Spawn()
    {
        _anchorDataManager = GetComponent<AnchorDataManager>();

        int anchorCount = _anchorDataManager.CountAnchorData();
        if (anchorCount == 0)
        {
            Debug.Log("저장된 데이터가 없습니다.");
            return;
        }

        _grasses = new GameObject[anchorCount];

        for (int i = 0; i < anchorCount; i++)
        {
            ARCloudAnchor arCloudAnchor = ARAnchorManagerExtensions.ResolveCloudAnchorId(ARAnchorManager, _anchorDataManager.GetAnchorID(i));
            Vector3 position = arCloudAnchor.transform.position + new Vector3(0f, 0.1f, 0f);
            Quaternion rotation = arCloudAnchor.transform.rotation;

            _grasses[i] = Instantiate(GrassPrefab, position, rotation);
            //_grasses[i].SetActive(false);
        }
    }
}
