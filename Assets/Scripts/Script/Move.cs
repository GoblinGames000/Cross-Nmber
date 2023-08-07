using System;
using System.Collections;
using System.Collections.Generic;
using CustomCamera;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public SpriteRenderer sp;

    public float TimeGame;
    public AnimationCurve SpeedCurve;
    public float Angle;
    public float Rotspeed;
    // Update is called once per frame
    void Update()
    {
        if (CanvasManager.Instance.Gamestate!=States.Game) return;

        if (Input.GetMouseButtonDown(0))
        {
            Angle = (-Angle);
        }

        if (Angle > 0)
        {
            sp.flipX = false;
        }
        else
        {
            sp.flipX = true;
            
        }
        TimeGame += Time.deltaTime;
       // ScoreManager.Instance.Score = (int)TimeGame;
            float new_angle = Mathf.LerpAngle(transform.eulerAngles.z, Angle, Time.deltaTime*Rotspeed );
            transform.eulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,new_angle);
            transform.GetChild(0).localEulerAngles=new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,-new_angle);
            Vector3 v = Vector3.down * Time.deltaTime * SpeedCurve.Evaluate(TimeGame);
        
            transform.Translate(v);
        transform.localPosition=new Vector3(transform.localPosition.x,transform.localPosition.y,0);        
                
        
    }
[ContextMenu("Shake")]
    public void Shake()
    {
        CameraShake.Shake(0.5f,0.25f);

    }

    public List<Sprite> Death;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerPrefs.GetInt(Constants.Vibration, 1) == 1)
        {
            MMVibrationManager.Haptic (HapticTypes.Failure);

        }
        
        if (other.CompareTag("H"))
        {
        } if (other.CompareTag("Finish"))
        {
        }
        if (other.CompareTag("Finish")||other.CompareTag("H"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponentInChildren<Animator>().enabled = false;
            Camera.main.transform.GetComponent<FollowCamera2D>().enabled = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Death[0];
            CameraShake.Shake(0.25f,0.25f);
           // CanvasManager.Instance.Gamestate = States.Lose;
        }
    }
}
