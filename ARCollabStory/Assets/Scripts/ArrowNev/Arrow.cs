using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Arrow prefab이 생성될 때 바라봐야할 오브젝트
    //WebMapLoader 컴포넌트에 있는 Destination 정보를 자동으로 받아옴
    public GameObject Destination;

    private void Start()
    {
        gameObject.transform.LookAt(Destination.transform);
    }
}
