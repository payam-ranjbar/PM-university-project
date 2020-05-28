using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGeneralMech : MonoBehaviour
{
    public float speed;
    public float Hfacing = 1;
    public float Vfacing = 0;
    public AudioClip SoundEffect;
    public bool directed = false;
    public bool chargeable = false;

    private float speedVal;
    private Bullet properties;
    
    
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        speedVal = speed;
        rigidbody = GetComponent<Rigidbody2D>();
        var Asource = gameObject.AddComponent<AudioSource>();
        Asource.clip = SoundEffect;
        Asource.Play();
        
    }

    private void Update()
    {
        rigidbody.velocity = new Vector2(Hfacing * speedVal, Vfacing * speedVal);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Destroy(this.gameObject);
        }
    }

    public void setDirction(float H, float V)
    {
        Hfacing = H;
        Vfacing = V;
    }

    public void resetSpeed()
    {
        speedVal = speed;
     //  rigidbody.velocity = new Vector2(Hfacing * speedVal, Vfacing * speedVal);

        
    }

    public void setZeroSpeed()
    {
        speedVal = 0;
       // rigidbody.velocity = new Vector2(Hfacing * speedVal, Vfacing * speedVal);

    }
    
     
    
    
}
