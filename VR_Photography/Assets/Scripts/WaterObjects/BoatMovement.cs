using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    float wiggleDistance = 1;
    float wiggleSpeed = 1;
    public GameObject boat;
 
void Update()
{
    float yPosition = Mathf.Sin(Time.time * wiggleSpeed) * wiggleDistance;
    transform.localPosition = new Vector3(boat.transform.position.x, yPosition, boat.transform.position.z);
}
}
