using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public void Catch()
    {
        Debug.Log("��Ҵ�!");
        GetComponentInParent<GrassSpawner>().CatchGrass();
        gameObject.SetActive(false);
    }
}
