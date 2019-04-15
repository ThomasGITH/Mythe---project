﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    public GameObject soul;
    float CurrentTime;
    float speed = -0.45f;

    void random_mess()
    {
        GameObject instance = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        instance.gameObject.GetComponent<Soul>().speed = speed;
    }

    void three_in_a_row()
    {
        Vector3 leftPos = soul.transform.position;
        leftPos.x = LanesManager.lanes[0].x;
        //leftPos.x = -11.5f;
        GameObject left = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        left.GetComponent<Soul>().auto_position = false;
        left.transform.position = leftPos;
        //left.GetComponent<Soul>().auto_color = false;
        //left.GetComponent<Renderer>().material.color = Color.red;
        left.gameObject.GetComponent<Soul>().speed = speed;

        Vector3 centerPos = soul.transform.position;
        centerPos.x = LanesManager.lanes[1].x;
       // centerPos.x = -10f;
        GameObject center = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        center.GetComponent<Soul>().auto_position = false;
        center.transform.position = centerPos;
        //center.GetComponent<Soul>().auto_color = false;
        //center.GetComponent<Renderer>().material.color = Color.green;
        center.gameObject.GetComponent<Soul>().speed = speed;

        Vector3 rightPos = soul.transform.position;
        rightPos.x = LanesManager.lanes[2].x;
        // rightPos.x = -8.5f;
        GameObject right = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        right.GetComponent<Soul>().auto_position = false;
        right.transform.position = rightPos;
        right.gameObject.GetComponent<Soul>().speed = speed;
        //right.GetComponent<Soul>().auto_color = false;
        //right.GetComponent<Renderer>().material.color = Color.blue;
    }

    void two_on_each_side()
    {
        Vector3 leftPos = soul.transform.position;
        leftPos.x = LanesManager.lanes[0].x;
        //leftPos.x = -11.5f;
        GameObject left = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        left.GetComponent<Soul>().auto_position = false;
        left.transform.position = leftPos;
        left.gameObject.GetComponent<Soul>().speed = speed;

        Vector3 rightPos = soul.transform.position;
       // rightPos.x = -8.5f;
        rightPos.x = LanesManager.lanes[2].x;
        GameObject right = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        right.GetComponent<Soul>().auto_position = false;
        right.transform.position = rightPos;
        right.gameObject.GetComponent<Soul>().speed = speed;
    }

    void two_left()
    {
        Vector3 leftPos = soul.transform.position;
        leftPos.x = LanesManager.lanes[0].x;
        //leftPos.x = -11.5f;
        GameObject left = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        left.GetComponent<Soul>().auto_position = false;
        left.transform.position = leftPos;
        left.gameObject.GetComponent<Soul>().speed = speed;

        Vector3 rightPos = soul.transform.position;
        rightPos.x = LanesManager.lanes[1].x;
        //rightPos.x = -10f;
        GameObject right = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        right.GetComponent<Soul>().auto_position = false;
        right.transform.position = rightPos;
        right.gameObject.GetComponent<Soul>().speed = speed;
    }

    void two_right()
    {
        Vector3 leftPos = soul.transform.position;
        leftPos.x = LanesManager.lanes[1].x;
        // leftPos.x = -10f;
        GameObject left = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        left.GetComponent<Soul>().auto_position = false;
        left.transform.position = leftPos;
        left.gameObject.GetComponent<Soul>().speed = speed;

        Vector3 rightPos = soul.transform.position;
        rightPos.x = LanesManager.lanes[2].x;
        //rightPos.x = -8.5f;
        GameObject right = Instantiate(soul, soul.transform.position, soul.transform.rotation);
        right.GetComponent<Soul>().auto_position = false;
        right.transform.position = rightPos;
        right.gameObject.GetComponent<Soul>().speed = speed;
    }

    void Update()
    {
        CurrentTime += Time.deltaTime;

        speed = speed > -0.45f ? speed - 0.0001f : speed;
        RoadMovement.speed = speed;

        print("Soulspeed: " + speed);
        
        if (CurrentTime > 0.75f)
        {
            CurrentTime = 0;
       
            switch(Random.Range(0, 12))
            {
                case 1:
                    two_on_each_side();
                    break;
                case 2:
                    three_in_a_row();
                    break;
                case 3:
                    two_left();
                    break;
                case 4:
                    two_left();
                    break;
                case 5:
                    two_right();
                    break;
                case 6:
                    two_right();
                    break;
                default:
                    random_mess();
                    break;
            }
        }
    }
}