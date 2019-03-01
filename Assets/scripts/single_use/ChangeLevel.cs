using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{

    private GameObject[] list;
    private GameObject cam;
    private byte level = 0;

    private void Start()
    {
        list = new GameObject[2];
        for(int i = 0; i < transform.childCount; i++)
        {
            list[i] = transform.GetChild(i).gameObject;
        }

        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(list[level]);
            level++;
            list[level].SetActive(true);
            cam.transform.position = new Vector3(cam.transform.position.x + 630, cam.transform.position.y, cam.transform.position.z);
        }
    }
}
