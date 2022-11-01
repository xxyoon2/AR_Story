using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using Google.XR.ARCoreExtensions;

public class DestinationsBehaviour : MonoBehaviour
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

    public void StartCheckingDistance(Vector3 playerPos)
    {
        StartCoroutine(CheckDistance(playerPos));
    }
    private IEnumerator CheckDistance(Vector3 _playerPos)
    {
        while(true)
        {
            float distance = Vector3.Distance(transform.position, _playerPos);
            if (distance < 0.5f)
            {
                Debug.Log($"{_missionType} 목적지 도착");
                GameManager.Instance.ChangeStatus.Invoke();
                yield break;
            }
        yield return new WaitForSeconds(0.5f);
        }

    }
}
