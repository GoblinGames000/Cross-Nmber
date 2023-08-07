using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
   private void OnEnable()
   {
      this.Invoke(() =>
      {
         gameObject.Hide();
      }, 2f);
   }
}
