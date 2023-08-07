using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    public List<Color> Colors;
  
    public List<Button> Sound;
    public List<Button> Vib;
    public List<Button> Lang; 
    // public List<TextMeshProUGUI> Soundtxt;
    // public List<TextMeshProUGUI> Vibtxt;
    // public List<TextMeshProUGUI> Langtxt;

    private void OnEnable()
    {
        UpdateNow();
    }

    private void UpdateNow()
    {
        // int soundpref = PlayerPrefs.GetInt(Constants.Sound, 1);
        // Soundtxt[soundpref.Reverse()].color=Colors[soundpref.Reverse()];
        // Debug.Log(soundpref.Reverse());
        // Debug.Log(soundpref);
        // Soundtxt[soundpref].color = Colors[soundpref]; 
        //
        
        
        
        
        
        
        
        Sound.ForEach(x=>x.interactable=true);
        Sound[PlayerPrefs.GetInt(Constants.Sound, 1)].interactable = false; 
       Vib.ForEach(x=>x.interactable=true);
   //    Vibtxt[PlayerPrefs.GetInt(Constants.Vibration, 1).Reverse()].color=Colors[PlayerPrefs.GetInt(Constants.Vibration, 1)];
       Vib[PlayerPrefs.GetInt(Constants.Vibration, 1)].interactable = false;
     //  Vibtxt[PlayerPrefs.GetInt(Constants.Vibration, 1)].color = Colors[PlayerPrefs.GetInt(Constants.Vibration, 1)];
       Lang.ForEach(x=>x.interactable=true);
     //  Langtxt[PlayerPrefs.GetInt(Constants.Language, 0).Reverse()].color=Colors[PlayerPrefs.GetInt(Constants.Language, 0)];
       Lang[PlayerPrefs.GetInt(Constants.Language, 0)].interactable = false;
      // Langtxt[PlayerPrefs.GetInt(Constants.Language, 0)].color = Colors[PlayerPrefs.GetInt(Constants.Language, 0).Reverse()];
       
    }

    public void ToggleSoound(int cur)
    {
  
     
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        PlayerPrefs.SetInt(Constants.Sound,cur);
       SoundManager.Instance.UpdateSound();
       UpdateNow();

    }
    public void ToggleLang(int a)
    {
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);

        PlayerPrefs.SetInt(Constants.Language,a);
        var languages = FindObjectsOfType<Language>();
        languages.ToList().ForEach(x=>x.Change());
        UpdateNow();

    }
    public void ToggleVibration(int cur)
    {

        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        PlayerPrefs.SetInt(Constants.Vibration,cur);
        UpdateNow();
    }

}
