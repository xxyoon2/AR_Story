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
            // 이 부분에 다른 미니 게임 혹은 퀘스트와 연결되는 메서드를 두면 될 듯
            Debug.Log("게임 시작");
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
