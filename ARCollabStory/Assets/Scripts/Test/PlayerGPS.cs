using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;

public class PlayerGPS : MonoBehaviour
{
    private float latitude;
    private float longitude;

    private bool _isRunning = true;
    private LocationServiceStatus _serviceStatus = LocationServiceStatus.Stopped;

    private void Start()
    {
        StartCoroutine(StartLocationService());
    }

    public IEnumerator StartLocationService()
    {

#if UNITY_EDITOR
        //Unity Remote�� ������� ���� �� null ��ȯ
        while (!UnityEditor.EditorApplication.isRemoteConnected)
        {
            yield return null;
        }
#endif
        _serviceStatus = LocationServiceStatus.Initializing;

        // ����� ��ġ ���� ��뿩�� ����
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
            yield return new WaitForSeconds(0.1f);
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

    /// <summary>
    /// ������� ��ġ ���¸� Ȯ���ϰ� �� �̹����� �����ϰų� ��ġ ������ �ٽ� �޾ƿ����� �õ��Ѵ�
    /// </summary>
    private void UpdateGPS()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            if (latitude != Input.location.lastData.latitude || longitude != Input.location.lastData.longitude)
            {
                latitude = Input.location.lastData.latitude;
                longitude = Input.location.lastData.longitude;
                Debug.Log($"��ġ �ٲ�. ���� ��ġ: {latitude}, {longitude}");
                Debug.Log($"�Ÿ�: {CheckDistance(latitude, longitude)}m");
            }

            _serviceStatus = Input.location.status;

        }
        else
        {
            Debug.Log("GPS is " + Input.location.status);
            Input.location.Start();
        }
    }

    private float _targetLatitude = 37.5397697f;
    private float _targetLonguitude = 127.1232618f;

    private double CheckDistance(float latitude, float longuitude)
    {
        double digree = Mathf.PI / 180.0;

        float playerLat = latitude * (float)digree;
        float playerLong = longuitude * (float)digree;
        float targetLat = _targetLatitude * (float)digree;
        float targetLong = _targetLonguitude * (float)digree - playerLong;
        float latSin = (float)((targetLat - playerLat) / 2.0);
        double distance = Mathf.Pow(Mathf.Sin(latSin), 2.0f) + Mathf.Cos(playerLat) * Mathf.Cos(targetLat) * Mathf.Pow(Mathf.Sin((float)(targetLong / 2.0)), 2.0f);

        return 6376500.0 * (2.0 * Mathf.Atan2((Mathf.Sqrt((float)distance)), Mathf.Sqrt((float)(1.0 - distance))));
    }
}
