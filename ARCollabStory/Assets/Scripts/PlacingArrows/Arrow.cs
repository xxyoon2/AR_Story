using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Ȱ��ȭ �Ǵ� ��Ȱ��ȭ �� �Ÿ�
    public float ActiveDistance = 1.0f;
    private GameObject _mainCamera;
    private MeshRenderer _meshRenderer;
    private bool _isActive;
    public GameObject Destination;

    private void Awake()
    {
        _mainCamera = GameObject.Find("AR Camera");
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        gameObject.transform.LookAt(Destination.transform);
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
    private void SetRendererActive()
    {
        double distanceToPlayer = Vector3.Distance(transform.position, _mainCamera.transform.position);

        if (_isActive && distanceToPlayer > ActiveDistance)
        {
            gameObject.SetActive(false);
            return;
        }

        if (!_isActive && distanceToPlayer < ActiveDistance)
        {
            _meshRenderer.enabled = true;
            _isActive = true;
        }
    }
}
