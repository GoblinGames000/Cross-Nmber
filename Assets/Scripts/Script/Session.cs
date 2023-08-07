using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : Singletion<Session>
{
   public bool Replay;
   public int CurrentLevel;
   public int UnlockedLevel;

   private void OnEnable()
   {
      if (ES3.KeyExists(gameObject.name))
      {
         UnlockedLevel = (int)ES3.Load(gameObject.name);
      }

      CurrentLevel = UnlockedLevel;
   }

   private void OnDisable()
   {
      ES3.Save(gameObject.name,UnlockedLevel);
   }

   private void OnApplicationPause(bool pauseStatus)
   {
      if(!pauseStatus) return;
      ES3.Save(gameObject.name,UnlockedLevel);
   }
}
