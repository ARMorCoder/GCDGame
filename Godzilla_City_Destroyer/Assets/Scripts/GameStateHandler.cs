using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] SlideTransition slideEvent;
    [SerializeField] PlayerInputHandler player;

    void Update(){
        if(player.health <= 0){
           // slideEvent.loseState(true);
            //SlideIn("TitleScreen");
        }
    }
}
