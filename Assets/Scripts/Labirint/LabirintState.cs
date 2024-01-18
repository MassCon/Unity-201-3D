using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LabirintState : MonoBehaviour
{

    private static List<Action<String>> observers = new();
    public static void AddNotifyListener(Action<String> listener)
    {
        observers.Add(listener);
    }
    private static void NotifyListeners([CallerMemberName] String propertyName = "")
    {
        foreach (var listener in observers)
        {
            listener.Invoke(propertyName);
        }
    }


    public static float checkPoint1Amount;
    public static bool checkPoint1Passed;
    public static bool cameraFirtsPerson;
    public static bool isDay;
    public static bool isPaused;

    public static float _musicVolume = 0.5f;
    public static float effectsVolume = 0.5f;
    public static bool isSoundsMuted;

    public static float musicVolume
    {
        get { return _musicVolume; }
        set { _musicVolume = value; NotifyListeners(); }
    }

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
