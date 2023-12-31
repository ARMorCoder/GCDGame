using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelName : MonoBehaviour
{
    [SerializeField] Text nameText;

    void Update(){
        Scene scene = SceneManager.GetActiveScene();

        string name = CheckLevel(scene);

        nameText.text = name;

    }

        public string CheckLevel(Scene currentScene){
        switch(currentScene.name){
            case "TutorialScene":
                return "Tutorial";
                break;
            case "Level1_City":
                return "Level 1: Tokyo";
                break;
            case "Level1_Boss":
                return "Level 1: Gigan";
                break;
            case "Level2_City":
                return "Level 2: The Artic";
                break;
            case "Level2_Boss":
                return "Level 2: Megalon";
                break;
            case "Level3_City":
                return "Level 3: X Mothership";
                break;
            case "Level3_Boss":
                return "Level 3: Ghidorah";
                break;
            default:
                return "ERROR";
        }
    }
    
}
