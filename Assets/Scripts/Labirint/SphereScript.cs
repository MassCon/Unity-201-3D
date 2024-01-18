using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    //[SerializeField]
    private Rigidbody body;
    private float forceFactor = 500f;
    private Vector3 anchorOffset;

    //[SerializeField]  //solar 
    private GameObject _camera;

    [SerializeField] private GameObject cameraAnchor;


    // [SerializeField]
    private AudioSource backgroundMusic;
    //[SerializeField]
    private AudioSource collectSound;

    private static SphereScript instance = null; //solar

    private void Start()
    {
        //---------------------------------------solar system
        if (instance != null)
        {
            
            this.transform.position +=
                new Vector3(0, instance.transform.position.y, 0);

            GameObject.Destroy(instance.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        _camera = Camera.main.gameObject;
        Debug.Log("SphereScript::Start");
        //-------------------------------------


        body = GetComponent<Rigidbody>();
        anchorOffset = this.transform.position - cameraAnchor.transform.position;

        AudioSource[] audioSources = GetComponents<AudioSource>();
        collectSound = audioSources[0];
        backgroundMusic = audioSources[1];

        if (!LabirintState.isSoundsMuted)
        {
            //backgroundMusic.volume = LabirintState.musicVolume;
            backgroundMusic.Play();
        }
        LabirintState.OnSoundsMuteChanged += SoundsMuteChanged;
        LabirintState.OnMusicVolumeChanged += MusicVolumeChanged;
        LabirintState.OnEffectsVolumeChanged += EffectsVolumeChanged;

        LabirintState.AddNotifyListener(OnLabirintStateChanged);
    }

    private void Update()
    {
        float kh = Input.GetAxis("Horizontal");
        float kv = Input.GetAxis("Vertical");
        //Vector3 forceDirection = new Vector3(kh, 0, kv);
        //body.AddForce(forceFactor * Time.deltaTime * forceDirection);

        //Debug.Log($"{kh} {kv}");

        Vector3 right = _camera.transform.right;
        Vector3 forward = _camera.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 forceDirection = // new Vector3(kh, 0, kv);
            kh * right + kv * forward;

        //Debug.Log(forceFactor * Time.deltaTime * forceDirection);

        body.AddForce(forceFactor * Time.deltaTime * forceDirection.normalized);
        cameraAnchor.transform.position = this.transform.position - anchorOffset;

        //if (backgroundMusic.volume != LabirintState.musicVolume)
        //{
        //    //backgroundMusic.volume = LabirintState.musicVolume;
        //}


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            if (!LabirintState.isSoundsMuted)
            {
                // collectSound.volume = LabirinthState.effectsVolume;
                collectSound.Play();
            }
        }
    }

    private void OnLabirintStateChanged(string propertyName)
    {
        //Debug.Log("OnLabirintStateChanged:" + propertyName);
    }

    public void SoundsMuteChanged()
    {
        backgroundMusic.mute = LabirintState.isSoundsMuted;
    }

    public void MusicVolumeChanged()
    {
        backgroundMusic.volume = LabirintState.musicVolume;
    }

    public void EffectsVolumeChanged()
    {
        collectSound.volume = LabirintState.effectsVolume;
    }

    private void OnDestroy()
    {
        LabirintState.RemoveNotifyListener(OnLabirintStateChanged);
    }
}
