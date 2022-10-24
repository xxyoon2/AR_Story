using Google.XR.ARCoreExtensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class GrassSpawner : MonoBehaviour
{
    public GameObject GrassPrefab;
    public ARAnchorManager ARAnchorManager;

    private LoadAnchorData _loadAnchorData;
    private GameObject[] _grasses;

    private void Awake()
    {
        _loadAnchorData = GetComponent<LoadAnchorData>();

        int anchorCount = _loadAnchorData.CountAnchorData();
        if (anchorCount == 0)
        {
            Debug.Log("����� �����Ͱ� �����ϴ�.");
            return;
        }

        _grasses = new GameObject[anchorCount];

        for (int i = 0; i < anchorCount; i++)
        {
            ARCloudAnchor arCloudAnchor = ARAnchorManagerExtensions.ResolveCloudAnchorId(ARAnchorManager, _loadAnchorData.GetAnchorID(i));
            Vector3 position = arCloudAnchor.transform.position + new Vector3(0f, 0.1f, 0f);
            Quaternion rotation = arCloudAnchor.transform.rotation;

            _grasses[i] = Instantiate(GrassPrefab, position, rotation);
            _grasses[i].SetActive(false);
        }
    }
}
