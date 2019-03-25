﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{

    private Vector3 bossPosition = new Vector3(-9.59f, -30, -30);
    private Vector3 spawningBossPosition = new Vector3(-10, -30, 255);
    private Vector3 bossDeadPosition = new Vector3(-10, -30, -75);
    private Vector3 bossHpPosition = new Vector3(0, 0, 0);
    private bool bossIsActive = false;
    private bool bossIsInPosition = false;
    private bool canSpawnOtherBoss = false;
    private GameObject spawningBossObject;
    private GameObject boss;
    private float bossFlyingSpeed = 35;
    private float bossWaitingSpawnTimeSeconds = 5;
    private SoulSpawner soulSpawner;
    private int bossFirstTime = 1;
    private bool bossJustDied = false;
    private GameObject spawningBossHp;
    private GameObject bossHp;

    void Start()
    {
        spawningBossObject = Resources.Load("Portal") as GameObject;
        spawningBossHp = Resources.Load("BossHpBackground") as GameObject;
        soulSpawner = GameObject.FindWithTag("SoulSpawner").GetComponent<SoulSpawner>();
        soulSpawner.enabled = false;
    }

    void Update()
    {
        // Check if boss is alive
        if (bossIsActive == false)
        {
            StartCoroutine(BossSpawning());
            canSpawnOtherBoss = false;
            bossIsActive = true;
        }

        if (boss != null)
        {
            // Check if souls can be spawned
            if (boss.transform.position == bossPosition && bossJustDied == false)
            {
                soulSpawner.enabled = true;
            }

            // Make boss move to position
            if (boss.transform.position != bossPosition && bossJustDied == false)
            {
                boss.transform.position = Vector3.MoveTowards(boss.transform.position, bossPosition, bossFlyingSpeed * Time.deltaTime);

            }

            if (bossJustDied == true)
            {
                boss.transform.position = Vector3.MoveTowards(boss.transform.position, bossDeadPosition, bossFlyingSpeed * Time.deltaTime);
            }

            if (boss.transform.position == bossDeadPosition)
            {
                bossJustDied = false;
                Destroy(boss);
                Destroy(bossHp);
            }
        }

        if (boss == null)
        {
            if (canSpawnOtherBoss == true)
            {
                soulSpawner.enabled = false;
                bossIsActive = false;

            }
        }


    }

    public void BossDied()
    {
        bossJustDied = true;
    }


    //Wait for boss spawning and spawns it
    IEnumerator BossSpawning()
    {
        if (bossFirstTime != 1)
        {
            yield return new WaitForSeconds(bossWaitingSpawnTimeSeconds);
        }
        else
        {
            bossFirstTime += 1;
        }
        yield return new WaitForSeconds(bossWaitingSpawnTimeSeconds);
        Instantiate(spawningBossObject, spawningBossPosition, Quaternion.identity);
        bossHp = Instantiate(spawningBossHp, bossHpPosition, Quaternion.identity);
        bossHp.transform.SetParent(GameObject.FindWithTag("UI").transform);
        boss = GameObject.FindWithTag("Portal");
        canSpawnOtherBoss = true;
    }
}
