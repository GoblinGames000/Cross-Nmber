using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : Singletion<SoundManager>
{
    public AudioSource Background;
    public AudioSource Effect;
    public AudioClip Click;
    public AudioClip Win;
    public AudioClip Lose;
    public AudioClip Item;

    private void OnEnable()
    {
        UpdateSound();
        UpdateMusic();

    }
    public void UpdateSound()
    {
        int status = PlayerPrefs.GetInt(Constants.Sound, 1);
        Effect.enabled = Convert.ToBoolean(status);
        //  Effect.mute = Convert.ToBoolean(Convert.ToInt16(!Convert.ToBoolean(status)));

    }public void UpdateMusic()
    {
        int status = PlayerPrefs.GetInt(Constants.Music, 1);
        Background.enabled = Convert.ToBoolean(status);

    }

    public void PlayOnshootSound(AudioClip Clip_)
    {
     //   SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        Effect.PlayOneShot(Clip_);
    }

}
