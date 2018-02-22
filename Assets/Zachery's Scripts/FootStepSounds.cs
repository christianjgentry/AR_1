using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour {

    public AudioClip[] soundClips;
    public AudioSource source;


    public void RightFootPlay()
    {
        source.Stop();
        source.clip = soundClips[0];
        source.Play();
    }

    public void LeftFootPlay()
    {
        source.Stop();
        source.clip = soundClips[1];
        source.Play();
    }
}
