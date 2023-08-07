using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    
    public List<GameObject> Prefab;
    public List<GameObject> Coin;

    private void Start()
    {
        StartCoroutine(nameof(Spawn));
    }

    IEnumerator Spawn()
   {
      while (CanvasManager.Instance.Gamestate == States.Game)
      {

        
      }
     yield return new WaitUntil(()=>CanvasManager.Instance.Gamestate!=States.Game);
     StartCoroutine(nameof(Spawn));

   }
}
