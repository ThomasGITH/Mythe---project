using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{

    float[] lanePositions;
    public bool auto_position = true, auto_color = true;

    public enum Col
    {
        RED, GREEN, BLUE
    }

    void Start()
    {
        if (auto_color)
        {
            Col color = (Col)Random.Range(0, 3);
            Color col = Color.white;

            switch (color)
            {
                case Col.RED:
                    col = Color.red;
                    break;
                case Col.GREEN:
                    col = Color.green;
                    break;
                case Col.BLUE:
                    col = Color.blue;
                    break;
            }
            GetComponent<Renderer>().material.color = col;
        }

        if(auto_position)
        {
            lanePositions = new float[3];

            for (int i = 0; i < 3; i++)
            {
                lanePositions[i] = LanesManager.lanes[i].x;
            }

            transform.position = new Vector3(lanePositions[Random.Range(0, 3)], transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        transform.Translate(0,0,-0.55f);

        if(transform.position.z < -75)
        {
            Destroy(gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
