using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Arrow prefab�� ������ �� �ٶ������ ������Ʈ
    //WebMapLoader ������Ʈ�� �ִ� Destination ������ �ڵ����� �޾ƿ�
    public GameObject Destination;

    private void Start()
    {
        gameObject.transform.LookAt(Destination.transform);
    }
}
