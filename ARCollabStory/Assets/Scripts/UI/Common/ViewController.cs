using UnityEngine;

///<summary>
/// 화면의 가장 기본이 되는 클래스입니다.
///</summary>
[RequireComponent(typeof(Canvas))]
public class ViewController : MonoBehaviour
{
    protected View View { get; set; }
    protected Presenter Presenter { get; set; }

    protected void Start()
    {
        Presenter.OnInitialize(View);
    }

    protected void OnDestroy()
    {
        View = default;
        Presenter.CompositeDisposable.Dispose();

        Presenter.OnRelease();
    }

}