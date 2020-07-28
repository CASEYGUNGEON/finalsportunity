using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTextController : MonoBehaviour
{
    public Text mesh;
    public string targetString;
    private int length;

    public void SetTarget(string s)
    {
        targetString = s;
        mesh.text = "";
        length = 0;
    }

    public void Clear()
    {
        targetString = "";
        mesh.text = "";
        length = 0;
    }

    public void FastFwd()
    {
        mesh.text = targetString;
        length = targetString.Length;
    }

    public bool IsDoneTyping()
    {
        if (string.Compare(mesh.text,targetString) == 0)
            return true;
        return false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (string.Compare(mesh.text,targetString) < 0)
        {
            length++;
            mesh.text = targetString.Substring(0, length);
        }

    }
}