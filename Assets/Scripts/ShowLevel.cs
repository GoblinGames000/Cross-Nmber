using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevel : MonoBehaviour
{
  public List<GameObject> Levels;

  private void OnEnable()
  {
    Levels[Session.Instance.CurrentLevel].SetActive(true);  
  }
}
