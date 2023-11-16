using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSlide : MonoBehaviour
{
    [SerializeField] Transform inTransform;
    [SerializeField] Transform creditsImage;
    [SerializeField] float slideTime = 51f;
    [SerializeField] GameObject finalScoreImage;

        void Start(){
            finalScoreImage.SetActive(false);
            SlideInCredit();
        }

        public void SlideInCredit(){
        StartCoroutine(SlideInRoutine());
        IEnumerator SlideInRoutine(){
            float timer = 0f;
            while(timer < slideTime){
                timer+=Time.deltaTime;
                creditsImage.position = Vector3.Lerp(creditsImage.position, inTransform.position, (timer/slideTime) / 900);
                yield return null;
            }
            Debug.Log("End Credits");
            yield return null;
            finalScoreImage.SetActive(true);
            //SceneManager.LoadScene("EndScene");
        }
    }

}
