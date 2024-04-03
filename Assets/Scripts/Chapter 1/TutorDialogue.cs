using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorDialogue : MonoBehaviour
{
    [SerializeField] private GameObject textbox;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;

    [SerializeField] private AudioSource dialogueSFX;

    [SerializeField] private GameObject player;

    public int index;
    private bool check;

    // Start is called before the first frame update
    void Start()
    {
        check = true;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        StartCoroutine(DialogueSFX());
    }

    IEnumerator TypeLine()
    {
        //type each character one by one
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    IEnumerator DialogueSFX()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            if (textComponent.text != lines[index])
            {
                dialogueSFX.Play();
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            StartCoroutine(DialogueSFX());
        }
        else
        {
            check = false;
            textbox.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
        }
    }
}
