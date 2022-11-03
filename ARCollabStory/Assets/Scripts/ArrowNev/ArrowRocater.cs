using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRocater : MonoBehaviour
{
    private Transform _destinationPos;

    private void Awake()
    {
        // ���߿� CSV ��Ŀ� ���� ���� ���ɼ� ����
        _destinationPos = GameManager.Instance.CurrentDestination.transform;
    }

    /// <summary>
    /// Y�����θ� �������� ���� ȸ���ϴ� �Լ�
    /// Update���� �־�� ��
    /// </summary>
    private void UpdateArrowRotation()
    {
        //�׽�Ʈ��
        transform.LookAt(new Vector3(_destinationPos.position.x, transform.position.y, _destinationPos.position.z));
    }

    /// <summary>
    /// ȭ��ǥ �׺���̼��� ���� Ű�� �Լ�
    /// </summary>
    /// <param name="On">true : Ŵ , false : ��</param>
    public void SetActiveArrowRocater(bool isActive)
    {
       GetComponentInChildren<Transform>().gameObject.SetActive(isActive);
    }

}
