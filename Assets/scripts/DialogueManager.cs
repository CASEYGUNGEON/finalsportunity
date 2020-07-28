using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private DialogueController dialogue;
    public DialogueController dialoguePrefab;
    public static DialogueManager manager;
    public Canvas canvas;

    public static DialogueController Talk()
    {
        playerController.Freeze();
        manager.dialogue = Instantiate(manager.dialoguePrefab);
        manager.dialogue.transform.SetParent(manager.canvas.transform, false);
        return manager.dialogue;
    }

    public static void Untalk()
    {   //auto called by dia. box when it's done
        playerController.Unfreeze();
    }

    // Start is called before the first frame update
    void Awake()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
