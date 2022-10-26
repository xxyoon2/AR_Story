using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public void Catch()
    {
        Debug.Log("¿‚æ“¥Ÿ!");
        GetComponentInParent<GrassSpawner>().CatchGrass();
        gameObject.SetActive(false);
    }
}
