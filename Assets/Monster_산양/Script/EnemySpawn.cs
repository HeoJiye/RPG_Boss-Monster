using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int maxCount;
    public int enemyCount;
    public float spawnTime;
    public float curTime;
    public bool[] isSpawn;
    public Transform[] spawnPoints;
    public GameObject enemy;
    public GameObject player;

    public static EnemySpawn _instance;

    void Awake()
    {
        // 초기 설정
        _instance = this;
        enemyCount = 0;
        isSpawn = new bool[spawnPoints.Length];

        // 스폰 여부 초기화
        for(int i = 0; i < isSpawn.Length; i++)
            isSpawn[i] = false;
    }

    void Update()
    {
        // 스폰 시간이 되면 스폰 함수 호출
        if(curTime >= spawnTime && enemyCount < maxCount)
        {
            int x = Random.Range(0, spawnPoints.Length);
            if(!isSpawn[x])
                SpawnEnemy(x);
        }
        curTime += Time.deltaTime;
    }

    void SpawnEnemy(int x)
    {
        curTime = 0;
        enemyCount++;

        //player : enemy가 발견하면 쫓아올 플레이어 객체
        EnemyMove em = enemy.GetComponent<EnemyMove>();
        em.player = player;
        em.index = x;

        // 지정된 위치에 몬스터 스폰                
        Instantiate(enemy, spawnPoints[x]);
        isSpawn[x] = true;
    }
}
