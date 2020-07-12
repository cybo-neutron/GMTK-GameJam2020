using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    


    Rigidbody2D rb;
    [SerializeField] float playermoveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask lmask;
    float pWidth;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletEmmisionPoint;

    PlayerAbilities ability;
    int extraJumps;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ability = GetComponent<PlayerAbilities>();


        pWidth = transform.localScale.x;
        extraJumps = ability.extraJumps;

        ability.nextShot = Time.time;
    }

    
    void Update()
    {

        
    }
    private void FixedUpdate()
    {
        HandleJump();

        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * playermoveSpeed * Time.fixedDeltaTime * 10, rb.velocity.y);

        if (moveX != 0)
            flip(moveX);


        if(Input.GetMouseButtonDown(0))
        {
            //shoot
            if(Time.time>ability.nextShot)
            {
                ability.nextShot = Time.time + ability.fireRate;
                Shoot();

            }
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround())
            {
                extraJumps = ability.extraJumps;
                Jump();
            }
            else if (!isGround() && extraJumps > 0)
            {
                Jump();
                extraJumps--;
            }
        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * Time.deltaTime * 10);
        
    }

    bool isGround()
    {
        return (Physics2D.OverlapArea(new Vector2(groundCheck.position.x - pWidth, groundCheck.position.y - 0.05f), new Vector2(groundCheck.position.x + pWidth, groundCheck.position.y + 0.001f),lmask ) );
          
    }

    void flip(float moveX)
    {
        if (moveX < 0)
            transform.rotation = Quaternion.Euler(0, -180, 0);
        else if (moveX > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);

    }


   

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletEmmisionPoint.position, bulletEmmisionPoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(bullet.transform.right * ability.shootSpeed, ForceMode2D.Force);

    }

}
