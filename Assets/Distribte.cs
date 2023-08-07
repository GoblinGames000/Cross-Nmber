using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distribte : MonoBehaviour
{
   public bool Pressed;
   public int MinX;
   public int MaxX;
   public int MinY;
   public int MaxY;
   public Vector2 _DownIndex;

   public Vector2 DownIndex
   {
      get => _DownIndex;
      set
      {
         _DownIndex = value;
         if(_DownIndex==Vector2.zero) return;
         if (_DownIndex.x ==GetComponent<Index>().IndexPosition.x)
         {
            //Y
            MoveY();
         }
         else if (_DownIndex.y == GetComponent<Index>().IndexPosition.y)
         {
            //X
            MoveX();
         }
         
      }
   }

   private void MoveX()
   {
      Debug.Log("X");
      if (DownIndex.x > GetComponent<Index>().IndexPosition.x)
      {
         LineRenderer R = transform.Find("X").GetComponent<LineRenderer>();
      }

     else if (DownIndex.x > GetComponent<Index>().IndexPosition.x)
      {
         LineRenderer R = transform.Find("-X").GetComponent<LineRenderer>();

      }
   } 
   private void MoveY()
   {
      Debug.Log("Y");
      if (DownIndex.y > GetComponent<Index>().IndexPosition.y)
      {
         LineRenderer R = transform.Find("Y").GetComponent<LineRenderer>();
      }
     else if (DownIndex.y < GetComponent<Index>().IndexPosition.y)
      {
         LineRenderer R = transform.Find("-Y").GetComponent<LineRenderer>();

      }

   }
   private void OnMouseDown()
   {
      Pressed = true;
      DownIndex=Vector2.zero;
   }

   private void OnMouseUp()
   {
      Pressed = false;
      DownIndex=Vector2.zero;


   }

   private void OnMouseDrag()
   {
      Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);
      if (hit.collider != null)
      {
         if (hit.collider.gameObject.TryGetComponent<Index>(out Index I))
         {
            DownIndex =I.IndexPosition;
         }
      }
   }
}
