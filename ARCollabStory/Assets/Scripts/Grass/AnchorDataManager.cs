using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// List를 직렬화하기 위한 class
[Serializable]
public class SerializationData<T>
{
    [SerializeField] private List<T> _data;
    [SerializeField] private int _dataCount;

    /// <summary>
    /// 불러온 파일을 다시 List<T> 타입으로 변환해 반환하는 메서드
    /// </summary>
    /// <returns>List<T>의 data</returns>
    public List<T> ToList()
    {
        return _data;
    }

    /// <summary>
    /// 저장된 데이터의 개수를 반환하는 메서드
    /// </summary>
    /// <returns>데이터의 개수</returns>
    public int CheckCount()
    {
        return _dataCount;
    }

    /// <summary>
    /// List를 직렬화 해주는 생성자
    /// </summary>
    /// <param name="data">list에 저장된 데이터</param>
    /// <param name="count">list에 저장된 데이터의 개수</param>
    public SerializationData(List<T> data, int count)
    {
        _data = data;
        _dataCount = count;
    }
}

// 저장할 데이터 class
[Serializable]
public class AnchorData
{
    public string AnchorName;
    public string AnchorID;

    public AnchorData(string anchorName, string anchorID)
    {
        AnchorName = anchorName;
        AnchorID = anchorID;
    }
}

public class AnchorDataManager : MonoBehaviour
{
    private List<AnchorData> _anchorDatas = new List<AnchorData>();
    private string _dataFileName = "DataFile";
    private string _anchorDataFileName = "HideAndSeekTest.json";

    /// <summary>
    /// Anchor List에 data가 몇 개 있는지 반환하는 메서드
    /// </summary>
    /// <returns>Anchor data의 개수</returns>
    public int CountAnchorData()
    {
        return _anchorDatas.Count;
    }

    /// <summary>
    /// 특정 앵커의 ID를 반환하는 메서드
    /// </summary>
    /// <param name="index">ID를 반환하고 싶은 Anchor의 index</param>
    /// <returns>Anchor의 ID</returns>
    public string GetAnchorID(int index)
    {
        return _anchorDatas[index].AnchorID;
    }

    /// <summary>
    /// 저장된 파일을 불러와 Anchor List로 만드는 메서드
    /// </summary>
    public void Load()
    {
        // 파일을 불러올 경로 생성
        string filePath = Path.Combine(Application.persistentDataPath, _dataFileName, _anchorDataFileName);
        Debug.Log(filePath);

        // 해당 경로에 파일이 존재하지 않는다면 log 출력
        if (!File.Exists(filePath))
        {
            Debug.Log("해당 파일을 찾을 수 없습니다.");
        }
        else
        {
            // 해당 경로에서 파일을 불러옴
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            byte[] byteData = new byte[fileStream.Length];
            fileStream.Read(byteData, 0, byteData.Length);
            fileStream.Close();

            // 불러온 Json 파일을 String으로 변환
            string fromJson = Encoding.UTF8.GetString(byteData);

            // String data를 List 타입의 data로 변환
            SerializationData<AnchorData> serializationData = JsonUtility.FromJson<SerializationData<AnchorData>>(fromJson);
            _anchorDatas = serializationData.ToList();

            Debug.Log("성공적으로 로드했습니다.");

            // data의 개수를 세고 데이터가 없다면 log 출력
            int dataCount = serializationData.CheckCount();
            if (dataCount == 0)
            {
                Debug.Log("저장된 내용이 없습니다.");
                return;
            }
        }
    }
}
