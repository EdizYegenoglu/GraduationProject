using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class spawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public int counter;

        private void OnTriggerEnter(Collider collision) {
        if((collision.gameObject.tag == "Hand") && (counter < 5)){
            Instantiate(foodPrefab, transform.position, Quaternion.identity);
            counter ++;
            Debug.Log(counter);
        }
    }

}
