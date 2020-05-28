using System;
using System.Collections;
using BuckyStates;
using UnityEngine;

public class PlayerMechanic : MonoBehaviour
{
    public float RunSpeed = 300f;
    public float JumpSpeed = 300f;
    public float DashSpeed = 300f;
    public float FallMultiplier = 5f;

    

    private bool onGround = true;
    private bool isJumping = false;
    private bool isFalling = false;
    private bool isDashing = false;
    private bool JumpTrigger = true;
    
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private PlayerSoundEffects soundEffects;
    private ParticleEffectManager particleManager;
    
    private int faceDirection = 1;
    private BuckyMechStates mechState = BuckyMechStates.Idle;
    private BuckShootingStates shootingState = BuckShootingStates.F;

    private float hInput;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        soundEffects = GetComponent<PlayerSoundEffects>();
        particleManager = GetComponent<ParticleEffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
      
        StateChecking();
        Facing();
        animationCheck();
    }

    private void FixedUpdate()
    {
       if (rigidbody.velocity.y < 0)
       {
           isFalling = true;
           rigidbody.velocity += Time.fixedDeltaTime * Physics2D.gravity.y * (FallMultiplier - 1) * Vector2.up;
       }
       movingMech();
        
        if ((Input.GetKeyDown(KeyCode.F)) && !isDashing)
        {
            dashing();
        }
        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space) && JumpTrigger)
            {
                soundEffects.playJumpEffect();
                rigidbody.AddForce(new Vector2(0, JumpSpeed * Time.fixedDeltaTime), ForceMode2D.Impulse);
                
                onGround = false;
                isJumping = true;
                isFalling = false;
//                JumpTrigger = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("ground"))
        {
            if (isJumping || isFalling)
            {
                soundEffects.playGroundHitEffect();
                particleManager.Play("landing dust");
            }
            
            onGround = true;
            isJumping = false;
            JumpTrigger = true;
            isFalling = false;
        }
    }

    private void Facing()
    {
        if (hInput > 0)
        {
            faceDirection = 1;
        } else if (hInput < 0)
        {
            faceDirection = -1;
        }
        transform.localScale = new Vector3(-faceDirection*0.55f,0.55f,0.55f);


    }

    private void StateChecking()
    {
        if (Math.Abs(hInput) > 0)
        {
            if (onGround)
            {
                mechState = BuckyMechStates.Run;

            } else if (isJumping)
            {
                
                mechState = BuckyMechStates.Idle;

            }
        }
        else
        {
            mechState = BuckyMechStates.Idle;

        }

    }

    private void movingMech()
    {
        if (!isDashing)
        {
            if (onGround)
            {
                rigidbody.velocity = new Vector2(hInput * RunSpeed * Time.fixedDeltaTime, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.velocity = new Vector2(hInput * (RunSpeed/2) * Time.fixedDeltaTime, rigidbody.velocity.y);

            }
        }
        else
        {
            var velocity = rigidbody.velocity;
            velocity = new Vector2(velocity.x, velocity.y);
            rigidbody.velocity = velocity;
        }

     
    }

    private void dashing()
    {
        isDashing = true;
        particleManager.Play("dash", faceDirection);
        soundEffects.playDashEffect();
        rigidbody.AddForce(new Vector2(faceDirection * (!isJumping? DashSpeed: DashSpeed + DashSpeed/2 )* Time.fixedDeltaTime, 0), ForceMode2D.Impulse);
        StartCoroutine(afterDash());

    }

    private IEnumerator afterDash()
    {
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
    }

    private void animationCheck()
    {
        switch (mechState)
        {
            case BuckyMechStates.Run:
                animator.SetTrigger("run");
                break;
            case BuckyMechStates.Idle:
                animator.SetTrigger("idle");
                break;
            default:
                animator.SetTrigger("idle");
                break;
        }
    }

    public float getFace()
    {
        return faceDirection;
        
    }

    public void playParticle(string name)
    {
        particleManager.Play(name);
    }
    
    
}
