using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Brandon Ruigrok
public class BossHealth : MonoBehaviour
{
    [SerializeField]
    int Hp = 400;

    public Action<int> BossTakingDamage;

    public void TakeDamage(int damage)
    {
        Hp -= damage;

        if (BossTakingDamage != null)
        {
            BossTakingDamage(Hp);
        }
    }
}
