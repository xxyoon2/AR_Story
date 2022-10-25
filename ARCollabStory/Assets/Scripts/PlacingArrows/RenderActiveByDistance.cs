using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderActiveByDistance : MonoBehaviour
{
    //Ȱ��ȭ �Ǵ� ��Ȱ��ȭ �� �Ÿ�
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
    /// �÷��̾�� �Ÿ��� ��������� �� ȭ��ǥ�� ���̰� �ϴ� �Լ�
    /// �÷��̾�� �Ÿ��� �־����� �ڽ��� ��Ȱ��ȭ
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
