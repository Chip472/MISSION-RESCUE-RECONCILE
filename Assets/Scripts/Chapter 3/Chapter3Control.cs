using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chapter3Control : MonoBehaviour
{
    [SerializeField] private GameObject chapterTitle, chapter;

    [SerializeField] private GameObject combatUI;

    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject enemyParent;

    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject winScene, loseScene;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayStart());
    }

    // Update is called once per frame
    void Update()
    {

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
        yield return new WaitForSeconds(1f);
        chapterTitle.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        combatUI.SetActive(true);
        chapterTitle.SetActive(false);
        chapter.SetActive(false);
    }

    public void ResetChap3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
