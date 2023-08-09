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
         if (_DownIndex == Vector2.negativeInfinity)
         {
            Debug.Log("Up");
         
            return;
         } if (_DownIndex == GetComponent<Index>().IndexPosition)
         {
           
         
            return;
         }
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
    
      if (DownIndex.x > GetComponent<Index>().IndexPosition.x)
      {
         LineRenderer R = transform.Find("X").GetComponent<LineRenderer>();
        
         int a = (int) ( DownIndex.x-GetComponent<Index>().IndexPosition.x );
         a -= 1;
        // Debug.Log(a);
         if (a == R.GetPosition(1).x)
         {
            
            if (GridData.Instance.GetIndex(DownIndex) == 0)
            { Debug.Log("X");
               GetComponentInChildren<Number>().MyNmber -= 1;
               GridData.Instance.SetGridIndex(DownIndex);
               R.SetPosition(1, new Vector3(a + 1, R.GetPosition(1).y, 0));
            }
         }
      }

     else if (DownIndex.x < GetComponent<Index>().IndexPosition.x)
      {
         LineRenderer R = transform.Find("-X").GetComponent<LineRenderer>();

         int a = (int) ( DownIndex.x-GetComponent<Index>().IndexPosition.x );
         a += 1;
         //Debug.Log(a);
         if (a == R.GetPosition(1).x)
         {
            if (GridData.Instance.GetIndex(DownIndex) == 0)
            {         Debug.Log("-X");
               GetComponentInChildren<Number>().MyNmber -= 1;

               GridData.Instance.SetGridIndex(DownIndex);
               R.SetPosition(1, new Vector3(a - 1, R.GetPosition(1).y, 0));
            }
         }
      }
   } 
   private void MoveY()
   {
      if (DownIndex.y > GetComponent<Index>().IndexPosition.y)
      {
         LineRenderer R = transform.Find("Y").GetComponent<LineRenderer>();
         int a = (int) ( DownIndex.y-GetComponent<Index>().IndexPosition.y );
         a -= 1;
       //  Debug.Log(a);
         if (a == R.GetPosition(1).y)
         {
            if (GridData.Instance.GetIndex(DownIndex) == 0)
            {         Debug.Log("Y");
               GetComponentInChildren<Number>().MyNmber -= 1;

               GridData.Instance.SetGridIndex(DownIndex);
               R.SetPosition(1, new Vector3(R.GetPosition(1).x, a + 1, 0));
            }
         }
      }
     else if (DownIndex.y < GetComponent<Index>().IndexPosition.y)
      {
         LineRenderer R = transform.Find("-Y").GetComponent<LineRenderer>();
         int a = (int) ( DownIndex.y-GetComponent<Index>().IndexPosition.y );
         a += 1;
        // Debug.Log(a);
         if (a == R.GetPosition(1).y)
         {
            if (GridData.Instance.GetIndex(DownIndex) == 0)
            {
               Debug.Log("-Y");
               GetComponentInChildren<Number>().MyNmber -= 1;

               GridData.Instance.SetGridIndex(DownIndex);
               R.SetPosition(1, new Vector3(R.GetPosition(1).x, a - 1, 0));
            }
         }

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
      DownIndex=Vector2.negativeInfinity;


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
