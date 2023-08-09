using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Number : MonoBehaviour
{
    public int _MyNmber;

    public int MyNmber
    {
        get => _MyNmber;
        set
        {
            if(value<0) return;
            if (value == 0)
            {
                transform.parent.GetComponentInChildren<DOTweenVisualManager>().enabled = true;
            }
            _MyNmber = value;
            GetComponent<TextMeshPro>().text = _MyNmber.ToString();
            if(CanvasManager.Instance.Gamestate!=States.Game) return;

            if (FindObjectsOfType<Number>().ToList().All(x => x.MyNmber <= 0))
            {
                CanvasManager.Instance.Gamestate = States.Win;
            }
        }
    }
    private void OnEnable()
    {
        MyNmber = _MyNmber;
    }
}
