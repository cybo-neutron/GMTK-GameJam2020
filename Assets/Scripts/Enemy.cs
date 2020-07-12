using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum States{
    Patrol,
    Chase,
    Attack,
    Idle
}

[System.Serializable]
 class enemyProperties
{
    public float nextShot;
    public float fireRate;

    public float points;

}
public class Enemy : Character
{
    States enemyState;

    [SerializeField] float speed;
    bool movingRight = true;
    [SerializeField] float attackDistance;
    [SerializeField] float chaseDistance;

    

    [SerializeField] Transform GroundDetector;
    [SerializeField] float groundDetectordistance;

    [SerializeField] Transform playerDetector;
    [SerializeField] float playerDetectorDistance;
    Rigidbody2D rb;
    [SerializeField] Transform player;
    [SerializeField] LayerMask playerDetectorIgnoreLayer;


    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletEmissionPoint;
    [SerializeField] float bulletSpeed;
    

    [SerializeField]enemyProperties eb = new enemyProperties();

    RaycastHit2D playerDetectorRay;
    private void Start()
    {
        enemyState = States.Patrol;
        movingRight = true;
        rb = GetComponent<Rigidbody2D>();
        //player = transform.parent.Find("Player").transform;
        eb.nextShot = Time.time;

    }

    private void Update()
    {

        if (player != null)
        {
            Vector2 dir = player.position - playerDetector.position;
            playerDetectorRay = Physics2D.Raycast(playerDetector.position, dir, playerDetectorDistance, playerDetectorIgnoreLayer);
            Debug.DrawRay(playerDetector.position, dir.normalized * playerDetectorDistance, Color.green);

            if (playerDetectorRay.collider == true)
            {

                if (playerDetectorRay.distance <= attackDistance)
                    enemyState = States.Attack;
                else if (playerDetectorRay.distance <= chaseDistance)
                    enemyState = States.Chase;
                else
                    enemyState = States.Patrol;

            }
            else
            {
                enemyState = States.Patrol;
            }


            

        }
        else
        {
            enemyState = States.Idle;
        }

        switch (enemyState)
        {
            case States.Patrol:
                Patrolling();
                break;
            case States.Chase:
                Chasing();
                break;
            case States.Attack:
                Attacking();
                break;
            case States.Idle:
                //Do Nothing
                break;

            default:

                break;

        }


    }

    void Patrolling()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetector.position, Vector2.down, groundDetectordistance);
        if(groundInfo.collider==false)
        {
            if(movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            movingRight = !movingRight;
        }

    }

    void Chasing()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetector.position, Vector2.down, groundDetectordistance);
        float dist = playerDetectorRay.point.x - transform.position.x;
        if (dist>0)
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }

        faceDir(movingRight);

        if(groundInfo.collider==true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }


    }

    void Attacking()
    {

        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetector.position, Vector2.down, groundDetectordistance);
        float dist = playerDetectorRay.point.x - transform.position.x;
        if (dist > 0)
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }

        faceDir(movingRight);

        if(Time.time>eb.nextShot)
        {
            Shoot();
            eb.nextShot = Time.time + eb.fireRate;
        }
    




    }


    void faceDir(bool movingRight)
    {
        if (movingRight)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else
            transform.eulerAngles = new Vector3(0, 180, 0);
    
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletEmissionPoint.position, bulletEmissionPoint.rotation);
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletrb.AddForce(bullet.transform.right*bulletSpeed, ForceMode2D.Force);

    }

}
