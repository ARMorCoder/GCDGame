using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SlideTransition : MonoBehaviour
{
    [SerializeField] Transform outTransform;
    [SerializeField] Transform inTransform;
    [SerializeField] GameObject winState;
    [SerializeField] float slideTime = 2f;

    void Start(){
        winState.SetActive(false);
        SlideOut();
    }

    void Update(){
        if(CentralGameScript.currentState == CentralGameScript.winState){
            winState.SetActive(true);
            Debug.Log("You win!!");
            SlideIn("BossLevel");
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
