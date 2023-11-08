using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] Transform attackPos;
    [SerializeField] LayerMask whatIsBuilding;
    [SerializeField] float attackRange;
    [SerializeField] int damage;
    [SerializeField] int footDamage;
    [SerializeField] LayerMask whatIsTank;
    [SerializeField] Transform footAttackPOS;
    [SerializeField] float footAttackRange;
    [SerializeField] LayerMask whatIsTutBuilding;

    void Awake(){
        damage = 5;
        footDamage = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Collider2D[] buildingsToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsBuilding);
            Collider2D[] tutBuildingsToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsTutBuilding);
                for (int i = 0; i < buildingsToDamage.Length; i++){
                    buildingsToDamage[i].GetComponent<BuildingHandler>().TakeDamage(damage);
                    buildingsToDamage[i].gameObject.GetComponent<AudioSource>().Play();
                }
                for (int i = 0; i < tutBuildingsToDamage.Length; i++){
                    tutBuildingsToDamage[i].GetComponent<TutorialBuildingHandler>().TakeDamage(damage);
                    tutBuildingsToDamage[i].gameObject.GetComponent<AudioSource>().Play();
                }
        }
        if(Input.GetKeyDown(KeyCode.V)){
            Collider2D[] tanksToDamage = Physics2D.OverlapCircleAll(footAttackPOS.position, footAttackRange, whatIsTank);
            Collider2D[] buildingsToDamage = Physics2D.OverlapCircleAll(footAttackPOS.position, footAttackRange, whatIsBuilding);
            Collider2D[] tutBuildingsToDamage = Physics2D.OverlapCircleAll(footAttackPOS.position, footAttackRange, whatIsTutBuilding);
            for (int i = 0; i < buildingsToDamage.Length; i++){
                buildingsToDamage[i].GetComponent<BuildingHandler>().TakeDamage(footDamage);
                buildingsToDamage[i].gameObject.GetComponent<AudioSource>().Play();
            }
            for (int i = 0; i < tanksToDamage.Length; i++){
                    tanksToDamage[i].GetComponent<TankHandler>().TakeDamage(footDamage);
            }
            for (int i = 0; i < tutBuildingsToDamage.Length; i++){
                    tutBuildingsToDamage[i].GetComponent<TutorialBuildingHandler>().TakeDamage(footDamage);
                    tutBuildingsToDamage[i].gameObject.GetComponent<AudioSource>().Play();
                }
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
        Gizmos.DrawWireSphere(footAttackPOS.position, footAttackRange);
    }
}
