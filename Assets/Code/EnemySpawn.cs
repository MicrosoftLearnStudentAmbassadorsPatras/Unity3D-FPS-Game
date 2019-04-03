using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 rndPositon;

    public float frequency;
    public float spawnRadius;

    // Use this for initialization
    void Start()
    {
        rndPositon = new Vector3();
        Invoke("Spawn", Random.Range(frequency + 0.5f, frequency + 2f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        float rand1 = Random.Range(-(spawnRadius / 2), (spawnRadius/2));
        float rand2 = Random.Range(-(spawnRadius / 2), (spawnRadius / 2));

        rndPositon.Set(this.transform.position.x + rand1, this.transform.position.y, this.transform.position.z + rand2);

        Instantiate(enemy, rndPositon, Quaternion.Euler(Random.Range(0, 10), 0, Random.Range(0, 10)));

        Invoke("Spawn", Random.Range(frequency + 0.5f, frequency + 2f));
    }
}
