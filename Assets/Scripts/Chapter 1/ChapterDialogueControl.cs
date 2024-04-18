using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterDialogueControl : MonoBehaviour
{
    [SerializeField] private GameObject chapter1;
    [SerializeField] private GameObject chapterTitle, dialogue1, textbox1;
    [SerializeField] private Animator transition;

    [SerializeField] private GameObject combatUI;

    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject enemyParent;

    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject winScene, loseScene;

    bool check;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (textbox1.GetComponent<Dialogue1>().end && !check)
        {
            transition.SetBool("fade out", true);
            StartCoroutine(DelayEndCutscene());
        }

        if (player.heartsNum == 2)
        {
            hearts[2].SetActive(false);
        }
        else if (player.heartsNum == 1)
        {
            hearts[1].SetActive(false);
        }
        else if (player.heartsNum == 0)
        {
            hearts[0].SetActive(false);
            loseScene.SetActive(true);
            player.enabled = false;
            enemyParent.transform.GetComponentInChildren<EnemyController>().enabled = false;
        }

        if (enemyParent.transform.childCount == 0)
        {
            winScene.SetActive(true);
            player.enabled = false;
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

    IEnumerator DelayEndCutscene()
    {
        yield return new WaitForSeconds(2f);
        chapter1.SetActive(false);
        dialogue1.SetActive(false);
        transition.SetBool("fade out", false);

        combatUI.SetActive(true);

        check = true;
    }

    public void ResetChap1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
