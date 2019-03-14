using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Brandon Ruigrok
public class BossHealth : MonoBehaviour
{
    int Hp = 400;

   // DamageOutput dmg;


    private void OnTriggerEnter(Collider col)
    {
    //    dmg = GameObject.Find("Scyth").GetComponent<DamageOutput>();
        if (col.gameObject.tag == "Shot Soul")
        {
    //        Hp = (Hp - dmg.Damage);
        }
    }
}
