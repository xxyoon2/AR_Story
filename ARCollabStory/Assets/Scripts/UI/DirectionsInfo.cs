using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionsInfo : MonoBehaviour
{
    // ������ ������ŭ ������ �� ��ư ui�� csv ���Ͽ��� �Ľ��� ������ ��ġ �����Ϳ� �����ϴ� ��ũ��Ʈ


    private Locations[] _directionAreas;
    private int _areaCount;
    
    void Start()
    {
        // �������� ����ŭ ��ġ ������ ���� �迭 ����
        _areaCount = transform.childCount;
        _directionAreas = new Locations[_areaCount];
        Debug.Log("�������迭����");

        for(int i = 0; i < _areaCount; i++)
        {
            _directionAreas[i] = transform.GetChild(i).gameObject.GetComponent<Locations>();
            Debug.Log("�޾ƿ�");
            _directionAreas[i].OrderIndex = GameManager.Instance.LocationRecords[i + 1].DirectionIndex;
            Debug.Log("��ư�����ؿ�");
        }

        // �������� ���¿� ���� ��ư ui�� ������ �ٲ��ִ� �Լ� ����
        Invoke("ButtonColorChange", 2f);
    }

    void ButtonColorChange()
    {
        // ������ ���¸� ������Ʈ�ϴ� �̺�Ʈ ����
        GameManager.Instance.StatusUpdateAlarm();
    }
}
