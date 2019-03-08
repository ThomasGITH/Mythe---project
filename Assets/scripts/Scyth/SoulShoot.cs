using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulShoot : MonoBehaviour
{
    [SerializeField]
    private float BulletSpeed = 1;
    private float timer;

    void Update()
    {
        transform.Translate(0, 0, BulletSpeed);

        timer += Time.deltaTime;
        if (timer >= 2)
        {
            Destroy(gameObject);
        }
    }

}
