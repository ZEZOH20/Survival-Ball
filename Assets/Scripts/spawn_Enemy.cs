using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_Enemy : MonoBehaviour
{
    public GameObject prefab,PowerUp_prefab;
    public int enemyLiveCount,c=1;
    void Start()
    {
        Instantiate(prefab, RandomPos(), prefab.transform.rotation);

    }
     void Update()
    {
        enemyLiveCount = FindObjectsOfType<Enemy>().Length;
        if (enemyLiveCount == 0)
        {
            c++;
            spawnEnemy(c);
            Instantiate(PowerUp_prefab, RandomPos(), PowerUp_prefab.transform.rotation);
        }

    }
    void spawnEnemy(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(prefab, RandomPos(), prefab.transform.rotation);
            
        }
    }

    public Vector3 RandomPos()
    {
        float spawnPosx = 9;
        float Randomx = Random.Range(spawnPosx, -spawnPosx);
        float Randomz = Random.Range(spawnPosx, -spawnPosx);

        Vector3 enemyPos = new Vector3(Randomx,0, Randomz);

        return enemyPos;
    } 
}
