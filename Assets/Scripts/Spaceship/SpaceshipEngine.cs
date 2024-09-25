using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEngine : MonoBehaviour, IMovementController, IGunController
{
    public Projectile projPrefab;
    public Spaceship spaceship;

    public void OnEnable(){
        spaceship.SetMovementController(this);
        spaceship.SetGunController(this);
    }

    public void Update(){
        if( Input.GetButton("Horizontal") ){
            spaceship.MoveHorizontally( Input.GetAxis("Horizontal") );
        }

        if( Input.GetButton("Vertical") ){
            spaceship.MoveVertically( Input.GetAxis("Vertical") );
        }

        if( Input.GetButtonDown("Fire1") ){
            spaceship.ApplyFire();
        }
    }

    public void MoveHorizontally(float x)
    {
        var hor = Time.deltaTime * x;
        transform.Translate(new Vector3(hor,0));
    }

    // Update is called once per frame
    public void MoveVertically(float y)
    {
        var ver = Time.deltaTime * y;
        transform.Translate(new Vector3(0,ver));
    }

    public void Fire(){
        Instantiate(projPrefab,transform.position,Quaternion.identity);
    }
}
