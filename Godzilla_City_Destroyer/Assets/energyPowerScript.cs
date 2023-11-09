using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyPowerScript : MonoBehaviour
{
    public int amount;

    void Awake(){
        int rnd = checkPoint(gameObject.tag);
        amount = rnd;
    }

    public int checkPoint(string tag){
        int rnd;
        switch(gameObject.tag){
            case "energyPoint":
                rnd = Random.Range(4, 9);
                break;
            case "armorPoint":
                rnd = Random.Range(15,30);
                break;
            case "healthPoint":
                rnd = Random.Range(4, 10);
                break;
            default:
                rnd = 1;
                break;
        }
        return rnd;
    }
}
