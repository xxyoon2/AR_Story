using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public void Catch()
    {
        GetComponentInParent<QuestObjectSpawner>().CatchQuestObject();
        gameObject.SetActive(false);
    }
}
