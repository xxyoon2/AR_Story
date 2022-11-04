using UniRx;
/// <summary>
/// 비즈니스 로직을 정의할 Presenter
/// </summary>
public abstract class Presenter
{
    internal CompositeDisposable CompositeDisposable { get; private set; } = new CompositeDisposable();

    /// <summary>
    /// View와 Presenter의 참조를 연결하고, View에 기본값을 할당합니다.
    /// 반드시 함수 종료 전 InitializeRx()를 호출해주세요.
    /// </summary>
    /// <param name="view">연결할 View</param>
    public abstract void OnInitialize(View view);

    /// <summary>
    /// ViewController가 파괴될 때 호출됩니다. 자원 정리 용도로 사용합니다.
    /// </summary>
    public virtual void OnRelease()
    {

    }
    
    protected void InitializeRx()
    {
        OnOccuredUserEvent();
        OnUpdatedModel();
    }

    /// <summary>
    /// View에 유저 이벤트가 발생했을 때 동작합니다.
    /// 보통 Model을 업데이트합니다.
    /// </summary>
    
    protected abstract void OnOccuredUserEvent();
    
    /// <summary>
    /// Model이 업데이트 되었을 때 동작합니다.
    /// 보통 View를 업데이트합니다.
    /// </summary>
    protected abstract void OnUpdatedModel();
}