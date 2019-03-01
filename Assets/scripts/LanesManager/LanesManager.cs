using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesManager : MonoBehaviour
{
    public List<Vector3> lanes = new List<Vector3>();


    void Awake()
    {

        // Adding Lanes Left / Middle / Right;
        lanes.Add(new Vector3(-11.5f, -30, -69));
        lanes.Add(new Vector3(-10, -30, -69));
        lanes.Add(new Vector3(-8.5f, -30, -69));

    }

    void Update()
    {
        
    }

  
}
