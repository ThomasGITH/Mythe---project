using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    public GameObject soul;

    float CurrentTime;

    void random_mess()
    {

    }

    void three_in_a_row()
    {

    }

    void two_after_each_other()
    {

    }

    void two_on_each_side()
    {

    }

    void Update()
    {
        CurrentTime += Time.deltaTime;

        if(CurrentTime > 0.5f)
        {
            CurrentTime = 0;
            Instantiate(soul, soul.transform.position, soul.transform.rotation);
        }
    }
}