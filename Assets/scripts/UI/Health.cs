using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    int Lives = 3;
    int Counter = 0;
    bool Dead = false;

    public int AmountOfSouls = 0;
    int MaxAmountOfSouls = 10;

    //Lives visual
    public GameObject H1, H2, H3;

    private void Start()
    {
        changeCape();
    }

    void changeCape()
    {
        int rndom = Random.Range(0, 3);
        Color col = Color.white;
        switch (rndom)
        {
            case 0:
                col = Color.red;
                break;
            case 1:
                col = Color.green;
                break;
            case 2:
                col = Color.blue;
                break;
        }

        GetComponent<Renderer>().material.color = col;
    }

    //Statements for the collider, If you're hit, you get X amount of invincibility frames
    private void OnTriggerEnter(Collider col)
    {
        //If the Player object collides with an object with that "Wrong soul" tag, it takes a life off, and starts the invincibility frames.

        /*
        if (col.gameObject.tag == "Wrong Soul" && Counter == 0)
        {
            Lives--;
            Counter = 120;
        }
        */

        Color color = GetComponent<Renderer>().material.color;
        Color soulColor = col.GetComponent<Renderer>().material.color;
        if(col.gameObject.tag == "Soul")
        {
            if ((color != soulColor) && (Counter == 0))
            {
                Lives--;
                Counter = 120;
                AmountOfSouls = 0;
            }
            else
            {
                AmountOfSouls++;
            }
            Destroy(col.gameObject);
        }
    }

    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Where invincibility frames get handled
        if (Counter > 0)
        {
            Counter--;
        }

        H1.SetActive(Lives >= 1);
        H2.SetActive(Lives >= 2);
        H3.SetActive(Lives == 3);

        if (Lives == 0)
        {
            Dead = true;
        }

        if(timer >= 7)
        {
            changeCape();
            timer = 0;
        }
        
        GameObject.Find("SoulScore").GetComponent<Text>().text = "" + AmountOfSouls;

        //Makes sure that the collected souls cap out at 10
        AmountOfSouls = AmountOfSouls >= MaxAmountOfSouls ? MaxAmountOfSouls : AmountOfSouls;
    }
}
