using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartTrigger : MonoBehaviour
{
    private bool _isGameStart;

    private void Update()
    {
        if (_isGameStart)
        {
            // �� �κп� �ٸ� �̴� ���� Ȥ�� ����Ʈ�� ����Ǵ� �޼��带 �θ� �� ��
            Debug.Log("���� ����");
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            _isGameStart = true;
        }
    }
}
