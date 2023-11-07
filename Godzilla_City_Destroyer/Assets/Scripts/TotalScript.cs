using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScript : MonoBehaviour
{
    [SerializeField] Text pointsText;
    public TotalPoints points;

    void Update(){
        pointsText.text = "Total Points: " + points.points;

    }
}
