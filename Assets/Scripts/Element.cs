using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Element : MonoBehaviour
{
  public int X;
  public int Y;
  public int index;
  private void OnEnable()
  {
    transform.localScale=Vector3.zero;
    transform.DOScale(Vector3.one, 0.25f);
  }

 
  public float duration = 0.5f;
  public float strength = 0.5f;
  public int vibrato = 10;
  public float randomness = 90f;


  void Start()
  {

  }

 
  
  void ReturnToOriginalScale()
  {
    transform.DOScale(Vector3.one, duration);
  }
  [ContextMenu("Shake")]
 public void Shake()
  {
    transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0f), duration, vibrato, randomness).OnComplete(ReturnToOriginalScale);
    transform.DOPunchRotation(new Vector3(0f, 0f, 10f), duration, vibrato, randomness);
  }
}
