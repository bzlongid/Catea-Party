using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text introText;
    public Queue<string> sentences;
    public GameObject directions;
    public AudioSource buttonPress;
    public Animator animator;

    public void Start()
    {
        sentences = new Queue<string>();
        StartIntro();
        directions.SetActive(false);
    }

    public void StartIntro()
    {
        animator.SetBool("isIn", false);
        sentences.Enqueue("Huh… where am I?");
        sentences.Enqueue("I thought I was sleeping… but this doesn’t look like my room at all.");
        sentences.Enqueue("I should take a look around.");
        sentences.Enqueue("Hey, who is that? Or what is that? It looks like an animal?");
        sentences.Enqueue("It doesn’t look dangerous… maybe I’ll go talk to it.");

        DisplayNextLine();

    }

    public void DisplayNextLine()
    {
        if (sentences.Count == 0)
        {
            EndIntro();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //So that the text displays one letter at a time:
    IEnumerator TypeSentence(string sentence)
    {
        introText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            introText.text += letter;
            yield return null;
        }
    }

    public void EndIntro()
    {
        animator.SetBool("isIn", true);
        gameObject.SetActive(false);
        directions.SetActive(true);
    }

    public void PlaySound()
    {
        buttonPress.Play();
    }
}
