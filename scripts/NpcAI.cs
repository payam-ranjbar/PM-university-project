
using UnityEngine;

public class NpcAI : MonoBehaviour
{
    [SerializeField] private float speedVal = 200;
    [SerializeField] private float jumpSize = 100;
    [SerializeField] private Transform balloonPoint;
    [SerializeField] private GameObject balloon;
     private GameObject balloonGameObject;

    private Rigidbody2D rigidbody;
    private Vector3 scale;
    private SoundEffectsManger soundEffects;
    private Animator animator;
    
    private int direction = 1;
    private float facing = 1;
    private float speed = 200;

    private bool stayFactor = false;
    private bool speaking = false;
    private bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
        soundEffects = GetComponent<SoundEffectsManger>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = !stayFactor ?  speedVal : 0;
        transform.localScale = new Vector3(direction * scale.x, scale.y, scale.z);
        
        move();

        if (stayFactor)
        {
            animator.SetTrigger("idle");
            
        }
        else
        {
            animator.SetTrigger("run");
        }

    }

    void move()
    {
        if (onGround)
        rigidbody.velocity = new Vector2(speed * direction * Time.fixedDeltaTime, rigidbody.velocity.y);
    }

    
    void jump()
    {
        if (onGround)
        rigidbody.AddForce(new Vector2(0, jumpSize * Time.fixedDeltaTime), ForceMode2D.Impulse);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ai-obstacle"))
        {
            jump();
        }

        else if (other.CompareTag("ai-stop-move"))
        {
            stayFactor = true;
        } else if (other.CompareTag("ai-wall"))
        {
            direction = -direction;
        } else if (other.CompareTag("Player"))
        {
            stayFactor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            stayFactor = false;
            if (balloonGameObject != null)
            {
                Destroy(balloonGameObject);
                speaking = false;
            }

        }    
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //balloon.setActive(true);
            if (!speaking)
            {
                balloonGameObject = Instantiate(balloon, balloonPoint.position, Quaternion.identity);
                speaking = true;
            }
        }
        if (other.CompareTag("Player")  && Input.GetKeyDown(KeyCode.E))
        {
            if (balloonGameObject != null)
            {
                Destroy(balloonGameObject);
                speaking = false;
            }
            
            
            var dialoug = FindObjectOfType<DialogueManager>();
            dialoug.end();

            dialoug.begin();
        }
          
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("ground"))
        {
            onGround = false;
            animator.SetTrigger("idle");
        }
        
    }

    public void playFootStepSoundEffect()
    {
        soundEffects.play("footstep");
    }
    
    
}
