using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBuildingHandler : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject damageEffect;
    [SerializeField] Sprite damage;
    //[SerializeField] pointsHandler points;
    bool belowDamage = false;

    public TotalPoints pointsInfo;

    public CentralGameScript sceneCheck;

    void Awake(){
        health = 60;
        damageEffect.SetActive(false);
    }

    void Update(){
        if(health <= 0){
            //damageEffect.SetActive(false);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            sceneCheck.currentState += 999;
            pointsHandler.singleton.addPoints(100);
            pointsInfo.points += 100;
            //Debug.Log("Current state is", )
            Destroy(damageEffect.gameObject);
           // gameObject.GetComponent<SpriteRenderer>().enabled = false;
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
