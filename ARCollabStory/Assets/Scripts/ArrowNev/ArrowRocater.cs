using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRocater : MonoBehaviour
{
    private Vector3 _playerPos;
    private Vector3 _destinationPos;

    private void Awake()
    {
        _playerPos = GameManager.Instance.PlayerPos;
        // ���߿� CSV ��Ŀ� ���� ���� ���ɼ� ����
        _destinationPos = GameManager.Instance.CurrentDestination.transform.position;
    }

    /// <summary>
    /// �÷��̾ �߽����� Y�����θ� �������� ���� ȸ���ϴ� �Լ�
    /// Update���� �־�� ��
    /// </summary>
    private void UpdateArrowRocaterTransform()
    {
        transform.position = _playerPos;

        Vector3 targetPos = new Vector3(_destinationPos.x, transform.position.y, _destinationPos.z);
        transform.LookAt(targetPos);

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
