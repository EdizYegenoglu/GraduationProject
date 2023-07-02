using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binocular : MonoBehaviour
{
    public GameObject Coin;
    public GameObject Ship;
    public Rigidbody ShipRB;
    public MonoBehaviour ShipScript;
    public MeshRenderer imageRenderer = null;
    Color colorStart = Color.black;
    Color colorEnd = Color.white;
    public float fadeDuration = 1.0f;
    public float delayPlay = 5f;

    public void Start(){
        imageRenderer.material.color = colorStart;
    }
    // pay
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Coin)
        {
            StartCoroutine(FadeObject());
            Coin.SetActive(false);
            Invoke("Sink", delayPlay);
        }
    }
    public IEnumerator FadeObject(){
        float t = 0.0f;
        while (t < fadeDuration){
            t += Time.deltaTime;
            imageRenderer.material.color = Color.Lerp(colorStart, colorEnd, t / fadeDuration);
            yield return null;
        }
    }
    
    //sink ship
    public void Sink(){
        ShipRB.constraints = RigidbodyConstraints.None;
        Invoke("disableBuoyancy", delayPlay);
    }
    public void disableBuoyancy(){
        ShipScript.enabled = false;
        Invoke("disableShip", delayPlay);
    }
    public void disableShip(){
        Ship.SetActive(false);
    }
}
