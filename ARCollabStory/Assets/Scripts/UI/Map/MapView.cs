using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class LocationUI
{
    public Button Button { get; set; }
    public string StatusInfo { get; set; }
}


public class MapView : MonoBehaviour, IView
{
    #region button&image properties
    public LocationUI[] Buttons { get; private set; }
    public Image Area1Image { get; private set; }
    public Image Area2Image { get; private set; }
    public Image Area3Image { get; private set; }
    #endregion

    private void Awake()
    {
        Buttons = new LocationUI[transform.childCount];
        for (int i = 0; i < Buttons.Length; i++)
        {
            string ButtonIndex = "Location" + (i + 1);
            Debug.Log($"{ButtonIndex}");
            Buttons[i].Button = transform.Find(ButtonIndex).GetComponent<Button>();
            Buttons[i].StatusInfo = ButtonIndex;
            Debug.Assert(Buttons[i] != null);
        }

        Area1Image = transform.Find("Area1").GetComponent<Image>();
        Debug.Assert(Area1Image != null);
        Area2Image = transform.Find("Area2").GetComponent<Image>();
        Debug.Assert(Area2Image != null);
        Area3Image = transform.Find("Area3").GetComponent<Image>();
        Debug.Assert(Area3Image != null);
    }
}