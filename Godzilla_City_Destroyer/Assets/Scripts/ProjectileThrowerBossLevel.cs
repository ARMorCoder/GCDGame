using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrowerBossLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;

    List<Rigidbody2D> pool;

    void Start(){
        //temp = Instantiate(projectilePrefab);
        pool = new List<Rigidbody2D>();
    }

    public void Throw(){
        Rigidbody2D newProjectileRB;
        AudioSource audio;

        if(pool.Count >= 6){
            if(pool[0] == null){
                pool.RemoveAt(0);
                newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            }else{
                pool.RemoveAt(0);
                newProjectileRB = pool[0];
                newProjectileRB.transform.position = transform.position;
                audio = newProjectileRB.GetComponent<AudioSource>();
                audio.Play();
            }
        }else{
            newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        }
        pool.Add(newProjectileRB);
        newProjectileRB.velocity = new Vector3 (0,5,0);
        //Destroy(newProjectileRB.gameObject, 5);

    }
}
