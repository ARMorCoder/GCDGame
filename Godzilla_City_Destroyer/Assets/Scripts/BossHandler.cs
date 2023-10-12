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

    void Start(){
        bullet.GetComponent<SpriteRenderer>().color = Color.red;
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
        /*rnd = Random.Range(0,1);
        if(rnd == 0 && transform.position != pos1.position){
            transform.position = Vector3.Lerp(transform.position, pos1.position, t);
            t += Time.deltaTime * 0.001f;
        }else if(rnd == 1 && transform.position != pos2.position){
            transform.position = Vector3.Lerp(transform.position, pos2.position, t);
            t += Time.deltaTime * 0.001f;
        }*/
        if(health <= 0){
            //Destroy(gameObject);
            CentralGameScript.currentState = 80;
        }
        healthText.text = "Gigan: " + health;
    }

     void SpawnBulletOverTime(){
        StartCoroutine(SpawnBulletOverTimeRoutine());
        IEnumerator SpawnBulletOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(1);
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
                        GetComponent<AudioSource>().Play();
                        yield return new WaitForSeconds(2);
                        leftAttack.SetActive(false);
                        gsc.ChangeAnimationState("GiganIdle");
                    }else{
                        gsc.ChangeAnimationState("GiganRightAttack");
                        rightAttack.SetActive(true);
                        GetComponent<AudioSource>().Play();
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
            //obj.GetComponent<AudioSource>().Play();
            Destroy(obj.gameObject);
        }
     }
}
