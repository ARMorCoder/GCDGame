using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOHandler : MonoBehaviour
{
    public GameObject bullet;
    //EnemyProjectileThrower pT;
    [SerializeField] Transform shooter;
    [SerializeField] Transform target;
    [SerializeField] int health;
    Vector3 shootPos = new Vector3(0,0,0);
    Vector3 tarPos = new Vector3(0, 0, 0);
    void Start()
    {
       SpawnBulletOverTime();
       //MoveAroundOverTime();
    }

    void Awake(){
        health = 10;
    }

    void Update(){
        shootPos = new Vector3(shooter.position.x, shooter.position.y, 0);
        tarPos = new Vector3(target.position.x, target.position.y, 0);
    }

   /* void MoveAroundOverTime(){
        StartCoroutine(MoveAroundOverTimeRoutine());
        IEnumerator MoveAroundOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(5);
                transform.position.velocity = (10, 0, 0);
                yield return new WaitForSeconds(5);
                transform.position.velocity = (-10, 0, 0);

            }
            yield return null;
        }
    }*/

     void SpawnBulletOverTime(){
        StartCoroutine(SpawnBulletOverTimeRoutine());
        IEnumerator SpawnBulletOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(2);
                Rigidbody2D newBullet = Instantiate(bullet,transform.position,Quaternion.identity).GetComponent<Rigidbody2D>();
                tarPos.z = 0;
                newBullet.velocity = (tarPos - transform.position);
                Object.Destroy(GetComponent<Rigidbody2D>(), 3);
            }

            yield return null;
            
         }
     }

     public void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "FriendlyBullet"){
            Debug.Log("I've hit an enemy!");
            health--;
        }
     }
}
