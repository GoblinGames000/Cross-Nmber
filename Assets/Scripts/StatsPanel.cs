using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    public TextMeshProUGUI Played;
    public TextMeshProUGUI LevelComp;
    public List<Image> Images;

    private void OnEnable()
    {

        Played.text = $"{PlayerPrefs.GetInt("Comp", 0)}/10";
        LevelComp.text = $"{(Session.Instance.UnlockedLevel)}/5";
        Images[0].fillAmount = (float) PlayerPrefs.GetInt("Comp", 0) / 10f;
        Images[1].fillAmount = (float) Session.Instance.UnlockedLevel / 5f;
    }
}
