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

    private int _grassNowCount = 0;
    private int _grassMaxCount;
    private int _grassCatchCount;

    private bool[] _isUsed;
    private Queue<int> _randomIndexQueue = new Queue<int>();

    private const int FirstAppearance = 3;
    private bool _isFirstAppear = false;

    private const float RespawnTime = 5f;
    
    private bool _isCreated = false;
    private bool _isSpawnStarted = false;

    private void Awake()
    {
        _arAnchorManager = GetComponent<ARAnchorManager>();
        _anchorDataManager = GetComponent<AnchorDataManager>();
    }

    private void Update()
    {
        if (!_isCreated || _isSpawnStarted) 
        { 
            return;
        }

        FirstAppear();
        StartCoroutine(AppearAfter());
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

        _grasses = new GameObject[anchorCount];
        _isUsed = new bool[anchorCount];
        _grassMaxCount = anchorCount;

        RandomIndexQueueCreate();

        for (int i = 0; i < anchorCount; i++)
        {
            // anchorID�� ����� arCloudAnchor ��ȯ
            string anchorID = _anchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = _arAnchorManager.ResolveCloudAnchorId(anchorID);

            // ��Ŀ ��ġ�� Ǯ���� ����
            _grasses[i] = Instantiate(GrassPrefab, arCloudAnchor.transform);
            // Ǯ���̸� ���� ������ �����ϱ� ���� parent�� ����
            _grasses[i].transform.parent = gameObject.transform;
            _grasses[i].SetActive(false);
        }

        _isCreated = true;
    }

    /// <summary>
    /// ������ ������ �̸� �������� �����ϴ� �޼���
    /// </summary>
    private void RandomIndexQueueCreate()
    {
        int count = 0;

        while (count < _grassMaxCount)
        {
            int randomNum = Random.Range(0, _grassMaxCount);

            // ���� ���ڰ� �ƴ϶��
            if (!_isUsed[randomNum])
            {
                // ������ ������ ť�� ����
                _randomIndexQueue.Enqueue(randomNum);
                _isUsed[randomNum] = true;
                count++;
            }
        }
    }

    /// <summary>
    /// Ǯ���̰� �������� �ϳ��� �������� �޼���
    /// </summary>
    private void RandomAppear()
    {
        // �����ϰ� ����� ������ �ҷ���
        int randomNum = _randomIndexQueue.Dequeue();

        _grasses[randomNum].SetActive(true);
        // ��Ŀ�� ���鿡 �ʹ� ��¦ �پ� �־ Ǯ���̰� �� �� �� ���̵��� ���� �÷��ش�.
        _grasses[randomNum].transform.Translate(new Vector3(0f, 0.2f, 0f), Space.World);
        _grassNowCount++;
    }

    /// <summary>
    /// ù 1ȸ�� ����, Ǯ���̸� �ѹ��� �������� �����ϴ� �޼���
    /// </summary>
    private void FirstAppear()
    {
        if (_isFirstAppear)
        {
            return;
        }

        while (_grassNowCount < FirstAppearance)
        {
            RandomAppear();
        }

        _isFirstAppear = true;
    }

    /// <summary>
    /// ���� �ð����� Ǯ���̸� �����ϴ� �ڷ�ƾ �Լ�
    /// </summary>
    private IEnumerator AppearAfter()
    {
        _isSpawnStarted = true;

        while (_grassNowCount < _grassMaxCount)
        {
            yield return new WaitForSecondsRealtime(RespawnTime);
            RandomAppear();
        }

        StopCoroutine(AppearAfter());
    }

    /// <summary>
    /// Ǯ���̸� ���� ������ count�� ���ִ� �޼���
    /// </summary>
    public void CatchGrass()
    {
        _grassCatchCount++;
        if (_grassCatchCount == _grassMaxCount)
        {
            Debug.Log("�� ��Ҵ�");
        }
    }
}
