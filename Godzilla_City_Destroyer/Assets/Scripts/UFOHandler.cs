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
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    int rnd = 0;
    public float t = 0;
    void Start()
    {
        transform.position = pos2.position;
        SpawnBulletOverTime();
        MoveAroundOverTime();
    }

    void Awake(){
        health = 10;
    }

    void Update(){
        shootPos = new Vector3(shooter.position.x, shooter.position.y, 0);
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
            Destroy(gameObject);
        }
    }

   void MoveAroundOverTime(){
        StartCoroutine(MoveAroundOverTimeRoutine());
        IEnumerator MoveAroundOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(3);
                rnd = Random.Range(0,10);
                Debug.Log("Random is " + rnd);
                if(rnd % 2 == 0){
                    Debug.Log("I am moving to pos1");
                    transform.position = Vector3.Lerp(transform.position, pos1.position, t);
                    t += Time.deltaTime * 10f;
                }else{
                    Debug.Log("I am moving to pos2");
                    transform.position = Vector3.Lerp(transform.position, pos2.position, t);
                    t += Time.deltaTime * 10f;
                }
            }
            yield return null;
        }
    }

     void SpawnBulletOverTime(){
        StartCoroutine(SpawnBulletOverTimeRoutine());
        IEnumerator SpawnBulletOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(2);
                Rigidbody2D newBullet = Instantiate(bullet,transform.position,Quaternion.identity).GetComponent<Rigidbody2D>();
                tarPos.z = 0;
                newBullet.velocity = (tarPos - transform.position);
                Destroy(newBullet.gameObject, 3);
            }

            yield return null;
            
         }
     }

     public void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "FriendlyBullet"){
            Debug.Log("I've hit an enemy!");
            health--;

            Destroy(obj.gameObject);
        }
     }
}
