using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestPanel : MonoBehaviour
{
  public TextMeshProUGUI TimeText;

  private void OnEnable()
  {
      if (PlayerPrefs.GetFloat("GameTime", 0) == 0)
      {
          TimeText.text = "--:--";

      }
      else
      {
          float T = PlayerPrefs.GetFloat("GameTime", 0);
          TimeText.text = Mathf.RoundToInt(30 - T).ToString();

      }
  }
}
