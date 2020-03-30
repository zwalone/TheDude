using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;
    public static DialogueManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DialogueManager>();
            }

            return _instance;
        }
    }

    public Text nameText;
    public Text dialogueText;

    public List<GameObject> ElementsOfUI;

    public GameObject nextButtom;
    public GameObject choices;

    public Animator animator;
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialogue(Dialogue dialogue)
    {
        foreach (GameObject obj in ElementsOfUI) obj.SetActive(false);

        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DislayNextSentence();

    }

    public void DislayNextSentence()
    {
        if (sentences.Count == 0)
        {
            nextButtom.SetActive(false);
            choices.SetActive(true);
            return;
        }

        dialogueText.text = sentences.Dequeue();

    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        foreach (GameObject obj in ElementsOfUI) obj.SetActive(true);
    } 

}
