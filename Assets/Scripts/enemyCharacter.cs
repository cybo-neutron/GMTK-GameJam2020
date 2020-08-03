using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCharacter : MonoBehaviour,IDamage
{
    public float health;

    public GameObject deathEffect;  //Particle effect when a character dies

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    public virtual void TakeDamage(float damageAmount)
    {
        
        Health -= damageAmount;

       


      
    }
}
