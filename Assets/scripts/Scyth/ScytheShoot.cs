using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheShoot : MonoBehaviour
{
    private LanesManager Lanes;
    private PlayerSideMovement Player;
    private GameObject player;
    private int playerLane = 0;

    private GameObject bulletprefab;

    List<Vector3> playerLanes = new List<Vector3>();

    void Start()
    {
        player = GameObject.Find("Player");
        Lanes = player.GetComponent<LanesManager>();
        Player = player.GetComponent<PlayerSideMovement>();
        bulletprefab = Resources.Load("Bullet") as GameObject;
        playerLanes = LanesManager.lanes;
    }

    void Update()
    {

        playerLane = Player.playerLane;

        if (playerLane != 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var Bullet = Instantiate(bulletprefab, playerLanes[playerLane - 1], Quaternion.identity);
            }
        }
        if (playerLane != 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var Bullet = Instantiate(bulletprefab, playerLanes[playerLane + 1], Quaternion.identity);
            }
        }
    }
}
