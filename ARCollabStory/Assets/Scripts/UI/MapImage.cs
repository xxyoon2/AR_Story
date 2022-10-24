using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MapImage : MonoBehaviour
{
    public RawImage mapRawImage;

    // ����� ���� ������ ���� ���� ���
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
    /// �÷��̾��� ����/�浵 ������ �ٲ� �� �� ��ġ ������ ������� �� �̹����� �ٽ� ��û�Ѵ�
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
    /// �� �̹����� ���� ������ ������� ���� �̹����� �׸��� url�� ������ �� �� url�κ��� �̹����� ������ �ؽ��ķ� �����Ų��
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

        // url�� �� ��û �� �ؽ��� �޾ƿ���
        url = UnityWebRequest.UnEscapeURL(url);
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);
        yield return req.SendWebRequest();

        // ���� Texture�� RAW �̹����� ����
        mapRawImage.texture = DownloadHandlerTexture.GetContent(req);
    }
}