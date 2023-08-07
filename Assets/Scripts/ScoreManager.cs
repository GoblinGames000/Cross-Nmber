using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   public static ScoreManager Instance;
   public List<TextMeshProUGUI> CoinText;
   private void Awake()
   {
      Instance = this;
   }

   public int _Coin;
   public int Coin
   {
      get
      {
         return _Coin;
      }
      set
      {
         _Coin = value;
         CoinText.ForEach(x=>x.text=_Coin.ToString());
        
      }
      
   }  
 
   private void OnEnable()
   {
     
         Coin = PlayerPrefs.GetInt("HS",0);
     
   }

   private void OnApplicationPause(bool pauseStatus)
   {
      if (pauseStatus)
      {
        PlayerPrefs.SetInt("HS",Coin);
      }
   }

   private void OnDisable()
   {
      PlayerPrefs.SetInt("HS",Coin);

   }
}
