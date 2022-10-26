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

    private void Awake()
    {
        _arAnchorManager = GetComponent<ARAnchorManager>();
        _anchorDataManager = GetComponent<AnchorDataManager>();

        _anchorDataManager.Load(JsonFileName);
        Create();
    }

    /// <summary>
    /// anchor ID�� �̿��� ���� ��ǥ�� ������Ʈ�� �����ϴ� �޼���
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

        _questObjects = new GameObject[anchorCount];

        for (int i = 0; i < anchorCount; i++)
        {
            // anchorID�� ����� arCloudAnchor ��ȯ
            string anchorID = _anchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = _arAnchorManager.ResolveCloudAnchorId(anchorID);

            // ��Ŀ ��ġ�� ����
            _questObjects[i] = Instantiate(QuestObjectPrefab, arCloudAnchor.transform);
            // ���� ������ �����ϱ� ���� parent�� ����
            _questObjects[i].transform.parent = gameObject.transform;
        }
    }
}
