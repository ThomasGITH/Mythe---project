using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulShoot : MonoBehaviour
{
    [SerializeField]
    private float BulletSpeed = 0.50f;
    private int hitSouls = 3;
    public int damageSouls;
    public int damageToBoss;
    public int soulCounter;
    private int oneSouls = 2;
    private int twoSouls = 5;
    private int threeSouls = 8;
    private int maxSouls = 10;


    private void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, BulletSpeed);


    }


    private void OnCollisionEnter(Collision collision)
    {
        // Check collision with boss (CHANGE NAME LATER)
        if (collision.gameObject.name == "Portal")
        {
            Destroy(this.gameObject);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
            if (damageSouls <= oneSouls)
            {                
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            } else 
            if (damageSouls <= twoSouls && damageSouls >= oneSouls)
            {                
                Destroy(other.gameObject);
                hitSouls -= 1;
                if (hitSouls == 1)
                {
                    Destroy(this.gameObject);
                }
            } else
            if (damageSouls <= threeSouls && damageSouls >= twoSouls)
            {
                Destroy(other.gameObject);
                hitSouls -= 1;
                if (hitSouls == 0)
                {
                    Destroy(this.gameObject);
                }
            } else
            if (damageSouls == maxSouls)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
