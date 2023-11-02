using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energySpawnerBoss : MonoBehaviour
{
   [SerializeField] GameObject energyPrefab;
   [SerializeField] GameObject healthPrefab;
   [SerializeField] GameObject armorPrefab;
   
   GameObject powerUpPrefab;
    void Start(){
        SpawnPointOverTime();

    }
    void SpawnPointOverTime(){
         StartCoroutine(SpawnPointOverTimeRoutine());
        IEnumerator SpawnPointOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(15);
                int rnd = Random.Range(0,20);
                if(rnd % 3 == 0){
                    powerUpPrefab = energyPrefab;
                }else if(rnd % 3 == 1){
                    powerUpPrefab = healthPrefab;
                }else if(rnd % 3 == 2){
                    powerUpPrefab = armorPrefab;
                }
                GameObject newEnergy = Instantiate(powerUpPrefab,new Vector3(Random.Range(-5,5),-4,0),Quaternion.identity);
                Destroy(newEnergy, 3);
            }
            yield return null;       
    }

    }
}
