using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// List�� ����ȭ�ϱ� ���� class
[Serializable]
public class SerializationData<T>
{
    [SerializeField] private List<T> _data;
    [SerializeField] private int _dataCount;

    /// <summary>
    /// �ҷ��� ������ �ٽ� List<T> Ÿ������ ��ȯ�� ��ȯ�ϴ� �޼���
    /// </summary>
    /// <returns>List<T>�� data</returns>
    public List<T> ToList()
    {
        return _data;
    }

    /// <summary>
    /// ����� �������� ������ ��ȯ�ϴ� �޼���
    /// </summary>
    /// <returns>�������� ����</returns>
    public int CheckCount()
    {
        return _dataCount;
    }

    /// <summary>
    /// List�� ����ȭ ���ִ� ������
    /// </summary>
    /// <param name="data">list�� ����� ������</param>
    /// <param name="count">list�� ����� �������� ����</param>
    public SerializationData(List<T> data, int count)
    {
        _data = data;
        _dataCount = count;
    }
}

// ������ ������ class
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
    /// Anchor List�� data�� �� �� �ִ��� ��ȯ�ϴ� �޼���
    /// </summary>
    /// <returns>Anchor data�� ����</returns>
    public int CountAnchorData()
    {
        return _anchorDatas.Count;
    }

    /// <summary>
    /// Ư�� ��Ŀ�� ID�� ��ȯ�ϴ� �޼���
    /// </summary>
    /// <param name="index">ID�� ��ȯ�ϰ� ���� Anchor�� index</param>
    /// <returns>Anchor�� ID</returns>
    public string GetAnchorID(int index)
    {
        return _anchorDatas[index].AnchorID;
    }

    /// <summary>
    /// ����� ������ �ҷ��� Anchor List�� ����� �޼���
    /// </summary>
    public void Load()
    {
        // ������ �ҷ��� ��� ����
        string filePath = Path.Combine(Application.persistentDataPath, _dataFileName, _anchorDataFileName);
        Debug.Log(filePath);

        // �ش� ��ο� ������ �������� �ʴ´ٸ� log ���
        if (!File.Exists(filePath))
        {
            Debug.Log("�ش� ������ ã�� �� �����ϴ�.");
        }
        else
        {
            // �ش� ��ο��� ������ �ҷ���
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            byte[] byteData = new byte[fileStream.Length];
            fileStream.Read(byteData, 0, byteData.Length);
            fileStream.Close();

            // �ҷ��� Json ������ String���� ��ȯ
            string fromJson = Encoding.UTF8.GetString(byteData);

            // String data�� List Ÿ���� data�� ��ȯ
            SerializationData<AnchorData> serializationData = JsonUtility.FromJson<SerializationData<AnchorData>>(fromJson);
            _anchorDatas = serializationData.ToList();

            Debug.Log("���������� �ε��߽��ϴ�.");

            // data�� ������ ���� �����Ͱ� ���ٸ� log ���
            int dataCount = serializationData.CheckCount();
            if (dataCount == 0)
            {
                Debug.Log("����� ������ �����ϴ�.");
                return;
            }
        }
    }
}
