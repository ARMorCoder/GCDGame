using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHandler : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] Transform shooter;
    public Transform target;
    [SerializeField] int health;
    Vector3 shootPos = new Vector3(0,0,0);
    Vector3 tarPos = new Vector3(0, 0, 0);
    public float t = 0;
    public TotalPoints pointsInfo;
    bool belowDamage = false;
    [SerializeField] GameObject damageEffect;

    void Start()
    {
        SpawnBulletOverTime();
    }

    void Awake(){
        health = 25;
    }

    void Update(){
        shootPos = new Vector3(shooter.position.x, shooter.position.y, 0);
        tarPos = new Vector3(target.position.x, target.position.y, 0);
        if(health <= 10 && belowDamage != true){
            damageEffect.SetActive(true);
            belowDamage = true;
        }
        if(health <= 0){
            pointsHandler.singleton.addPoints(10);
            pointsInfo.points += 10;
            Destroy(damageEffect.gameObject);
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

    public void TakeDamage(int damage){
        health -= damage;
        Debug.Log("damage was taken to tank");
    }
}
