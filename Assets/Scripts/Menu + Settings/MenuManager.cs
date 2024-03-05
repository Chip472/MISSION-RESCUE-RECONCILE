using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator menuAnim;
    [SerializeField] GameObject stopTimeline, menuActivate, menuObj;
    [SerializeField] GameObject disclaimer;

    [SerializeField] GameObject loadScene;
    [SerializeField] RectTransform loadingBar;
    [SerializeField] TMP_Text loadText;

    [SerializeField] GameObject exitWarning;
    [SerializeField] GameObject menuTheme;
    [SerializeField] AudioSource buttonSFX;

    [SerializeField] RectTransform blitzHand, blitzHand2;

    [SerializeField] ButtonSettingsHover backButton;

    bool checkHandLoad = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTimeline.activeSelf)
        {
            disclaimer.SetActive(false);
        }

        if (menuActivate.activeSelf)
        {
            menuObj.SetActive(true);
            menuTheme.SetActive(true);
        }

        if (checkHandLoad)
        {
            blitzHand.GetComponent<RectTransform>().anchoredPosition += new Vector2(blitzHand.GetComponent<RectTransform>().anchoredPosition.x + 20, blitzHand.GetComponent<RectTransform>().anchoredPosition.y + 20);
            Debug.Log(blitzHand.position);
        }
    }

    public void NewGame()
    {
        //menuAnim.SetBool("fade out", true);
        buttonSFX.Play();
    }

    public void LoadScene(int sceneID)
    {
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {
        loadScene.SetActive(true);
        checkHandLoad = true;
        yield return new WaitForSeconds(2f);

        //AsyncOperation op = SceneManager.LoadSceneAsync(sceneID);
        //float progress = op.progress;
        //Debug.Log(progress);

        //while (!op.isDone)
        //{
        //    if (progress < 0.5f)
        //    {
        //        //blitzHand.localPosition = Vector2.MoveTowards(blitzHand.localPosition, new Vector2(782, 643), op.progress * 100 * Time.deltaTime);
        //        //Debug.Log(blitzHand.localPosition);

        //        for (int i = 1; i <= 10; i++)
        //        {
        //            loadingBar.localScale = new Vector2(i / 10, 1);
        //            loadText.text = (i * 10) + "%";
        //            Debug.Log(op.progress);
        //        }
        //        yield return null;
        //    }
        //    else
        //    {
        //        loadText.text = (op.progress * 100 + 10) + "%";
        //        float progressValue = Mathf.Clamp01(op.progress / 0.9f);
        //        loadingBar.localScale = new Vector2(progressValue, 1);
        //        //blitzHand.localPosition = Vector2.MoveTowards(blitzHand.localPosition, new Vector2(782, 643), op.progress * 100 * Time.deltaTime);
        //        //Debug.Log(blitzHand.localPosition);
        //        Debug.Log(op.progress);

        //        yield return null;
        //    }

        //    Debug.Log(blitzHand.position);
        //}

    }

    public void Settings()
    {
        backButton.check = false;
        menuAnim.SetBool("fade to settings", true);
        buttonSFX.Play();
    }

    public void CloseSettings()
    {
        backButton.check = true;
        menuAnim.SetBool("fade to settings", false);
        buttonSFX.Play();
    }

    public void ExitGame()
    {
        buttonSFX.Play();
        exitWarning.SetActive(true);
    }

    public void ExitNo()
    {
        buttonSFX.Play();
        exitWarning.GetComponent<Animator>().SetBool("close", true);
    }
    public void ExitYes()
    {
        Application.Quit();
    }
}