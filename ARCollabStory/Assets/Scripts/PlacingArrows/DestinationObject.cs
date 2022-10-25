using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// �������� ����Ű�� ��ġ�� ������Ʈ�� Ÿ��
/// </summary>
public enum TypeOfDestinationObject
{
    StartQuestDestination,
    EndQuestDestination,
    StartMiniGameDestination,
    EndMiniGameDestination
}

public class DestinationObject : MonoBehaviour
{
    public TypeOfDestinationObject TypeOfDestination;
    public float Distance = 0.01f;

    private GameObject _mainCamera;
    private bool _isActived;
  
    private void Awake()
    {
        _mainCamera = GameObject.Find("AR Camera");
    }

    private void Update()
    {
        double distanceToPlayer = Vector3.Distance(transform.position, _mainCamera.transform.position);

        if(_isActived && distanceToPlayer < Distance)
        {
            gameObject.SetActive(false);
            return;
        }

        //�������� �÷��̾�� �Ÿ��� ��������� �� ���� ���� ����
        //"�������� �������� ��"�� ��� ���� �� �ڵ忡�� �ϸ� ��
        if (distanceToPlayer < Distance)
        {
            Debug.Log("�������� ������");
            _isActived = true;
        }
    }
}