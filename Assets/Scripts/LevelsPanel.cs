using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    
   public List<Image> LevelImg;

   private void OnEnable()
   {
       LevelImg.ForEach(x=>x.GetComponent<Button>().interactable=false);
      for (int i = 0; i <= Session.Instance.UnlockedLevel; i++)
      {
          LevelImg[i].GetComponent<Button>().interactable = true;
      }
   }

  
   public void SelectLevel(int val)
   {
       SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
       Session.Instance.CurrentLevel = val;
       CanvasManager.Instance.Gamestate = States.Game;
   }
}
