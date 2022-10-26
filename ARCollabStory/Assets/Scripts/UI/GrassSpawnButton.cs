using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawnButton : MonoBehaviour
{
    public AnchorDataManager AnchorDataManager;
    public GrassSpawner GrassSpawner;

    /// <summary>
    /// 테스트용 메서드
    /// 실제로는 버튼을 눌러서 소환되지 않음
    /// </summary>
    public void Click()
    {
        AnchorDataManager.Load("HideAndSeekTest.json");
        GrassSpawner.Create();
    }
}
