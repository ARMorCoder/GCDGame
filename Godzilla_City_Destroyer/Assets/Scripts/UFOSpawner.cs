using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
   [SerializeField] GameObject ufoPrefab;
   //[SerializeField] UFOHandler create;
   //[SerializeField] AIChase create2;
   public GameObject player;
    void Start(){
        SpawnObstacleOverTime();

    }

    void SpawnObstacleOverTime(){
         StartCoroutine(SpawnObstacleOverTimeRoutine());
        IEnumerator SpawnObstacleOverTimeRoutine(){
            while(true){
                GameObject newUFO = Instantiate(ufoPrefab,new Vector3(Random.Range(-5,5),Random.Range(9,10),0),Quaternion.identity);
                newUFO.GetComponent<UFOHandler>().target = player.transform;
                newUFO.GetComponent<AIChase>().player = player;
                //create.target = player.transform;
                yield return new WaitForSeconds(20);
            }
            yield return null;
        }
    }
}
