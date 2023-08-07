using System;
using System.Collections;
using System.Collections.Generic;
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
            _MyNmber = value;
            GetComponent<TextMeshPro>().text = _MyNmber.ToString();
        }
    }
    private void OnEnable()
    {
        MyNmber = _MyNmber;
    }
}
