using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    [SerializeField] float speed = 5f;

    public void Throw(Vector3 tP){
        Rigidbody2D newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        tP.z = 0;
        newProjectileRB.velocity = (tP - transform.position).normalized * speed;
        //newProjectileRB.velocity = new Vector3 (0,-5,0);
    }
}
