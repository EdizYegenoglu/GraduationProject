using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyancyObject : MonoBehaviour
{
    public Transform[] floaters;
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float AirDrag = 0f;
    public float AirAngularDrag = 0.05f;
    public float floatingPower = 15f;
    Rigidbody m_Rigidbody;
    int floatersUnderwater;
    bool underwater;
    WaterManager waterManager;

    void Start(){
        m_Rigidbody = GetComponent<Rigidbody>();
        waterManager = FindObjectOfType<WaterManager>();
    }

    void FixedUpdate(){
        floatersUnderwater = 0;
        for(int i = 0; i < floaters.Length; i++){
            float difference = floaters[i].position.y - waterManager.WaterHeightAtPosition(floaters[i].position);
            if(difference < 0){
                m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floaters[i].position, ForceMode.Force);
                floatersUnderwater += 1;
                if(!underwater){
                    underwater = true;
                    SwitchState(true);
                } 
            }
        }
        if(underwater && floatersUnderwater == 0){
            underwater = false;
            SwitchState(false);
        }
    }
    void SwitchState(bool isUnderwater){
        if(isUnderwater){
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underWaterAngularDrag;
        } else{
            m_Rigidbody.drag = AirDrag;
            m_Rigidbody.angularDrag = AirAngularDrag;
        }
    }
}
