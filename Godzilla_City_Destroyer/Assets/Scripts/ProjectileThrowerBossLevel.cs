using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrowerBossLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;

    void Start(){
        //temp = Instantiate(projectilePrefab);
    }

    public void Throw(){
        Rigidbody2D newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        newProjectileRB.velocity = new Vector3 (0,5,0);
        Destroy(newProjectileRB.gameObject, 5);

    }
}
