using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLine : MonoBehaviour
{
    public float speed = 5f; // Snelheid van het object
    public bool fly = false;
    
    public void Fly(){
        fly = true;
    }

    void Update(){
        if(fly){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
