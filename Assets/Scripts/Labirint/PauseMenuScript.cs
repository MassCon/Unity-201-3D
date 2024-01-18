using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider effectsVolumeSlider;
    [SerializeField] private Toggle muteAllToggle;
    [SerializeField] private GameObject content;
    [SerializeField] private AudioMixer soundMixer;

    void Start()
    {
        OnMusicVolumeChanged(musicVolumeSlider.value);
        OnEffectsVolumeChanged(effectsVolumeSlider.value);
        LabirintState.isSoundsMuted = muteAllToggle.isOn;

        if (content.activeInHierarchy)
        {
            ShowMenu();
            LabirintState.isPaused = true;
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (content.activeInHierarchy) HideMenu();
            else ShowMenu();
            LabirintState.isPaused = false;

        }
    }
    public void OnMusicVolumeChanged(float volume)
    {
        LabirintState.MusicVolumeChanged(volume);
        if (!LabirintState.isSoundsMuted)
        {
            float dB = -80f + 90f * volume;
            soundMixer.SetFloat("MusicVolume", dB);
        }
    }
    public void OnEffectsVolumeChanged(float volume)
    {
        LabirintState.EffectsVolumeChanged(volume);
        if (!LabirintState.isSoundsMuted)
        {
            float dB = -80f + 90f * volume;
            soundMixer.SetFloat("EffectsVolume", dB);
        }
    }
    public void OnMuteAllChanged(bool value)
    {
        LabirintState.SoundsMuteChanged(value);
        if (value)
        {
            soundMixer.SetFloat("EffectsVolume", -80f);
            soundMixer.SetFloat("MusicVolume", -80f);
        }
        else
        {
            OnMusicVolumeChanged(LabirintState.effectsVolume);
            OnEffectsVolumeChanged(LabirintState.musicVolume);
        }
    }
    private void ShowMenu()
    {
        content.SetActive(true);
        Time.timeScale = 0f;
    }
    private void HideMenu()
    {
        content.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnMenuButtonClick(int value) {
        Debug.Log(value.ToString());

        switch (value)
        {
            case 1: //exit
                if (Application.isEditor)
                {
                    EditorApplication.ExitPlaymode();
                    //EditorApplication.Exit(0);
                }
                else
                {
                    Application.Quit(0);
                }
                break;
            case 2: //restore
                OnMusicVolumeChanged(0.5f);
                OnEffectsVolumeChanged(0.5f);
                OnMuteAllChanged(false);
                break;
            case 3: //close
                HideMenu();
                break;
            default:
                Debug.LogError($"Undefined button click{value}");
                break;
        }
    }

}
