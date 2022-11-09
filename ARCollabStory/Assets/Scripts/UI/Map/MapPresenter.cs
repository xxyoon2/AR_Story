using UniRx;
using UniRx.Triggers;
using UniRx.TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public sealed class MapPresenter : IPresenter
{
    private MapView _mapView;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();
    
    private int _currentDestination = 0;
    
    public void OnInitialize(IView view)
    {
        _mapView = view as MapView;
        InitializeRx();
    }

    public void OnRelease()
    {
        _mapView = default;
        _compositeDisposable.Dispose();
    }

    private void InitializeRx()
    {
        Model.MapModel.Destinations = CSVParser.GetLocationInfos();

        for (int i = 0; i < _mapView.Buttons.Length; i++)
        {
            int index = i;
            _mapView.Buttons[i].OnClickAsObservable().Subscribe(_ => SendButtonInfo(index)).AddTo(_compositeDisposable);
            ChangeButtonColor(index);
        }
        
        SetCurrentDestination(_currentDestination);
    }

    private void ChangeButtonColor(int index)
    {
        string status = Model.MapModel.Destinations[index + 1].MissionStatus;
        switch(status)
        {
            case "NotStarted":
                _mapView.Buttons[index].GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                break;
            case "InProgress":
                _mapView.Buttons[index].GetComponent<Image>().color = new Color(0, 0, 1, 0.7f);
                break;
            case "Done":
                _mapView.Buttons[index].GetComponent<Image>().color = new Color(1, 0, 0, 0.5f);
                break;
        }
    }

    private void SetCurrentDestination(int index)
    {
        Model.MapModel.Destinations[index + 1].MissionStatus = "InProgress";
        ChangeButtonColor(index);
    }

    private void SetButtonStatusDone(int index)
    {
        Model.MapModel.Destinations[index + 1].MissionStatus = "Done";

        if(Model.MapModel.Destinations[index + 1].DirectionIndex % 2 == 0)
        {
            // NPC와 대화를 나눠 Done이 된 목적지 인덱스가 짝수일 시 퀘스트 범위 활성화
        }
        else
        {
            currentDestination++;
            SetCurrentDestination(_currentDestination);
        }
    }

    private void SendButtonInfo(int buttonIndex)
    {
        string status = Model.MapModel.Destinations[buttonIndex + 1].MissionStatus;

        if(status == "InProgress")
        {
            Model.MapModel.SetPopUpUIText(true);
            Debug.Log("진행중");
        }
        else
        {
            Model.MapModel.SetPopUpUIText(false);
        }
    }
}
