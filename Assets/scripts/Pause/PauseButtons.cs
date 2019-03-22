using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//Brandon Ruigrok
public class PauseButtons : MonoBehaviour
{
    string Menu = "Menu";

    public void ResumeButton()
    {
        gameObject.GetComponentInParent<Pause>().Resumed();
    }

    public void PauseButton()
    {
        gameObject.GetComponentInParent<Pause>().Paused();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Menu);
    }
}
