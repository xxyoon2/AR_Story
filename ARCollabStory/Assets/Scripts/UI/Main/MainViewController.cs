using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainViewController : ViewController
{
    private void Awake()
    {
        View = transform.Find("MainView").GetComponent<MainView>();
        Debug.Assert(View != null);
        Presenter = new MainViewPresenter();
        Debug.Assert(Presenter != null);
    }
}
