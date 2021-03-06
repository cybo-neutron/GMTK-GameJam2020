﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float _damage;
    [SerializeField] GameObject particleEff;
    [SerializeField] float lifeTime;

    private void Awake()
    {
        Invoke("DestroyThis", lifeTime);
    }

    void DestroyThis()
    {
        //spawn particle effect
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision != null)
        {


            if (collision.transform.CompareTag("Player"))
            {
                //play particle effect

                collision.transform.GetComponent<Player>().TakeDamage(_damage);


                Destroy(this.gameObject);

            }
            else if (!collision.transform.CompareTag("Enemy") && !collision.transform.CompareTag("Bullet"))
            {
                //play particle effect;

                Destroy(this.gameObject);

            }

        }

    }
}
