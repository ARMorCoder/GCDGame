using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOHandler : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] Transform shooter;
    public Transform target;
    [SerializeField] int health;
    Vector3 shootPos = new Vector3(0,0,0);
    Vector3 tarPos = new Vector3(0, 0, 0);
    int rnd = 0;
    public float t = 0;
    void Start()
    {
        bullet.GetComponent<SpriteRenderer>().color = Color.green;
        SpawnBulletOverTime();
    }

    void Awake(){
        health = 10;
    }

    void Update(){
        shootPos = new Vector3(shooter.position.x, shooter.position.y, 0);
        tarPos = new Vector3(target.position.x, target.position.y, 0);
        if(health <= 0){
            Destroy(gameObject);
        }
    }
     void SpawnBulletOverTime(){
        StartCoroutine(SpawnBulletOverTimeRoutine());
        IEnumerator SpawnBulletOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(2);
                Rigidbody2D newBullet = Instantiate(bullet,transform.position,Quaternion.identity).GetComponent<Rigidbody2D>();
                tarPos.z = 0;
                newBullet.velocity = (tarPos- transform.position).normalized * 10;
                Destroy(newBullet.gameObject, 2);
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
