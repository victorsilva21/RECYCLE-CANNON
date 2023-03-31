using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    Vector3 spawnAreaMin, spawnAreaMax, minInWorld, maxInWorld;
    private EnemyType enemyType;
    [SerializeField]float m_spawnTime;    
    [SerializeField]GameObject m_targetObject;
    private bool bossTime = false;
    public bool BossTime
    {
        get{return bossTime;}
        set{bossTime = value;}
    }
    public float m_SpawnTime
    {
        get{return m_spawnTime;}
        set{m_spawnTime = value;}
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnAreaMin = new Vector3(Screen.safeArea.xMin,Screen.safeArea.yMin,0);
        spawnAreaMax = new Vector3(Screen.safeArea.xMax,Screen.safeArea.yMax,0);

        minInWorld = Camera.main.ScreenToWorldPoint(spawnAreaMin);
        maxInWorld = Camera.main.ScreenToWorldPoint(spawnAreaMax);        
        StartCoroutine(Spawner());
        


    }
    public void SpawnerActivator()
    {
       StartCoroutine(Spawner()); 
    }

    // Update is called once per frame
    IEnumerator Spawner()
    {
        
            yield return new WaitForSeconds(5);
            GameObject enemyInstance = Instantiate(m_targetObject, new Vector3(Random.Range(minInWorld.x, maxInWorld.x), transform.position.y, Camera.main.orthographicSize - (Camera.main.orthographicSize / 3)), Quaternion.identity);
            enemyType = enemyInstance.GetComponent<EnemyType>();
            int typePercentage = Random.Range(0, 100);
            if (typePercentage <= 50 && bossTime == false) enemyType.M_type = "EnemyOrganic";
            if (typePercentage > 50 && typePercentage <= 75 && bossTime == false) enemyType.M_type = "EnemyMetal";
            if (typePercentage > 75 && bossTime == false) enemyType.M_type = "EnemyPlastic";
            if (bossTime == true) enemyType.M_type = "EnemyBoss";
            yield return new WaitForSeconds(m_spawnTime);
            if(enemyType.M_type != "EnemyBoss")StartCoroutine(Spawner());
            

        
        
            

        
        
    }
}
