using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//public class PauseMenuScript : MonoBehaviour
//{
//    [SerializeField] private Slider musicVolumeSlider;
//    [SerializeField] private Slider effectsVolumeSlider;
//    [SerializeField] private Toggle muteAllToggle;
//    [SerializeField] private GameObject content;
//    [SerializeField] private AudioMixer soundMixer;

//    void Start()
//    {
//        OnMusicVolumeChanged(musicVolumeSlider.value);
//        OnEffectsVolumeChanged(effectsVolumeSlider.value);
//        LabirintState.isSoundsMuted = muteAllToggle.isOn;

//        if (content.activeInHierarchy)
//        {
//            ShowMenu();
//            LabirintState.isPaused = true;
//        }
//    }
//    void Update()
//    {
//        if (Input.GetKeyUp(KeyCode.Escape))
//        {
//            if (content.activeInHierarchy) HideMenu();
//            else ShowMenu();
//            LabirintState.isPaused = false;

//        }
//    }
//    public void OnMusicVolumeChanged(float volume)
//    {
//        LabirintState.MusicVolumeChanged(volume);
//        if (!LabirintState.isSoundsMuted)
//        {
//            float dB = -80f + 90f * volume;
//            soundMixer.SetFloat("MusicVolume", dB);
//        }
//    }
//    public void OnEffectsVolumeChanged(float volume)
//    {
//        LabirintState.EffectsVolumeChanged(volume);
//        if (!LabirintState.isSoundsMuted)
//        {
//            float dB = -80f + 90f * volume;
//            soundMixer.SetFloat("EffectsVolume", dB);
//        }
//    }
//    public void OnMuteAllChanged(bool value)
//    {
//        LabirintState.SoundsMuteChanged(value);
//        if (value)
//        {
//            soundMixer.SetFloat("EffectsVolume", -80f);
//            soundMixer.SetFloat("MusicVolume", -80f);
//        }
//        else
//        {
//            OnMusicVolumeChanged(LabirintState.effectsVolume);
//            OnEffectsVolumeChanged(LabirintState.musicVolume);
//        }
//    }
//    private void ShowMenu()
//    {
//        content.SetActive(true);
//        Time.timeScale = 0f;
//    }
//    private void HideMenu()
//    {
//        content.SetActive(false);
//        Time.timeScale = 1f;
//    }

//    public void OnMenuButtonClick(int value) {
//        Debug.Log(value.ToString());

//        switch (value)
//        {
//            case 1: //exit
//                if (Application.isEditor)
//                {
//                    EditorApplication.ExitPlaymode();
//                    //EditorApplication.Exit(0);
//                }
//                else
//                {
//                    Application.Quit(0);
//                }
//                break;
//            case 2: //restore
//                OnMusicVolumeChanged(0.5f);
//                OnEffectsVolumeChanged(0.5f);
//                OnMuteAllChanged(false);
//                break;
//            case 3: //close
//                HideMenu();
//                break;
//            default:
//                Debug.LogError($"Undefined button click{value}");
//                break;
//        }
//    }

//}


//public class PauseMenuScript : MonoBehaviour
//{
//    [SerializeField] private Slider musicVolumeSlider;
//    [SerializeField] private Slider effectsVolumeSlider;
//    [SerializeField] private Toggle muteAllToggle;
//    [SerializeField] private GameObject content;

//    [SerializeField] private TMP_Dropdown dropdown;
//    void Start()
//    {
//        string[] names = QualitySettings.names;
//        if (names.Length != dropdown.options.Count)
//        {
//            dropdown.options.Clear();
//            for (int i = 0; i < names.Length; i++)
//            {
//                dropdown.options.Add(new TMP_Dropdown.OptionData(names[i]));
//            }
//            dropdown.value = QualitySettings.GetQualityLevel();
//        }
//        else
//        {
//            OnQualityDropdownChanged(dropdown.value);
//        }


