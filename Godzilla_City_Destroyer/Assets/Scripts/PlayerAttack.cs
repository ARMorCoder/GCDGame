using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    [SerializeField] float startTimeBtwAttack;
    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask whatIsBuilding;
    [SerializeField] float attackRange;
    [SerializeField] int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(timeBtwAttack <= 0){
            if(Input.GetKey(KeyCode.Space)){
                Collider2D[] buildingsToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsBuilding);
                for (int i = 0; i < buildingsToDamage.Length; i++){
                    buildingsToDamage[i].GetComponent<BuildingHandler>().TakeDamage(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }else{
            timeBtwAttack = Time.deltaTime;
        }*/

        if(Input.GetKeyDown(KeyCode.Space)){
            Collider2D[] buildingsToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsBuilding);
                for (int i = 0; i < buildingsToDamage.Length; i++){
                    buildingsToDamage[i].GetComponent<BuildingHandler>().TakeDamage(damage);
                    buildingsToDamage[i].gameObject.GetComponent<AudioSource>().Play();
                }
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
