using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSrc = GetComponent<AudioSource>();

    }

    private AudioSource audioSrc;

    private float musicVolume = 1f;

    private void FixedUpdate()
    {
        audioSrc.volume = musicVolume;

    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
