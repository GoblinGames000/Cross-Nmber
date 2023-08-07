using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SettingScreen : MonoBehaviour
{
 
    public Image Vivbtn;


    public Image Soundbtn;
    public Image Musicbtn;
    public List<Sprite> S;
    public List<Sprite> M;
    public List<Sprite> V;

    private void OnEnable()
    {
        Up();
    }

    private void Up()
    {

        Soundbtn.sprite = S[PlayerPrefs.GetInt(Constants.Sound, 1)];
        Musicbtn.sprite = M[PlayerPrefs.GetInt(Constants.Music, 1)];
        Vivbtn.sprite = V[PlayerPrefs.GetInt(Constants.Vibration, 1)];
    }

    public void ToggleSoound()
    {
        int a = PlayerPrefs.GetInt(Constants.Sound, 1);
        a = a^1;
     
       
        PlayerPrefs.SetInt(Constants.Sound,a);
        Up();
        SoundManager.Instance.UpdateSound();
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
       
    }  public void ToggleVibration()
    {
        int a = PlayerPrefs.GetInt(Constants.Vibration, 1);
        a = a^1;
     
       
        PlayerPrefs.SetInt(Constants.Vibration,a);
       Up();
            SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);


    } public void ToggleMusic()
    {
        int a = PlayerPrefs.GetInt(Constants.Music, 1);
        a = a^1;
     
       
        PlayerPrefs.SetInt(Constants.Music,a);
       Up();
       SoundManager.Instance.UpdateMusic();

            SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);


    }
   
   
}
