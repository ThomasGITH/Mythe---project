using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMovement : MonoBehaviour
{
    private LanesManager Lanes;
    private GameObject player;
    private int playerLane = 1;
    private float playerStep = 10;

    List<Vector3> playerLanes = new List<Vector3>();

    void Start()
    {
        //Get player / Get Positions & Set position 
        player = GameObject.Find("Player");
        Lanes = player.GetComponent<LanesManager>();
        playerLanes = LanesManager.lanes;
        player.transform.position = playerLanes[1];
    }

    
    void Update()
    {
        // Player Go Left
        if (playerLane == 1 || playerLane == 2)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerLane -= 1;
            }
        }

        // Player Go Right
        if (playerLane == 0 || playerLane == 1)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                playerLane += 1;
            }
        }

        // Set Player Position (While Moving)
        player.transform.position = Vector3.MoveTowards(player.transform.position, playerLanes[playerLane], playerStep * Time.deltaTime);
    }
}
