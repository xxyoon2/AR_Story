using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderActiveByDistance : MonoBehaviour
{
    //활성화 또는 비활성화 할 거리
    public float ActiveDistance = 0.1f;
    private GameObject _mainCamera;
    private MeshRenderer _meshRenderer;
    private bool _isWalkingDestination;
    private bool _isActive;

    private void Awake()
    {
        _mainCamera = GameObject.Find("AR Camera");
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _isActive = false;
        _meshRenderer.enabled = false;
    }

    private void Update()
    {
        SetRendererActive();
    }

    /// <summary>
    /// 플레이어와 거리가 가까워졌을 때 화살표가 보이게 하는 함수
    /// 플레이어와 거리가 멀어지면 자신을 비활성화
    /// </summary>
    public void SetRendererActive()
    {
        double distanceToPlayer = Vector3.Distance(transform.position, _mainCamera.transform.position);

        if (!_isActive && distanceToPlayer < ActiveDistance)
        {
            _meshRenderer.enabled = true;
            _isActive = true;
        }
        
        if (_isActive && distanceToPlayer > ActiveDistance)
        {
            gameObject.SetActive(false);
        }
    }
}
