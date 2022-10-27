using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public GameObject ActiveObject;

    public void Click()
    {
        ActiveObject.SetActive(true);
    }
}
