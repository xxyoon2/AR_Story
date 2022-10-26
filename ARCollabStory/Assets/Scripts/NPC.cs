using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public void Talk()
    {
        // 여기서 UI로 무언가 띄우면 될 듯
        Debug.Log($"{gameObject} 말한다");
    }
}
