using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pointsHandler : MonoBehaviour
{
  public static pointsHandler singleton;
     [SerializeField] int points;
     [SerializeField] Text PointText;

    void Awake(){
        if (singleton == null){
            singleton = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    void Update(){
        PointText.text = "Points: " + points;
    }

    public void addPoints(int d){
        points += d;
    }
}
