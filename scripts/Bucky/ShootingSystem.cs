using System;
using System.Collections;



using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public Bullet[] bulletList;
    public SoundEffectsManger soundEffects;
    
    public Transform aim;

    private GameObject bullet;
    private int bulletIndex = 0;
    
    private float HAimFacing = 1;
    private float VAimFacing = 0;
    private float facing;

    private bool allowedToShoot = true;
    private bool allowedToSwitch = true;
    private bool holdLight = true;
    private float lightMaxCharge = 2f;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<SoundEffectsManger>();
        bullet = bulletList[bulletIndex].bulletObj;
    }

    // Update is called once per frame
    void Update()
    {
        facing = gameObject.GetComponent<PlayerMechanic>().getFace();
        
        aimingStateChecking();
        
        if (Input.GetKey(KeyCode.Z))
        {
            holdLight = true;
         }
        else
        {
            holdLight = false;
        }

        
        if (Input.GetMouseButtonDown(0))
        {
             shoot();    
           
        }
        

        if (Input.GetMouseButtonDown(1))
        {
            switchWeapon();
        }
    }

    private void aimingStateChecking()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            HAimFacing = 1;
        } else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            HAimFacing = -1;
        }
        else
        {
            HAimFacing = 0;
        }
        
        
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            VAimFacing = 1;
            
        } else if (Input.GetAxisRaw("Vertical") < 0)
        {
            VAimFacing = -1;
        }
        else
        {
            VAimFacing = 0;
        }
        
    }

    private bulletGeneralMech shoot()
    {
        if (allowedToShoot)
        {
//            string bullName = "";
//            if (isBulletKindOf("light"))
//            {
//                bullName = "light";
//            } else if (isBulletKindOf("normal"))
//            {
//                bullName = "normal";
//            }

            getCurrentBullet();
           
            var bul = Instantiate(bullet, aim.position, Quaternion.identity);
            var mech = bul.GetComponent<bulletGeneralMech>();
            mech.resetSpeed();

//            if (bullName == "light")
//            {
//                allowedToShoot = false;
//                allowedToSwitch = false;
//                StartCoroutine(ChargeLightBullet());
//                if (!holdLight)
//                {
//                    mech.resetSpeed();
//                    allowedToShoot = true;
//                    allowedToSwitch = true;
//                }
//            
//            } else if (bullName == "normal")
//            {
//                mech.resetSpeed();
//            }
        
                
        
            if (mech.directed)
            {
                correctBulletAngel(ref bul);
            }

            if (VAimFacing == 0 && HAimFacing == 0)
            {
                mech.setDirction(facing, 0);
            }
            else
            {
                mech.setDirction(HAimFacing, 0);
            }

            return mech;
        }

        return null;

    }

    private void correctBulletAngel(ref GameObject bul)
    {
        if (VAimFacing == 0 && HAimFacing != 0)
        {
           bul.transform.rotation = Quaternion.Euler(0, 0, (-HAimFacing * 90)  );
        } else if (HAimFacing == 0)
        {
            if (VAimFacing == -1)
            {
              //  bul.transform.rotation = Quaternion.Euler(0, 0, 180);
            } else if (VAimFacing == 0)
            {
               // bul.transform.rotation = Quaternion.Euler(0, 0, (facing * 90));
            }
        } else
        {
          //  bul.transform.rotation = Quaternion.Euler(0, 0, (-HAimFacing * 90) + (HAimFacing * VAimFacing) * 45);
        }
        
        
    }
    

    private void switchWeapon(string name = "")
    {
        soundEffects.play("weapon switch");
        if (name != "")
        {
            bullet = Array.Find(bulletList, bulletList => bulletList.name == name).bulletObj;
        }
        else
        {
            if (++bulletIndex >= bulletList.Length)
            {
                bulletIndex = 0;
            }

            bullet = bulletList[bulletIndex].bulletObj;
        }
    }

    
    

    private bool isBulletKindOf(string name)
    {
        return bulletList[bulletIndex].name == name;
    }

    private GameObject getCurrentBullet()
    {
        bullet = bulletList[bulletIndex].bulletObj;
        return bullet;
    }

    private IEnumerator ChargeLightBullet()
    {
        getCurrentBullet();
        float i = 0.1f;
        
        while (bullet.transform.localScale.x <= lightMaxCharge && bullet.transform.localScale.y <= lightMaxCharge)
        {
            bullet.transform.localScale = new Vector3(bullet.transform.localScale.x + i, bullet.transform.localScale.y +i, bullet.transform.localScale.z);
            i++;
           
            yield return new WaitForSeconds(0.5f);
        }
    }

}
