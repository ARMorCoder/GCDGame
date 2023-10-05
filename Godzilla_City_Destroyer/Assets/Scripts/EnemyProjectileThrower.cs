using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileThrower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    [SerializeField] float speed = 5f;

    public void Throw(Vector3 tP){
        Rigidbody2D newEnemyProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        tP.z = 0;
        newEnemyProjectile.velocity = (tP - transform.position).normalized * speed;
        Destroy(newEnemyProjectile.gameObject, 3);
    }
}
