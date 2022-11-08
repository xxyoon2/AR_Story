using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : View
{
    public Button MenuButton { get; private set; }
    public Button NoteButton { get; private set; }
    public Button MapButton { get; private set; }

    private void Awake()
    {
        MenuButton = transform.Find("MenuButton").GetComponent<Button>();
        Debug.Assert(MenuButton != null);
        NoteButton = transform.Find("NoteButton").GetComponent<Button>();
        Debug.Assert(NoteButton != null);
        MapButton = transform.Find("MapButton").GetComponent<Button>();
        Debug.Assert(MapButton != null);
    }
}
