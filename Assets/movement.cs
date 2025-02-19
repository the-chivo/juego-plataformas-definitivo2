using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LayerMask groundLayer;
    Rigidbody2D rb;
    [SerializeField] SpriteRenderer playerColor;
    [SerializeField] ParticleSystem particles;
    [SerializeField] ParticleSystem jumpParticles;
    [SerializeField] ParticleSystem noJumpParticles;
    [SerializeField] float airFriction = 1;
    [SerializeField] statsLists stats;
    bool isgrounded = false;
    bool airjump = false;
    bool jumpTimeIsOut = false;
    bool charIsJumping = false;
    bool jumpTime;
    bool airFrictionActive;
    bool maxGroundAceleration;
    bool maxAirAceleration;
    float time = Mathf.Infinity;
    float frictionTime = 1;
    float speed;
    int playerJumps = 0;
    float jumpsRemaining;
    [SerializeField] Gradient onAirColor;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionInput = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            directionInput += Vector2.right;          
        }
        if (Input.GetKey(KeyCode.A))
        {
            directionInput += Vector2.left;
        }
        //Friccion aire
        if (directionInput.x == 0)
        {
            //rb.velocity = new Vector2(rb.velocity.x * (1 - airFriction * Time.deltaTime), rb.velocity.y);
            airFrictionActive = true;
        }
        else airFrictionActive = false;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isgrounded || (isgrounded == false && playerJumps < Stats.maxJumps))
            {
                airjump = true;
                time = 0;
            }
            if(isgrounded == false)
            {
                playerJumps += 1;
                print(playerJumps);
                if(playerJumps <= Stats.maxJumps)
                {
                    jumpsRemaining = (1f * Stats.maxJumps - playerJumps) / Stats.maxJumps;
                    playerColor.color = onAirColor.Evaluate(jumpsRemaining);
                    jumpParticles.Play();
                    airjump = true;
                }
            }
                
            if(playerJumps > Stats.maxJumps)
            {
                noJumpParticles.Play();
                airjump = false;
            }
            
        }

        if (Input.GetKeyUp(KeyCode.Space) || time >= Stats.maxJumpTime)
        {
            airjump = false;
        }


        if (Mathf.Abs(rb.velocity.x) < Stats.maxGroundHorizontalSpeed)
        {
                maxGroundAceleration = true;      
        }

        if (Mathf.Abs(rb.velocity.x) < Stats.maxAirHorizontalSpeed)
        {
            maxAirAceleration = true;
        }

        if(Mathf.Abs(rb.velocity.x) > Stats.maxGroundHorizontalSpeed)
        {
             maxGroundAceleration = false; 
        }
        if (Mathf.Abs(rb.velocity.x) < Stats.maxAirHorizontalSpeed)
        {
            maxAirAceleration = false;
        }




                isgrounded = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 0.7f, groundLayer);
        if(isgrounded == true)
        {
            //print("si");
            playerJumps = 0;
            playerColor.color = onAirColor.Evaluate(1);
            rb.gravityScale = 1;
            //airjump = false;
        }
       
        if(rb.velocity.y < Stats.maxFallSpeed)
        {
            rb.velocity = new Vector2(0,Stats.maxFallSpeed);
        }

        //speed = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y);
        speed = rb.velocity.magnitude;
 
        //particulas
        if (isgrounded == true)
        {
            var par = particles.main;
            par.startLifetime = 1.36f;
        }
        if (isgrounded == false)
        {
            var par = particles.main;
            par.startLifetime = 0;
        }
        //tema de gravedad
        if(rb.velocity.y > -Stats.yVelocityLowGravityThreshold && rb.velocity.y < Stats.yVelocityLowGravityThreshold && isgrounded == false)
        {
            rb.gravityScale = Stats.peackGravity;
            print("pick");
        }
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = Stats.fallGravity;
        }
        if(rb.velocity.y > 0)
        {
            rb.gravityScale = Stats.upGravity;
        }
    }
    void FixedUpdate()
    {
        //direccion
        Vector2 directionInput = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            directionInput += Vector2.right;          
        }
        if (Input.GetKey(KeyCode.A))
        {
            directionInput += Vector2.left;
        }
        //friccion
        if (airjump)
        {
            rb.velocity = new Vector2(rb.velocity.x, Stats.jumpForce);
            time += Time.deltaTime;
        }
        if(airFrictionActive == true)
        {
            rb.velocity = new Vector2(rb.velocity.x * (1 - airFriction * Time.deltaTime), rb.velocity.y);
        }
        //movimiento

        if (maxGroundAceleration == true)
        {
            rb.velocity += directionInput.normalized * Stats.groundAceleration * Time.deltaTime;
        }
        
        if (maxAirAceleration == true)
        {
            rb.velocity += directionInput.normalized * Stats.airAceleration * Time.deltaTime;
        }
    }
    
    MovementStatus Stats
    {
        get => stats.playerMode;
    }
   private void Jump()
    {
            print(playerJumps);
            //rb.velocity = new Vector2(rb.velocity.x, Stats.jumpForce);(esta en fixed update)
            //time = 0;
            charIsJumping = true;          
    }

}