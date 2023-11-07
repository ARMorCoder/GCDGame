using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    
    [SerializeField] AudioSource audio;

    public void PlayMe(){
        audio.Play();
    }

}
