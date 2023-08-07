using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
  
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI TimeText;
    public float _Time;

    public float TimeVal
    {
        get => _Time;
        set
        {
            if (value < 0)
            {
                value = 0;
                CanvasManager.Instance.Gamestate = States.Lose;
            }
            _Time = value;
            TimeText.text = _Time.ToDateTime();
            if (_Time < 10)
            {
                TimeText.color=Color.blue;
            }
            else
            {
                TimeText.color=Color.white;

            }
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
       LevelText.text = $"LEVEL {Session.Instance.CurrentLevel+1}";
    }

    private void Update()
    {
        if(CanvasManager.Instance.Gamestate!=States.Game) return;
        TimeVal -= Time.deltaTime;
        
    }
}
