using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
   [SerializeField] GameObject ufoPrefab;
   [SerializeField] Transform Location1;
   [SerializeField] Transform Location2;
   [SerializeField] Transform Location3;
   //[SerializeField] UFOHandler create;
   //[SerializeField] AIChase create2;
   public GameObject player;
   Transform newLocate;
    void Start(){
        SpawnObstacleOverTime();

    }

    void SpawnObstacleOverTime(){
         StartCoroutine(SpawnObstacleOverTimeRoutine());
        IEnumerator SpawnObstacleOverTimeRoutine(){
            while(true){
                int rnd = Random.Range(0,20);
                if(rnd % 3 == 0){
                    newLocate = Location1;
                }else if(rnd % 3 == 1){
                    newLocate = Location2;
                }else if(rnd % 3 == 2){
                    newLocate = Location3;
                }

                //GameObject newUFO = Instantiate(ufoPrefab,new Vector3(Random.Range(-5,5),Random.Range(9,10),0),Quaternion.identity);
                //GameObject newUFO = Instantiate(ufoPrefab, new Vector3(Location1.position.x, Location1.position.y, 0), Quaternion.identity);
                GameObject newUFO = Instantiate(ufoPrefab, new Vector3(newLocate.position.x, newLocate.position.y, 0), Quaternion.identity);
                newUFO.GetComponent<UFOHandler>().target = player.transform;
                newUFO.GetComponent<AIChase>().player = player;
                //create.target = player.transform;
                yield return new WaitForSeconds(25);
            }
            yield return null;
        }
    }
}
