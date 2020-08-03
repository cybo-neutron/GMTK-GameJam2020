using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour,IDamage
{
    public float health;
    
    public GameObject deathEffect;  //Particle effect when a character dies

    public float Health { get { return health; }  
        set { health = value;}
         }

    public void TakeDamage(float damageAmount)
    {
        
        Health -= damageAmount;

        if(Health<=0)
        {
            //play death effect
            GameManager.Instance.playerDead();
            Destroy(this.gameObject);
        }
    
    }

}
