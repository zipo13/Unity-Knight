using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class DamageController : MonoBehaviour 
{
    public int maxHealth = 100;
    private DamageListener listener;

    public void wound(int damage, float attackDirection)
    {
        maxHealth -= damage;
        if (listener != null)
        {
            listener.hurt(attackDirection);
            if (maxHealth <= 0)
            {
                listener.dead();
            }
        }
        
    }

    public void SetDamageListener(DamageListener damageListener)
    {
        this.listener = damageListener;
    }
}
