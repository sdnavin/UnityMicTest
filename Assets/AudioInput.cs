﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioInput : MonoBehaviour
{
    void Start()
    {
        audio.Stop();

        audio.loop = true;

        int minFreq, maxFreq;
        Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

        audio.clip = Microphone.Start(null, true, 1, minFreq);

        while (true)
        {
            int delay = Microphone.GetPosition(null);
            if (delay > 0)
            {
                audio.Play();
                Debug.Log("Latency = " + (1000.0f / audio.clip.frequency * delay) + " msec");
                break;
            }
        }
    }
}