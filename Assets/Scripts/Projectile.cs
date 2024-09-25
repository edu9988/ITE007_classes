using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20.0f;
    void Update()
    {
        ApplyMovement();
        //CheckDistance();
    }

    void ApplyMovement(){
        transform.Translate(Time.deltaTime * speed * new Vector3(0,1));
    }

    /*
    void CheckDistance(){
        if(transform.position.y > 5.0f ){
            Destroy(gameObject);
        }
    }
    */
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
