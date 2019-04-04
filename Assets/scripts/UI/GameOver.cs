﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Brandon Ruigrok
public class GameOver : MonoBehaviour
{
    public GameObject DeathScreen;

    public bool Dead;
    public int ScoreCounter = 0;
    public Text ScoreDisplay;
    private Pause Pauser;
    private Health Checker;

    // Start is called before the first frame update
    void Start()
    {
        Checker = GameObject.Find("Player").GetComponent<Health>();
        Pauser = GameObject.Find("Pause").GetComponent<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        Dead = Checker.Dead; //Checks to see if the player died.
        if (Dead == true)
        {
            DeathScreen.SetActive(true);
            Pauser.DeadPaused();
        }

        else if (!Dead)
        {
            ScoreCounter = ScoreCounter + 1;
            ScoreDisplay.text = ScoreCounter.ToString();
        }
    }
}
