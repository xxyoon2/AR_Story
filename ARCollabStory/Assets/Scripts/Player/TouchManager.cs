using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public interface IInput
{
    //public int LayerInfo(string layerName);
    public bool Tab(int layerMask);
    public bool Tab();
    public bool OpenBook();
}

public enum LayerMaskID
{
    OPENBOOK = 128,
}

public class TouchManager : MonoBehaviour, IInput
{
    private Ray ray;
    private RaycastHit hit;
    //private int layerMask;
    //private LayerMaskID layerMask;

    private Touch touch;
    private Vector2 tabPoint = new Vector2();

    public float distance = 5f;

    void Update()
    {
        if (Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Canceled)
        {
            return;
        }

        touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                Tab();
                break;
            case TouchPhase.Moved:
                if (tabPoint.x >= 1050)
                {
                    OpenBook();
                }
                break;
            case TouchPhase.Ended:
                break;
        }
    }

    /*
    /// <summary>
    /// 몇 번째 레이어인지 반환
    /// </summary>
    /// <param name="layerName">레이어 이름</param>
    /// <returns></returns>
    public int LayerInfo(string layerName)
    {
        // 나중에는 메서드가 아니라 class로 사용해야할 애니메이션 미리 연산해두고 쓸 것
        // ex ) 수업때 배웠던 AnimID class 같은
        layerMask = 1 << LayerMask.NameToLayer(layerName);

        return layerMask;
    }
    */

    // 터치해서 만약 오브젝트가 있다면 true, 없다면 false 반환하는 형태로 가야할지
    public bool Tab()
    {
        return Tab(1);
    }

    public bool Tab(int layerMask)
    {
        tabPoint = touch.position;

        ray = Camera.main.ScreenPointToRay(touch.position);
        Debug.Log($"{touch.position}");

        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            hit.transform.GetComponent<Grass>()?.Catch();
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool OpenBook()
    {
        Debug.Log("스와이프");

        return true;
    }
}
