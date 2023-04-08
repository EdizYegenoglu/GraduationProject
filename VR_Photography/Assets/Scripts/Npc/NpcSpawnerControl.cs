using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnerControl : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] npcs;
    int randomSpawnPoint, randomNpc;
    public static bool spawnAllowed;
    public int delay;


    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating ("SpawnANpc", 0f, 5f);
    }

    void SpawnANpc()
    {
        if (spawnAllowed) {
            randomSpawnPoint = Random.Range (0, spawnPoints.Length);
            randomNpc = Random.Range (0, npcs.Length);
            Instantiate (npcs [randomNpc], spawnPoints [randomSpawnPoint].position, Quaternion.identity);
            StartCoroutine(TimedDelay());

        }
    }

    IEnumerator TimedDelay(){
        delay = 180;
        yield return new WaitForSeconds(delay);
        spawnAllowed = false;
    }
}
