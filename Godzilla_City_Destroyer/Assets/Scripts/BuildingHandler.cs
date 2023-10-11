using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject damageEffect;
    bool belowDamage = false;

    void Awake(){
        health = 50;
        damageEffect.SetActive(false);
    }

    void Update(){
        if(health <= 0){
            //damageEffect.SetActive(false);
            CentralGameScript.currentState += 5;
            //Debug.Log("Current state is", )
            Destroy(damageEffect.gameObject);
            Destroy(gameObject);
        }
        if(health <= 15 && belowDamage != true){
            damageEffect.SetActive(true);
            belowDamage = true;
        }
    }

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("damage was taken to building");
    }

    void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "FriendlyBullet"){
            TakeDamage(3);
           GetComponent<AudioSource>().Play();
            Destroy(obj.gameObject);
        }
    }

}
