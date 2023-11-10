using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public BuildingCounter bC;
    [SerializeField] Text countText;

    void Update(){
        countText.text = "Buildings: " + bC.counter;
    }
}
