using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public QuestObjectSpawner QuestObjectSpawner;

    public void Click()
    {
        QuestObjectSpawner.Create();
    }
}
