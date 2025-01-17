﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;   //name , dialogue
    public Text DialogueText;

    private Queue<string> sentences;



    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear(); 

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); // Dialog Enqueue
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count ==0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); // Dialog Dequeue and next sentence
        Debug.Log(sentence);
        DialogueText.text = sentence;
    }


    void EndDialogue()
    {
        Debug.Log("End of conversation."); 
    }
}
