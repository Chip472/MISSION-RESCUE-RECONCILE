using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterDialogueControl : MonoBehaviour
{
    [SerializeField] private GameObject chapterTitle, dialogue1, textbox1;
    [SerializeField] private Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (textbox1.GetComponent<Dialogue1>().end)
        {
            transition.SetBool("fade out", true);
        }
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(1.5f);
        chapterTitle.SetActive(true);

        yield return new WaitForSeconds(3f);
        dialogue1.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        textbox1.SetActive(true);
    }
}
