using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLine : MonoBehaviour
{
    public float speed = 5f; // Snelheid van het object
    public bool fly = false;

    public float delayPlay = 0f;
    
    public void Start(){
        Invoke("Fly", delayPlay);
    }

    public void PlayGame(){
        // Invoke("Fly", delayPlay);
    }

    public void Fly(){
        fly = true;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Keypad0)) {
            Fly();
        }
        if(fly){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
