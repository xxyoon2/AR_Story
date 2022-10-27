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
            // ���⿡ �ٸ� ������ �Ѿ�� ���� �ֱ�
        }
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
        _objectMaxCount = anchorCount;

        for (int i = 0; i < anchorCount; i++)               
        {
            // anchorID�� ����� arCloudAnchor ��ȯ
            string anchorID = _anchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = _arAnchorManager.ResolveCloudAnchorId(anchorID);

            // ��Ŀ ��ġ�� ����
            _questObjects[i] = Instantiate(QuestObjectPrefab, arCloudAnchor.transform);
        }

        Debug.Log("���� �Ϸ�");
    }

    /// <summary>
    /// ������Ʈ�� ���� ������ count�� ���ִ� �޼���
    /// </summary>
    public void CatchQuestObject()
    {
        _objectCatchCount++;
        if (_objectCatchCount == _objectMaxCount)
        {
            _questComplete = true;
            Debug.Log("��");
        }
    }
}
