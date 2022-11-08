using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainViewPresenter : Presenter
{
    private MainView _mainView;
    public override void OnInitialize(View view)
    {
        _mainView = view as MainView;
        InitializeRx();
    }

    protected override void OnOccuredUserEvent()
    {
        _mainView.MenuButton.OnClickAsObservable().Subscribe().AddTo(CompositeDisposable);
        _mainView.NoteButton.OnClickAsObservable().Subscribe(_ => ChangeView(GameManager.ViewMode.NOTE)).AddTo(CompositeDisposable);
        _mainView.MapButton.OnClickAsObservable().Subscribe(_ => ChangeView(GameManager.ViewMode.MAP)).AddTo(CompositeDisposable);
    }

    protected override void OnUpdatedModel()
    {
        
    }

    private void ChangeView(GameManager.ViewMode mode)
    {
        GameManager.Instance.SetViewMode(mode);
    }
}
