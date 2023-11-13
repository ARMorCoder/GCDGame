using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHandler : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] Transform target;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject leftAttack;
    [SerializeField] GameObject rightAttack;
    Vector3 shootPos = new Vector3(0,0,0);
    Vector3 tarPos = new Vector3(0, 0, 0);
    [SerializeField] int health;
    [SerializeField] GiganAnimateStateChanger gsc;
    [SerializeField] Text healthText;
    int rnd;
    public CentralGameScript sceneCheck;

    public AudioSource hurtAudio;
    public AudioSource attackAudio;
    [SerializeField] float time;

    public TotalPoints pointsInfo;
    bool bossDefeat = false;

    void Start(){
        time = 1.0f;
        leftAttack.SetActive(false);
        rightAttack.SetActive(false);
        healthText.text = "Gigan: " + health;
        SpawnBulletOverTime();
        PickAttackOverTime();
    }

    void Awake(){
        health =  50;

    }

    void Update(){
        shootPos = new Vector3(head.position.x, head.position.y, 0);
        tarPos = new Vector3(target.position.x, target.position.y, 0);
        if(health <= 25){
            time = 0.5f;
        }
        if(health <= 0){
            //Destroy(gameObject);
            if(!bossDefeat){
                pointsInfo.points += 1500;
                pointsHandler.singleton.addPoints(1500);
                bossDefeat = true;
            }
            sceneCheck.currentState = 999;
        }
        healthText.text = "Gigan: " + health;
    }

     void SpawnBulletOverTime(){
        StartCoroutine(SpawnBulletOverTimeRoutine());
        IEnumerator SpawnBulletOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(time);
                Rigidbody2D newBullet = Instantiate(bullet,transform.position,Quaternion.identity).GetComponent<Rigidbody2D>();
                tarPos.z = 0;
                newBullet.velocity = (tarPos - transform.position);
                Destroy(newBullet.gameObject, 3);
            }

            yield return null;
            
         }
     }

     void PickAttackOverTime(){
        StartCoroutine(PickAttackOverTimeRoutine());
        IEnumerator PickAttackOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(5);
                    rnd = Random.Range(0,9);
                    if(rnd % 2 == 0){
                        gsc.ChangeAnimationState("GiganLeftAttack");
                        leftAttack.SetActive(true);
                        attackAudio.Play();
                        yield return new WaitForSeconds(2);
                        leftAttack.SetActive(false);
                        gsc.ChangeAnimationState("GiganIdle");
                    }else{
                        gsc.ChangeAnimationState("GiganRightAttack");
                        rightAttack.SetActive(true);
                        attackAudio.Play();
                        yield return new WaitForSeconds(2);
                        rightAttack.SetActive(false);
                        gsc.ChangeAnimationState("GiganIdle");
                    }
                }
                 yield return null;
            }
    }

     void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "FriendlyBullet"){
            health--;
            hurtAudio.Play();
            Destroy(obj.gameObject);
        }
     }
}
