using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFragment : MonoBehaviour
{
    private int _num;
    public int Num
    {
        get { return _num;}
        set { _num = value;}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            Debug.Log($"{Num}��° {gameObject.name}�� ��Ҵ�.");
        }
    }

}
