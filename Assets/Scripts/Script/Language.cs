using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[ExecuteInEditMode]
public class Language : MonoBehaviour
{
  public Sprite English;
  public Sprite Russian;
 public Sprite Port;
 
  private void OnEnable()
  {
    if (English == null&& !Application.isPlaying)
    {
      English = GetComponent<Image>().sprite;
    }

    if(!Application.isPlaying) return;
    
    Change();
  
  }

public  void Change()
  {
    switch (PlayerPrefs.GetInt(Constants.Language,0))
    {
      case 0:
        GetComponent<Image>().sprite = English;
        break; 
      case 1:
        GetComponent<Image>().sprite = Russian;
        break;
      case 2:
      GetComponent<Image>().sprite = Port;
        break;
      default:
        break;
    }
  }
}
