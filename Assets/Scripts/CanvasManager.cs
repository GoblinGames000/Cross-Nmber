using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    private void Awake()
    {
        Instance = this;
    }


    public GameObject Main;
    public GameObject Setting;
   public GameObject Play;
    public GameObject Game;
    public GameObject Levels;
    public GameObject Win;
    public GameObject Stats;
    public GameObject Lose;
    public ParticleSystem WinParticle;
    public List<GameObject> AllScreens;
    [SerializeField]
    private States _Gamestate;
    public States Gamestate
    {
        get => _Gamestate;
        set
        {

            Prev = _Gamestate;
            _Gamestate = value;
            if (_Gamestate != States.Win)
            {
                if (_Gamestate != States.Lose)
                {
                    TurnOffAll();
                }
            }

            switch (_Gamestate)
            {
                case States.Main:
                    Main.Show();
                    break;
                case States.Setting:
                    Setting.Show();
                    break;
                case States.Game:
                 Play.SetActive(true);
                    Game.Show();
                    break;
                case States.Levels:
                    Levels.Show();
                    break; case States.Stats:
                    Stats.Show();
                    break;
                case States.Win:

                    if (Game.GetComponent<GameManager>().TimeVal > PlayerPrefs.GetFloat("GameTime", 0))
                    {
                        PlayerPrefs.SetFloat("GameTime", Game.GetComponent<GameManager>().TimeVal);
                    }

                    if (Session.Instance.CurrentLevel < 8)
                    {
                        
                    Session.Instance.CurrentLevel += 1;
                    }
                    else
                    {
                        Session.Instance.CurrentLevel =0;
                    }
                    if (Session.Instance.UnlockedLevel < 8)
                    {
                        
                    Session.Instance.UnlockedLevel += 1;
                    }

                   
                    this.Invoke(() =>
                    {
                        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Win);
                        TurnOffAll();
                        Win.Show();
                       
                    }, 2f);
                    break;
               case States.Lose:
                    
                   
                    this.Invoke(() =>
                    {
                        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Lose);

                        TurnOffAll();
                        Lose.Show();
                       
                    }, 2f);
                    break;
               
                
            }

        }
    }

    public States Prev;
    private void Start()
    {
       
        if (Session.Instance.Replay)
        {
            Session.Instance.Replay = false;
           Gamestate = States.Game;
            return;
        }
        Gamestate = States.Main;

    }
    public void Replay() 
    {
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        Session.Instance.Replay = true;
        Fade.Instance.LoadScene("Game");
    }
    [ContextMenu("Reload")]
    public void MainMenu() 
    {
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);

        Fade.Instance.LoadScene("Game");
    }
    public void ReplaySameLevel() 
    {
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        Session.Instance.Replay = true;
        Session.Instance.CurrentLevel -= 1;
        if (Session.Instance.CurrentLevel < 0)
        {
            Session.Instance.CurrentLevel = 1;
        }
        Fade.Instance.LoadScene("Game");
    }

    public void TurnOffAll()
    { 
        Play.SetActive(false);
        AllScreens.ForEach(x =>
        {
                x.Hide();
        });
    }

    public void OnClickBack()
    {
        SoundManager.Instance.PlayOnshootSound(SoundManager.Instance.Click);
        CanvasManager.Instance.Gamestate = Prev;
    }
}
public enum States
{
    Main, Setting, Game, Levels, Win,Stats,Lose
}






























