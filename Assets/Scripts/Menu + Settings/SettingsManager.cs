using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private TMP_Dropdown resoDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    private bool isFullScreen;

    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        //Get available resolutions and add them to my dropdown
        resolutions = Screen.resolutions;
        resoDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResoIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResoIndex = i;
            }
        }

        resoDropdown.AddOptions(options);
        resoDropdown.value = currentResoIndex;
        resoDropdown.RefreshShownValue();

        // sự kiện khi giá trị của Dropdown thay đổi
        resoDropdown.onValueChanged.AddListener(delegate {
            SetResolution(resoDropdown.value);
        });

        // Lấy giá trị được lưu từ PlayerPrefs
        int selectedIndex = PlayerPrefs.GetInt("indexScreenSize", 0); // Giá trị mặc định là 0 nếu không có giá trị được lưu trước đó

        // Thiết lập giá trị này cho Dropdown
        resoDropdown.value = selectedIndex;

        //Setup my volume mixer
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
            SetMasterVolume();
        }

        // Set Screen Size
        if (PlayerPrefs.HasKey("fullScreen"))
        {
            fullScreenToggle.isOn = (PlayerPrefs.GetInt("fullScreen") == 0) ? false : true; 
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");

        SetMusicVolume();
        SetSFXVolume();
        SetMasterVolume();
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = fullScreenToggle.isOn;
        this.isFullScreen = fullScreenToggle.isOn;

        PlayerPrefs.SetInt("fullScreen", (fullScreenToggle.isOn == false) ? 0 : 1);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen);

        PlayerPrefs.SetInt("indexScreenSize", resolutionIndex);
    }
}
