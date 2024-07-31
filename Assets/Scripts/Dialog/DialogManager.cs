using System.Collections;
using System.Collections.Generic;
using TMPro; // If you use TextMeshPro
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText; // Ensure this is assigned in the Inspector

    private Queue<string> dialog;

    void Start()
    {
        dialog = new Queue<string>();
        TriggerInitialDialogue();
    }

    public void StartDialog(Dialogue dialogue)
    {
        dialog.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            dialog.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialog.Count == 0)
        {
          
            return;
        }
        string sentence = dialog.Dequeue();
       
        dialogText.text = sentence;

        StartCoroutine(DisplayNextSentenceAfterDelay(10f)); // Adjust the delay time as needed
    }

    IEnumerator DisplayNextSentenceAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DisplayNextSentence();
    }

   

    //void Update()
    //{
    //    // For testing, start the dialogue automatically if available
    //    // Remove or adjust this part according to your game's requirements
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        TriggerInitialDialogue();
    //    }
    //}

    void TriggerInitialDialogue()
    {
        // Find the DialogTrigger component and start dialogue
        DialogTrigger trigger = FindObjectOfType<DialogTrigger>();
        if (trigger != null)
        {
            trigger.TriggerDialog();
        }
    }
}
