using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;


public class GPSManager : SingletonBehaviour<GPSManager>
{
    public float latitude;
    public float longitude;
    public UnityEvent<float, float> SetMapImage = new UnityEvent<float, float>();

    private bool _isRunning = true;
    private LocationServiceStatus _serviceStatus = LocationServiceStatus.Stopped;

    private void Start()
    {
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {

#if UNITY_EDITOR
        //Unity Remote와 연결되지 않을 시 null 반환
        while (!UnityEditor.EditorApplication.isRemoteConnected)
        {
            //Debug.Log("리모트 연결 안 됨");
            yield return null;
        }
#endif
        _serviceStatus = LocationServiceStatus.Initializing;

        // 사용자 위치 권한 허용여부 설정
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("user has not enabled gps");
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        if (Permission.HasUserAuthorizedPermission(Permission.FineLocation) && !Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        Input.location.Start();
        yield return new WaitForSeconds(3f);
        StartCoroutine(WaitLocationInitializing());

        _serviceStatus = Input.location.status;
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        while (_isRunning)
        {
            yield return new WaitForSeconds(1f);
            UpdateGPS();
        }
    }

    IEnumerator WaitLocationInitializing()
    {
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1f);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed Out");
            yield break;
        }
    }

    private void UpdateGPS()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;

            _serviceStatus = Input.location.status;

            SetMapImage.Invoke(latitude, longitude);
        }
        else
        {
            Debug.Log("GPS is " + Input.location.status);
            Input.location.Start();
        }
    }
}