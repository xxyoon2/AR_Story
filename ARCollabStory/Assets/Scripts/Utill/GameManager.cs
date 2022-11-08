using System.Collections;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    #region View 전환
    public enum ViewMode
    {
        NONE,
        NOTE,
        MAP,
        MAX,
    }
    
    public ViewMode Mode { get; private set; }
    
    [SerializeField] private GameObject[] _viewController = new GameObject[(int)ViewMode.MAX];
    
    public void SetViewMode(ViewMode mode)
    {
        _viewController[(int)Mode].SetActive(false);
        _viewController[(int)mode].SetActive(true);

        Mode = mode;
    }
    #endregion

    #region CSV 파싱
    public UnityEvent<int> DirectionsStatusUpdate = new UnityEvent<int>();
    public UnityEvent SetCSVData = new UnityEvent();
    public UnityEvent<int> SetVisibleQuestArea = new UnityEvent<int>();
    private List<LocationRecord> _locationRecords;

    // csv 파싱해서 저장할 리스트
    public List<LocationRecord> LocationRecords
    {
        get { return _locationRecords; }
        set { _locationRecords = value; }
    }

    private (List<BookRecord>, List<PuzzleRecord>) _bookInfos;
    public List<BookRecord> bookRecords
    {
        get { return _bookInfos.Item1; }
        set { _bookInfos.Item1 = value; }
    }
    public List<PuzzleRecord> PuzzleRecords
    {
        get { return _bookInfos.Item2; }
        set { _bookInfos.Item2 = value; }
    }

    void Start()
    {
        _locationRecords = CSVParser.GetLocationInfos();
        _bookInfos = CSVParser.GetBookInfos();
        SetCSVData.Invoke();
    }

    public void StatusUpdateAlarm(int index)
    {
        DirectionsStatusUpdate.Invoke(index);
    }

    public void AlarmQuestAreaInfo(int index)
    {
        SetVisibleQuestArea.Invoke(index);
    }
    #endregion
}
