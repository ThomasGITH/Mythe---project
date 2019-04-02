using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject cube;
    public GameObject[] objs;



    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            objs[i] = Instantiate(cube, transform);//2.56
            objs[i].transform.position += new Vector3(0f, 0f,i*5f);
        }

    }

}








