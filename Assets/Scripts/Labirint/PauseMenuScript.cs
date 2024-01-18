using System.Collections;
using System.Collections.Generic;
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
        LabirintState.musicVolume = musicVolumeSlider.value;
        LabirintState.effectsVolume = effectsVolumeSlider.value;
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
        soundMixer.SetFloat("MusicVolume", -80*volume);
    }
    public void OnEffectsVolumeChanged(float volume)
    {
        LabirintState.EffectsVolumeChanged(volume);
    }
    public void OnMuteAllChanged(bool value)
    {
        LabirintState.SoundsMuteChanged(value);
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
}
