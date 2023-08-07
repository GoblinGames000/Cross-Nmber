using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Level
{
  public bool IsOpen;
  public int Moves;
  public List<Collectable> _Colectable;
  public Vector2 GridSize;
}
[Serializable]
public class Collectable
{
  public Sprite ToCollect;
  public int Count;
}
public class LevelData : MonoBehaviour

{
  public static LevelData Instance;

  private void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
    {
      Destroy(gameObject);
    }
  }

  public List<Level> Levels;

  private void OnEnable()
  {
    if (ES3.KeyExists(gameObject.name))
    {
      Levels = ES3.Load(gameObject.name) as List<Level>;
    }
  }

  private void OnDisable()
  {
    ES3.Save(gameObject.name,Levels);

  }

  private void OnApplicationPause(bool pauseStatus)
  {
    if(!pauseStatus) return;
    ES3.Save(gameObject.name,Levels);

  }
}
