using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue1 : MonoBehaviour
{
    [SerializeField] private GameObject textbox;
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;

    [SerializeField] private AudioSource dialogueSFX;

    [SerializeField] private GameObject nameText;
    [SerializeField] private GameObject[] scene;

    [SerializeField] private Animator screenshake;

    public bool end = false;

    public int index;
    private bool check;

    // Start is called before the first frame update
    void Start()
    {
        nameText.SetActive(false);
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
        if (index == 2)
        {
            nameText.SetActive(true);
            scene[0].SetActive(true);
        } 
        else if (index == 4)
        {
            screenshake.Play("ScreenShake", 0);//screen shake
            nameText.GetComponent<TMP_Text>().text = "BLITZO";
        }
        else if (index == 5)
        {
            nameText.GetComponent<TMP_Text>().text = "STOLAS";
        }
        else if (index == 6)
        {
            nameText.GetComponent<TMP_Text>().text = "BLITZO";
        }
        else if (index == 7)
        {
            scene[1].SetActive(true);
        }
        else if (index == 8)
        {
            nameText.SetActive(false);
            nameText.GetComponent<TMP_Text>().text = "STOLAS";
        }
        else if (index == 9)
        {
            scene[2].SetActive(true);
        }
        else if (index == 10)
        {
            nameText.SetActive(true);
            scene[3].SetActive(true);
        }
        else if (index == 11)
        {
            scene[4].SetActive(true);
        }



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
            end = true;
            textbox.SetActive(false);
        }
    }
}
