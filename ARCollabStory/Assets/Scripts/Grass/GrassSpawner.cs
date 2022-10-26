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

        _grasses = new GameObject[anchorCount];
        _isUsed = new bool[anchorCount];
        _grassMaxCount = anchorCount;

        RandomIndexQueueCreate();

        for (int i = 0; i < anchorCount; i++)
        {
            // anchorID를 사용해 arCloudAnchor 반환
            string anchorID = _anchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = _arAnchorManager.ResolveCloudAnchorId(anchorID);

            // 앵커 위치에 풀덩이 생성
            _grasses[i] = Instantiate(GrassPrefab, arCloudAnchor.transform);
            // 풀덩이를 잡을 때마다 관리하기 위해 parent로 세팅
            _grasses[i].transform.parent = gameObject.transform;
            _grasses[i].SetActive(false);
        }

        _isCreated = true;
    }

    /// <summary>
    /// 스폰될 순서를 미리 랜덤으로 지정하는 메서드
    /// </summary>
    private void RandomIndexQueueCreate()
    {
        int count = 0;

        while (count < _grassMaxCount)
        {
            int randomNum = Random.Range(0, _grassMaxCount);

            // 사용된 숫자가 아니라면
            if (!_isUsed[randomNum])
            {
                // 랜덤한 순서를 큐에 저장
                _randomIndexQueue.Enqueue(randomNum);
                _isUsed[randomNum] = true;
                count++;
            }
        }
    }

    /// <summary>
    /// 풀덩이가 랜덤으로 하나씩 보여지는 메서드
    /// </summary>
    private void RandomAppear()
    {
        // 랜덤하게 저장된 순서를 불러옴
        int randomNum = _randomIndexQueue.Dequeue();

        _grasses[randomNum].SetActive(true);
        // 앵커는 지면에 너무 바짝 붙어 있어서 풀덩이가 좀 더 잘 보이도록 위로 올려준다.
        _grasses[randomNum].transform.Translate(new Vector3(0f, 0.2f, 0f), Space.World);
        _grassNowCount++;
    }

    /// <summary>
    /// 첫 1회에 한해, 풀덩이를 한번에 여러마리 스폰하는 메서드
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
    /// 일정 시간마다 풀덩이를 스폰하는 코루틴 함수
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
    /// 풀덩이를 잡을 때마다 count를 세주는 메서드
    /// </summary>
    public void CatchGrass()
    {
        _grassCatchCount++;
        if (_grassCatchCount == _grassMaxCount)
        {
            Debug.Log("다 잡았다");
        }
    }
}
