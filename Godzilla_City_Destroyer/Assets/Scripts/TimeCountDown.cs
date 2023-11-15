using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountDown : MonoBehaviour
{
    [SerializeField] Text timerText;
    public int secondsLeft = 0;
    public bool takingAway = false;
    public bool done;
        
    void Start(){
        done = false;
        timerText.text = "";
    }

    void Update(){
        if(takingAway == false && secondsLeft > 0){
            done = false;
            StartCoroutine(TimerTake());
        }
    }

    public void setSeconds(int d){
        secondsLeft = d;
    }

    public void addSeconds(int d){
        secondsLeft += d;
    }


    IEnumerator TimerTake(){
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if(secondsLeft == 0){
            done = true;
            timerText.text = "";
        }else{
            timerText.text = "Time: " + secondsLeft;
        }
        takingAway = false;
    }

}