//        LabirintState.musicVolume = musicVolumeSlider.value;
//        LabirintState.effectsVolume = effectsVolumeSlider.value;
//        LabirintState.isSoundsMuted = muteAllToggle.isOn;
//        if (content.activeInHierarchy)
//        {
//            ShowMenu();
//        }
//    }
//    void Update()
//    {
//        if (Input.GetKeyUp(KeyCode.Escape))
//        {
//            if (content.activeInHierarchy) HideMenu();
//            else ShowMenu();
//        }
//    }
//    public void OnMusicVolumeChanged(float volume)
//    {
//        LabirintState.MusicVolumeChanged(volume);
//    }
//    public void OnEffectsVolumeChanged(float volume)
//    {
//        LabirintState.EffectsVolumeChanged(volume);
//    }
//    public void OnMuteAllChanged(bool value)
//    {
//        LabirintState.SoundsMuteChanged(value);
//    }
//    private void ShowMenu()
//    {
//        content.SetActive(true);
//        Time.timeScale = 0f;
//    }
//    private void HideMenu()
//    {
//        content.SetActive(false);
//        Time.timeScale = 1f;
//    }
//    public void OnQualityDropdownChanged(int value)
//    {
//        Debug.Log(value);
//        QualitySettings.SetQualityLevel(value, true);
//    }
//    public void OnMenuButtonClick(int button)
//    {
//        switch (button)
//        {
//            case 1: // Exit
//                if (Application.isEditor)
//                {
//                    EditorApplication.ExitPlaymode();
//                }
//                else
//                {
//                    Application.Quit(0);
//                }
//                break;
//            case 2:
//                musicVolumeSlider.value = 0.5f;
//                effectsVolumeSlider.value = 0.5f;
//                muteAllToggle.isOn = false;
//                OnMusicVolumeChanged(0.5f);
//                OnEffectsVolumeChanged(0.5f);
//                OnMuteAllChanged(false);
//                break;
//            case 3:
//                HideMenu();
//                break;
//        }
//    }
//}

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeSlider;
    [SerializeField]
    private Slider effectsVolumeSlider;
    [SerializeField]
    private Toggle muteAllToggle;
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private AudioMixer soundMixer;

    void Start()
    {
        OnMusicVolumeChanged(musicVolumeSlider.value);
        OnEffectsVolumeChanged(effectsVolumeSlider.value);
        LabirintState.isSoundsMuted = muteAllToggle.isOn;
        if (content.activeInHierarchy)
        {
            ShowMenu();
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (content.activeInHierarchy)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }
    private void ShowMenu()
    {
        content.SetActive(true);
        Time.timeScale = 0f;
        LabirintState.isPaused = true;
    }
    private void HideMenu()
    {
        content.SetActive(false);
        Time.timeScale = 1.0f;
        LabirintState.isPaused = false;
    }

    public void OnMusicVolumeChanged(float volume)
    {
        LabirintState.musicVolume = volume;
        if (!LabirintState.isSoundsMuted)
        {
            // volume [0..1], dB [-80..+10]
            float dB = -80f + 90f * volume;
            soundMixer.SetFloat("MusicVolume", dB);
        }
    }
    public void OnEffectsVolumeChanged(float volume)
    {
        LabirintState.effectsVolume = volume;
        if (!LabirintState.isSoundsMuted)
        {
            float dB = -80f + 90f * volume;
            soundMixer.SetFloat("EffectsVolume", dB);
        }
    }
    public void OnMuteAllChanged(bool value)
    {
        LabirintState.isSoundsMuted = value;
        if (value)
        {
            soundMixer.SetFloat("EffectsVolume", -80f);
            soundMixer.SetFloat("MusicVolume", -80f);
        }
        else
        {
            OnEffectsVolumeChanged(LabirintState.effectsVolume);
            OnMusicVolumeChanged(LabirintState.musicVolume);
        }
    }
    public void OnMenuButtonClick(int value)
    {
        // Debug.Log(value.ToString());
        switch (value)
        {
            case 1:  // Exit
                if (Application.isEditor)
                {
                    EditorApplication.ExitPlaymode();  // Çóïèíÿº ãðó
                    // EditorApplication.Exit(0);  // Çàêðèâàº ðàçîì ç Unity
                }
                else
                {
                    Application.Quit(0);
                }
                break;
            case 2:  // Defaults
                OnMusicVolumeChanged(0.5f);
                OnEffectsVolumeChanged(0.5f);
                OnMuteAllChanged(false);
                break;
            case 3:  // Close
                HideMenu();
                break;
            default:
                Debug.LogError($"Undefined button click detected: value '{value}'");
                break;
        }
    }
}