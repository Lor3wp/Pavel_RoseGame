﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    private AudioSource audioSrc;

    private float musicVolume = 1f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

    }
    private void FixedUpdate()
    {
        audioSrc.volume = musicVolume;

    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
