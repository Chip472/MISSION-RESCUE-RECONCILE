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

        if (player.heartsNum == 2) //lấy heartsNum từ script PlayerController của Blitz để so sánh
        {
            hearts[2].SetActive(false); //nếu bằng 2 (mất 1 mạng) thì tắt tim thứ 3 đi
        }
        else if (player.heartsNum == 1)
        {
            hearts[1].SetActive(false);
        }
        else if (player.heartsNum == 0)
        {
            hearts[0].SetActive(false); //mạng bằng 0 thì tắt tim cuối cùng
            loseScene.SetActive(true); //hiển thị màn hình thua cuộc
            player.enabled = false; //khóa player lại cho người chơi không di chuyển được nữa
            enemyParent.transform.GetComponentInChildren<EnemyController>().enabled = false; //khóa quái lại cho quái không di chuyển nữa
        }

        if (enemyParent.transform.childCount == 0) //check xem trong phụ huynh "enemies" có còn con không, nếu không thì ng chơi thắng
        {
            winScene.SetActive(true); //hiển thị màn hình thắng
            player.enabled = false; //khóa player lại cho người chơi không di chuyển được nữa
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
