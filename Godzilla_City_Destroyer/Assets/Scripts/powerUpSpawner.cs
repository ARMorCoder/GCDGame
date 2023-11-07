using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpSpawner : MonoBehaviour
{
   [SerializeField] GameObject energyPrefab;
   [SerializeField] GameObject healthPrefab;
   [SerializeField] GameObject armorPrefab;
   GameObject powerUpPrefab;
    void Start(){
        SpawnObstacleOverTime();
    }

    void SpawnObstacleOverTime(){
         StartCoroutine(SpawnObstacleOverTimeRoutine());
        IEnumerator SpawnObstacleOverTimeRoutine(){
            while(true){
                int rnd = Random.Range(0,20);
                if(rnd % 3 == 0){
                    powerUpPrefab = energyPrefab;
                }else if(rnd % 3 == 1){
                    powerUpPrefab = healthPrefab;
                }else if(rnd % 3 == 2){
                    powerUpPrefab = armorPrefab;
                }
                GameObject newPowerUp = Instantiate(powerUpPrefab,new Vector3(Random.Range(-65,40),Random.Range(7,-111),0),Quaternion.identity);
                yield return new WaitForSeconds(30);
            }
            yield return null;
        }
    }
}
