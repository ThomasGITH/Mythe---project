﻿using System.Collections;
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
    [SerializeField]
    private RawImage ChangeColor;
    public CamShake camShaking; 

    private void Start()
    {
        changeCape();
        camShaking = GameObject.FindWithTag("MainCamera").GetComponent<CamShake>(); 
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

    int colCount = 0;

    //Statements for the collider, If you're hit, you get X amount of invincibility frames
    private void OnTriggerEnter(Collider col)
    {
        //If the Player object collides with an object with that "Wrong soul" tag, it takes a life off, and starts the invincibility frames.
        Color color = currentColor;
        Color soulColor = col.GetComponent<Renderer>().material.color;
        if(col.gameObject.tag == "Soul")
        {
            if ((color != soulColor))
            {
                Lives--;
                Counter = 120;
                AmountOfSouls = 0;
                camShaking.Shake(0.1f, 0.5f);

                colCount++;

            }
            else
            {
                AmountOfSouls++;
            }
            Destroy(col.gameObject);
        }
    }

    float timer;
    public Color currentColor;
    bool flashUp = true;

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

        if (timer > 7)
        {
            Color col = GetComponent<Renderer>().material.color;
            float r = currentColor.r / 10;
            float g = currentColor.g / 10;
            float b = currentColor.b / 10;

            if (col.r >= 1 && col.g >= 1 && col.b >= 1)
            {
                flashUp = false;
            }
            else if(col.r <= currentColor.r && col.g <= currentColor.g && col.b <= currentColor.b)
            {
                flashUp = true;
            }

            if(flashUp)
            {
                GetComponent<Renderer>().material.color = new Color(col.r + 0.05f, col.g + 0.05f, col.b + 0.05f);
            }
            else
            {
                GetComponent<Renderer>().material.color = new Color(col.r - 0.05f, col.g - 0.05f, col.b - 0.05f);
            }

            if (timer > 10 && col.r <= currentColor.r && col.g <= currentColor.g && col.b <= currentColor.b)
            {
                changeCape();
                timer = 0;
            }
        }
        else
        {
            currentColor = GetComponent<Renderer>().material.color;
        }

        //Makes sure that the collected souls cap out at 10
        AmountOfSouls = AmountOfSouls >= MaxAmountOfSouls ? MaxAmountOfSouls : AmountOfSouls;

        GameObject.Find("SoulScore").GetComponent<Text>().text = "" + AmountOfSouls;
        ChangeColor.color = GetComponent<Renderer>().material.color;
    }
}
