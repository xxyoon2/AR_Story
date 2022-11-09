using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapViewController : ViewController
{
    private MapView _mapView;
    private MapPresenter _mapPresenter = new MapPresenter();
    
    private void Awake()
    {
        _mapView = transform.Find("MapView").GetComponent<MapView>();
        Debug.Assert(_mapView != null);
    }

    private void Start()
    {
        _mapPresenter.OnInitialize(_mapView);
    }

    private void OnDestroy()
    {
        _mapPresenter.OnRelease();
    }
}
