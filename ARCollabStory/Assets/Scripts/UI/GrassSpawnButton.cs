using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawnButton : MonoBehaviour
{
    public AnchorDataManager AnchorDataManager;
    public GrassSpawner GrassSpawner;

    /// <summary>
    /// �׽�Ʈ�� �޼���
    /// �����δ� ��ư�� ������ ��ȯ���� ����
    /// </summary>
    public void Click()
    {
        AnchorDataManager.Load("HideAndSeekTest.json");
        GrassSpawner.Create();
    }
}
