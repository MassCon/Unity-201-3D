using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabirintState : MonoBehaviour
{
    public static float checkPoint1Amount;
    public static bool checkPoint1Passed;
    public static bool cameraFirtsPerson;
    public static bool isDay;
    public static bool isPaused;

    public static float musicVolume = 0.5f;
    public static float effectsVolume = 0.5f;
    public static bool isSoundsMuted;

    public static event Action OnSoundsMuteChanged;
    public static event Action OnMusicVolumeChanged;
    public static event Action OnEffectsVolumeChanged;

    public static void SoundsMuteChanged(bool value)
    {
        isSoundsMuted = value;
        OnSoundsMuteChanged?.Invoke();
    }

    public static void MusicVolumeChanged(float value)
    {
        musicVolume = value;
        OnMusicVolumeChanged?.Invoke();
    }

    public static void EffectsVolumeChanged(float value)
    {
        effectsVolume = value;
        OnEffectsVolumeChanged?.Invoke();
    }
}
