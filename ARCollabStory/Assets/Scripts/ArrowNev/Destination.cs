using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using Google.XR.ARCoreExtensions;

public class Destination : MonoBehaviour
{
    [SerializeField]
    private Text _collisionLogText;
    private int _count = 0;

    private string _missionType;
    public string MissionType
    {
        get { return _missionType; }
        set { _missionType = value; }
    }

    private string _missionStatus;
    public string MissionStatus
    {
        get { return _missionStatus; }
        set { _missionStatus = value; }
    }

    /// <summary>
    /// 오브젝트와 실행 기기의 거리를 측정하여 게임의 상태를 변경하는 함수 
    /// </summary>
    /// <param name="playerPos"></param>
    public void StartCheckingDistance(Vector3 playerPos)
    {
        StartCoroutine(CheckDistance(playerPos));
    }

    private IEnumerator CheckDistance(Vector3 _playerPos)
    {
        while(true)
        {
            float distance = Vector3.Distance(transform.position, _playerPos);
            Debug.Log($"{distance}");
            if (distance < 0.5f)
            {
                Debug.Log($"{this.gameObject.name}과 충분히 가까움");
                GameManager.Instance.ChangeStatus.Invoke();
                yield break;
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            Debug.Log($"{this.gameObject.name}오브젝트와 닿았다");
        }
    }
}
