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
    /// cloud Anchor ID�� ����ؼ� anchor ��ġ�� Ǯ���̸� �����ϴ� �޼���
    /// </summary>
    public void Create()
    {
        int anchorCount = _anchorDataManager.CountAnchorData();
        // ��Ŀ�� �ϳ��� ���ٸ�
        if (anchorCount == 0)
        {
            Debug.Log("����� �����Ͱ� �����ϴ�.");
            return;
        }

        // ��Ŀ�� ������ŭ ������Ʈ ����
        _grasses = new GameObject[anchorCount];

        for (int i = 0; i < anchorCount; i++)
        {
            // anchorID�� ����� arCloudAnchor ��ȯ
            string anchorID = _anchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = _arAnchorManager.ResolveCloudAnchorId(anchorID);

            // ��Ŀ ��ġ�� Ǯ���� ����
            _grasses[i] = Instantiate(GrassPrefab, arCloudAnchor.transform);
            //_grasses[i].SetActive(false);
        }
    }
}
