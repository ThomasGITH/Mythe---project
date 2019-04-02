using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Brandon Ruigrok
public class GameOver : MonoBehaviour
{
    GameObject DeathScreen;

    private bool Dead;
    private Pause Pauser;
    private Health Checker;

    // Start is called before the first frame update
    void Start()
    {
        DeathScreen = this.gameObject.transform.GetChild(0).gameObject;
        Checker = GameObject.Find("Player").GetComponent<Health>();
        Pauser = GameObject.Find("Pause").GetComponent<Pause>();
        Dead = Checker.Dead;
    }

    // Update is called once per frame
    void Update()
    {
        Dead = Checker.Dead;
        if (Dead == true)
        {
            DeathScreen.SetActive(true);
            Pauser.Paused();
        }
    }
}
