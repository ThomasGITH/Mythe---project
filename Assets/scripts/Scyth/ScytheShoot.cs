using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheShoot : MonoBehaviour
{
    private GameObject BulletParentRight;
    private GameObject BulletParentLeft;
    public GameObject bulletprefab;

    void Start()
    {
        BulletParentLeft = GameObject.Find("LeftScythe");
        BulletParentRight = GameObject.Find("RightScythe");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var Bullet = Instantiate(bulletprefab, BulletParentLeft.transform.position, Quaternion.identity);
            Bullet.transform.parent = BulletParentLeft.transform;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var Bullet = Instantiate(bulletprefab, BulletParentRight.transform.position, Quaternion.identity);
            Bullet.transform.parent = BulletParentRight.transform;
        }
    }
}
