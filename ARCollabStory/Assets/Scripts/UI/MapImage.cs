using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MapImage : MonoBehaviour
{
    public RawImage mapRawImage;

    // 출력할 맵의 정보를 담은 변수 목록
    [Header("Map Info")]
    private string _strBaseURL = "https://maps.googleapis.com/maps/api/staticmap?";
    private string _centerPos = "37.540233,127.122505";
    private double _latitude = 37.53969;
    private double _longitude = 127.1234;
    private int zoom = 17;
    private int mapWidth = 2400;
    private int mapHeight = 2400;
    [SerializeField]
    private string strAPIKey = "";

    void Start()
    {
        mapRawImage = GetComponent<RawImage>();
        GPSManager.Instance.SetMapImage.AddListener(SendRequestToReloadMap);
    }

    [SerializeField]
    private double destlat;
    [SerializeField]
    private double destlon;

    private double lastLat = 0;
    private double lastLon = 0;

    /// <summary>
    /// 플레이어의 위도/경도 정보가 바뀔 시 새 위치 정보를 기반으로 맵 이미지를 다시 요청한다
    /// </summary>
    /// <param name="playerLat"></param>
    /// <param name="playerLon"></param>
    private void SendRequestToReloadMap(float playerLat, float playerLon)
    {
        if (lastLat != playerLat || lastLon != playerLon)
        {
            lastLat = playerLat;
            lastLon = playerLon;
            StartCoroutine(LoadMap(playerLat, playerLon));
        }
    }

    /// <summary>
    /// 맵 이미지에 대한 정보를 기반으로 지도 이미지를 그리는 url을 생성한 후 위 url로부터 이미지를 가져와 텍스쳐로 적용시킨다
    /// </summary>
    /// <param name="playerLat"></param>
    /// <param name="playerLon"></param>
    /// <returns></returns>
    IEnumerator LoadMap(float playerLat, float playerLon)
    {
        _latitude = playerLat;
        _longitude = playerLon;

        string url = _strBaseURL + "center=" + _centerPos +
                        "&zoom=" + zoom.ToString() + "&size=" + mapWidth.ToString() + "x" + mapHeight.ToString()
                        + "&markers=icon:https://tinyurl.com/3dedamj6|" + _latitude + "," + _longitude + "&map_id=8ebdea23bc8fbdc5" + "&key=" + strAPIKey;

        // url에 웹 요청 후 텍스쳐 받아오기
        url = UnityWebRequest.UnEscapeURL(url);
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);
        yield return req.SendWebRequest();

        // 받은 Texture를 RAW 이미지에 적용
        mapRawImage.texture = DownloadHandlerTexture.GetContent(req);
    }
}