using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Google.XR.ARCoreExtensions;

public class PlacingObjectSpawner : MonoBehaviour
{
    public AnchorDataManager AnchorDataManager;
    public GameObject Prefab;

    private ARAnchorManager ARAnchorManager;
    private GameObject[] _prefabs;

    private void Awake()
    {
        ARAnchorManager = GetComponent<ARAnchorManager>();
    }

    public void Create()
    {
        AnchorDataManager.Load("DestinationAnchorDB​.json");

        int CountAnchors = AnchorDataManager.CountAnchorData();
        _prefabs = new GameObject[CountAnchors]; 

        for(int i = 0; i < CountAnchors; i++)
        {
            string anchorID = AnchorDataManager.GetAnchorID(i);
            ARCloudAnchor arCloudAnchor = ARAnchorManager.ResolveCloudAnchorId(anchorID);

            _prefabs[i] = Instantiate(Prefab, arCloudAnchor.transform);
            _prefabs[i].GetComponent<PlacingObjectBehaviour>().ObjectNum = i;
        }
    }
}