using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SlideTransition : MonoBehaviour
{
    [SerializeField] Transform outTransform;
    [SerializeField] Transform inTransform;
    [SerializeField] GameObject winState;
    [SerializeField] GameObject loseState;
    [SerializeField] PlayerInputHandler player;
    [SerializeField] PlayerInputBossLevel playerBoss;
    [SerializeField] float slideTime = 2f;

    void Start(){
        CentralGameScript.currentState = 0;
        winState.SetActive(false);
        loseState.SetActive(false);
        SlideOut();
    }

    void Update(){
        if(CentralGameScript.currentState == CentralGameScript.winState){
            winState.SetActive(true);
            Debug.Log("You win!!");
            CentralGameScript.currentState = 0;
            SlideIn("BossLevel");
        }
        else if(player.health <= 0 || playerBoss.health <= 0){
            loseState.SetActive(true);
            SlideIn("TitleScreen");
        }
        else if(CentralGameScript.currentState == CentralGameScript.bossWinState){
            winState.SetActive(true);
            Debug.Log("You win!!");
            CentralGameScript.currentState = 0;
            SlideIn("TitleScreen");
        }
    }

    public void SlideOut(){
        StartCoroutine(SlideOutRoutine());
        IEnumerator SlideOutRoutine(){
            float timer = 0f;
            while(timer < slideTime){
                timer+=Time.deltaTime;
                transform.position = Vector3.Lerp(inTransform.position, outTransform.position, (timer/slideTime));
                yield return null;
            }
            yield return null;
        }
    }

    public void SlideIn(string sceneName){
        StartCoroutine(SlideInRoutine());
        IEnumerator SlideInRoutine(){
            float timer = 0f;
            while(timer < slideTime){
                timer+=Time.deltaTime;
                transform.position = Vector3.Lerp(outTransform.position, inTransform.position, (timer/slideTime));
                yield return null;
            }
            yield return null;
            SceneManager.LoadScene(sceneName);
        }
    }





}
