using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    private List<string> stringTable;
    private int currentString;
    public DialogueTextController text;

    public void AddString(string s)
    {
        stringTable.Add(s);
        if (stringTable.Count == 1)
            text.SetTarget(s);
    }

    public void Clear()
    {
        stringTable = null;
        currentString = 0;
        text.Clear();
    }

    void Awake()
    {
        stringTable = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (!text.IsDoneTyping())
            {
                text.FastFwd();
            }
            else
            {
                if (stringTable.Count > currentString + 1)
                {
                    currentString++;
                    text.SetTarget(stringTable[currentString]);
                }
                else
                {
                    DialogueManager.Untalk();
                    Destroy(this.gameObject);
                }
            }
        }
    }
}