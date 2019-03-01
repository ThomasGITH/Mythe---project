﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    private GameObject road1, road2;
    private Vector3 spawnPosition;

    void Awake()
    {
        road1 = transform.GetChild(0).gameObject;
        road2 = transform.GetChild(1).gameObject;
        spawnPosition = road2.transform.position;
    }

    void Update()
    {
        Vector3 pos1 = road1.transform.position;
        Vector3 pos2 = road2.transform.position;
        
        pos1.z = pos1.z <= -245.0f ? pos2.z + road2.transform.localScale.z - 1 : pos1.z - 1;
        pos2.z = pos2.z <= -245.0f ? pos1.z + road2.transform.localScale.z - 1 : pos2.z - 1;

        road1.transform.position = pos1;
        road2.transform.position = pos2;
    }
}