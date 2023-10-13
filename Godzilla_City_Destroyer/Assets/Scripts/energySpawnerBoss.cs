using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energySpawnerBoss : MonoBehaviour
{
    [SerializeField] GameObject energyPrefab;

    void Start(){
        SpawnPointOverTime();

    }
    void SpawnPointOverTime(){
         StartCoroutine(SpawnPointOverTimeRoutine());
        IEnumerator SpawnPointOverTimeRoutine(){
            while(true){
                yield return new WaitForSeconds(15);
                GameObject newEnergy = Instantiate(energyPrefab,new Vector3(Random.Range(-5,5),-4,0),Quaternion.identity);
                //Destroy(newEnergy, 3);
            }
            yield return null;       
    }

    }
}
