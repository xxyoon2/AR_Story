using UniRx;
using UniRx.Triggers;
using UniRx.TMPro;
using System;

public sealed class MapPresenter : IPresenter
{
    private MapView _mapView;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

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
            _mapView.Buttons[i].Button.OnClickAsObservable().Subscribe(_ => PopUpUi(_mapView.Buttons[i].StatusInfo)).AddTo(_compositeDisposable);
        }
        Model.MapModel.DestinationStatus.Subscribe(SetDestinationsInfo).AddTo(_compositeDisposable);
    }

    private void PopUpUi(string statusInfo)
    {
        if(statusInfo == "InProgress")
        {

        }
        else
        {

        }
    }

    private void SetDestinationsInfo(bool hi)
    {

    }
}
