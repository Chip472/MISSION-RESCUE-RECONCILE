using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterControl : MonoBehaviour
{
    [SerializeField] private Animator chapterAnim;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftButton()
    {
        if(count == 0)
        {
            count++;
            chapterAnim.Play("1To2", 0);
        }
        else if (count == 1)
        {
            count++;
            chapterAnim.Play("2To3", 0);
        }

        Debug.Log(count);
    }

    public void RightButton()
    {
        if (count == 1)
        {
            count--;
            chapterAnim.Play("2To1", 0);
        }
        else if (count == 2)
        {
            count--;
            chapterAnim.Play("3To2", 0);
        }

        Debug.Log(count);
    }

    public void ChapterSelect(int scene)
    {
        StartCoroutine(TransiDelay(scene));
    }

    IEnumerator TransiDelay(int scene)
    {
        chapterAnim.Play("End", 0);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetString("play", "already");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("play", "quit");
        //set playerpref to quit so it turns the disclaimer on when go back into game
    }
}
