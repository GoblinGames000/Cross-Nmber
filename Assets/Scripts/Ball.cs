using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class Ball : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D other)
  {
    if(CanvasManager.Instance.Gamestate==States.Lose|| CanvasManager.Instance.Gamestate==States.Win) return;
    if (other.gameObject.CompareTag("Ball"))
    {
      SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Item);
      
      if (PlayerPrefs.GetInt(Constants.Vibration, 1) == 1)
      {
        MMVibrationManager.Haptic(HapticTypes.Success);
      }
      CanvasManager.Instance.WinParticle.transform.position = transform.position;
      CanvasManager.Instance.WinParticle.Play();
      
      CanvasManager.Instance.Gamestate = States.Win;
    }
   if (other.gameObject.CompareTag("Finish"))
    {
      if (PlayerPrefs.GetInt(Constants.Vibration, 1) == 1)
      {
        MMVibrationManager.Haptic(HapticTypes.Failure);
      }
      CanvasManager.Instance.Gamestate = States.Lose;
    }
  
  }
}
