using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SlideTransition : MonoBehaviour
{

    [SerializeField] Transform topCover;
    [SerializeField] Transform bottomCover;
    [SerializeField] Transform bottomOutTransform;
    [SerializeField] Transform topOutTransform;
    [SerializeField] Transform inTransform;
    [SerializeField] GameObject winState;
    [SerializeField] GameObject loseState;
    [SerializeField] PlayerInputHandler player;
    [SerializeField] PlayerInputBossLevel playerBoss;
    [SerializeField] float slideTime = 2f;
    public TotalPoints pointsInfo;
    public string level;
    public CentralGameScript sceneCheck;

    void Awake(){
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "TitleScreen"){
            pointsInfo.points = 0;
            sceneCheck.arrayCheck = -1;
        }else{
            sceneCheck.arrayCheck += 1;
        }
    }

    void Start(){
        sceneCheck.currentState = 0;
        winState.SetActive(false);
        loseState.SetActive(false);
        SlideOut();
    }

    void Update(){
        Scene scene = SceneManager.GetActiveScene();
        if(sceneCheck.currentState == sceneCheck.winState){
            winState.SetActive(true);
            Debug.Log("You win!!");
            /*
            sceneCheck.currentState = 0;
            level = sceneCheck.levelNames[sceneCheck.arrayCheck];*/
            level = CheckLevel(scene);
            SlideIn(level);
        }
        else if(player.health <= 0 || playerBoss.health <= 0){
            loseState.SetActive(true);
            sceneCheck.currentState = 0;
            sceneCheck.arrayCheck = 0;
            SlideIn("TitleScreen");
        }
        else if(sceneCheck.currentState == sceneCheck.bossWinState){
            winState.SetActive(true);
            Debug.Log("You win!!");
            sceneCheck.currentState = 0;
            /*
            if(scene.name =="Level2_Boss"){
                level = "EndScene";
            }else{
                level = sceneCheck.levelNames[sceneCheck.arrayCheck];
            }*/
            level = CheckLevel(scene);
            SlideIn(level);
            //SlideIn("TitleScreen");
        }
    }

    public void SlideOut(){
        StartCoroutine(SlideOutRoutine());
        IEnumerator SlideOutRoutine(){
            float timer = 0f;
            while(timer < slideTime){
                timer+=Time.deltaTime;
                bottomCover.position = Vector3.Lerp(inTransform.position, bottomOutTransform.position, (timer/slideTime));
                topCover.position = Vector3.Lerp(inTransform.position, topOutTransform.position, (timer/slideTime));
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
                bottomCover.position = Vector3.Lerp(bottomOutTransform.position, inTransform.position, (timer/slideTime));
                topCover.position = Vector3.Lerp(topOutTransform.position, inTransform.position, (timer/slideTime));
                yield return null;
            }
            yield return null;
            SceneManager.LoadScene(sceneName);
        }
    }


    public string CheckLevel(Scene currentScene){
        switch(currentScene.name){
            case "TutorialScene":
                return "Level1_City";
                break;
            case "Level1_City":
                return "Level1_Boss";
                break;
            case "Level1_Boss":
                return "Level2_City";
                break;
            case "Level2_City":
                return "Level2_Boss";
                break;
            case "Level2_Boss":
                return "EndScene";
                break;
            default:
                return "TitleScreen";
        }
    }





}
