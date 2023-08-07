using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movebg : MonoBehaviour
{
    private void Start()
    {
       Vector3 size=Camera.main.ViewportToWorldPoint(Vector3.one);
       size.z = 0;
      // transform.localScale = size * 2;
        StartCoroutine(move());
    }
  
    IEnumerator move()
   {
      RawImage mat = GetComponent<RawImage>();
          float offst = 0;
      while (true)
      {
          mat.uvRect = new Rect(new Vector2(offst,offst/2), Vector2.one);
          offst += 0.02f*Time.deltaTime;
      yield return new WaitForEndOfFrame();
      }
   }
}
