public interface IPresenter
{
    void OnInitialize(IView view);
    void OnRelease();
}