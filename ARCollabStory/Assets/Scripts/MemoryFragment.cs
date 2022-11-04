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
    private bool _isStart = false;
    private Vector3 _minScale = new Vector3(0.001f, 0.001f, 0.001f);
    private float _speed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MainCamera")
        {
            if(_isStart)
            {
                Debug.Log($"{Num}번째 {gameObject.name}과 닿았다.");
                transform.GetChild(0).gameObject.SetActive(false);
                Debug.Log($"기억 파편이 현재 {transform.GetChild(0).gameObject.activeSelf} 상태임");

            }
            _isStart = true;
        }
    }

}
