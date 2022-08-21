using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool lockEnemy;
    public float timer;
    public List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
            Invoke("SpawnEnemy", timer);
        
    }

    public void SpawnEnemy() {
        if(!lockEnemy) {
            Instantiate(enemies[0], transform.position, transform.rotation);
            Invoke("SpawnEnemy", timer);
            
            //Invoke("SpawnEnemy", timer);
        }
    }
}
