using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowLevel : MonoBehaviour
{
  public List<GameObject> Levels;
  public TextMeshProUGUI T;

  private void OnEnable()
  {
    T.text = $"LEVEL {Session.Instance.CurrentLevel}";
    Levels[Session.Instance.CurrentLevel].SetActive(true);  
  }
}
