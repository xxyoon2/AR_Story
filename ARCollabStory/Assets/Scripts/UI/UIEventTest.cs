using UnityEngine;
using UnityEngine.EventSystems;

enum UIMode
{
    NONE,
    MAIN,
    NAVI,
    MAP,
    BOOK,
    MENU
}

public class UIEventTest : MonoBehaviour
    , IPointerClickHandler
    //, IDragHandler
    //, IPointerEnterHandler
    //, IPointerExitHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Click, {eventData.pointerPress}");
    }
    /*
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"Drag, {eventData}");
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"Enter, {eventData.pointerPress}");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log($"Exit, {eventData.pointerPress}");
    }
    */
}