using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TextMeshProUGUI _ui;
    private int _dialogueIndex = 0;
    private List<DialogueRecord> _records;
    
    void Awake()
    {
        _records = CSVParser.GetDialogueInfos();
        _ui = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClick()
    {
        DialoguePrint();
    }

    // 순서에 맞게 대화창 출력
    void DialoguePrint()
    {
        _dialogueIndex++;
        if (_dialogueIndex >= _records.Count)
        {
            gameObject.SetActive(false);
            return;
        }
        _ui.text = $"{_records[_dialogueIndex].Dialogue}";
    }
}
