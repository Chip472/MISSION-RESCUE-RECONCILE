using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuESC : MonoBehaviour
{

    [SerializeField] private GameObject menuEsc;
    [SerializeField] private GameObject options, gallery;
    bool checkMenu;

    private void Update()
    {
        if (!checkMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuEsc.SetActive(true);
                checkMenu = true;
                Time.timeScale = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuEsc.SetActive(false);
                Time.timeScale = 1;
                checkMenu = false;
            }
        }
    }

    public void BackToGame()
    {
        menuEsc.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options()
    {
        options.SetActive(true);
    }

    public void OptionsBack()
    {
        options.SetActive(false);
    }

    public void Gallery()
    {
        gallery.SetActive(true);
    }

    public void GalleryBack()
    {
        gallery.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        PlayerPrefs.SetString("play", "already");
    }

    private void OnApplicationQuit()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetString("play", "quit");
        //set playerpref to quit so it turns the disclaimer on when go back into game
    }
}
