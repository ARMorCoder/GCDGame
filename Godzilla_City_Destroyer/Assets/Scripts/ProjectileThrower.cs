using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    [SerializeField] float speed = 5f;

    List<Rigidbody2D> pool;

    void Start(){
        //temp = Instantiate(projectilePrefab);
        pool = new List<Rigidbody2D>();
    }

    public void Throw(Vector3 tP){
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
        tP.z = 0;
        newProjectileRB.velocity = (tP - transform.position).normalized * speed;
        //newProjectileRB.velocity = new Vector3 (0,-5,0);
        //Destroy(newProjectileRB.gameObject, 2);

    }
}
