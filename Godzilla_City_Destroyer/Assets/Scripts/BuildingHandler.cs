using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject damageEffect;
    [SerializeField] Sprite damage;
    bool belowDamage = false;

    public TotalPoints pointsInfo;

    public CentralGameScript sceneCheck;

    public BuildingCounter bC;

    void Awake(){
        health = 60;
        damageEffect.SetActive(false);
    }

    void Update(){
        if(health <= 0){
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            sceneCheck.currentState += 5;
            bC.counter -= 1;
            pointsHandler.singleton.addPoints(100);
            pointsInfo.points += 100;
            Destroy(damageEffect.gameObject);
            Destroy(gameObject);
        }
        if(health <= 15 && belowDamage != true){
            GetComponent<SpriteRenderer>().sprite = damage;
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
            TakeDamage(5);
            GetComponent<AudioSource>().Play();
            Destroy(obj.gameObject);
        }
    }

}
