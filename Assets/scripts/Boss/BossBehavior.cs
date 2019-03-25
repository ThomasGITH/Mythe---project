using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{

    private Vector3 bossPosition = new Vector3(-10, -30, -30);
    private Vector3 spawningBossPosition = new Vector3(-10, -30, 255);
    [SerializeField]
    private bool bossIsActive = false;
    private bool bossIsInPosition = false;
    private GameObject spawningBossObject;
    [SerializeField]
    private GameObject boss;
    private float bossFlyingSpeed =  35;
    private float bossWaitingSpawnTimeSeconds = 5;
    private SoulSpawner soulSpawner;

    void Start()
    {
        spawningBossObject = Resources.Load("Portal") as GameObject;
        soulSpawner = GameObject.FindWithTag("SoulSpawner").GetComponent<SoulSpawner>();
        soulSpawner.enabled = false;
    }

    
    void Update()
    {
        // Check if boss is alive
        if (bossIsActive == false)
        {
            StartCoroutine(BossSpawning());
            bossIsActive = true;
        }

        if (boss != null)
        {

            // Check if souls can be spawned
            if (boss.transform.position == bossPosition)
            {
                soulSpawner.enabled = true;
            }

            // Make boss move to position
            if (boss.transform.position != spawningBossPosition)
            {
                boss.transform.position = Vector3.MoveTowards(boss.transform.position, bossPosition, bossFlyingSpeed * Time.deltaTime);
                //print(boss.transform.position);
            }
        }
       
    }


    //Wait for boss spawning and spawns it
    IEnumerator BossSpawning()
    {
        bossIsActive = true;
        yield return new WaitForSeconds(bossWaitingSpawnTimeSeconds);
        Instantiate(spawningBossObject, spawningBossPosition, Quaternion.identity);
        boss = GameObject.FindWithTag("Portal");
        boss.transform.position = new Vector3(boss.transform.position.x, boss.transform.position.y, boss.transform.position.z - 10);
    }
}
