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
        Debug.Log("Took Damage");
        Health -= damageAmount;

        if(Health<=0)
        {
            //play death effect

            Destroy(this.gameObject);
        }


        Debug.Log(Health);
    }

}
