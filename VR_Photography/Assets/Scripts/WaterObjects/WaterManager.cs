using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public float wavesHeight = 10f;
    public float wavesFrequency = 10f;
    public float wavesSpeed = 10f;
    public Transform water;
    Material WaterMat;
    Texture2D WavesDisplacement;
    
    void Start()
    {
        SetVariables();
    }

    void SetVariables(){
        WaterMat = water.GetComponent<Renderer>().sharedMaterial;
        WavesDisplacement = (Texture2D)WaterMat.GetTexture("_WavesDisplacement");
    }

    public float WaterHeightAtPosition(Vector3 position){
        return water.position.y + WavesDisplacement.GetPixelBilinear(position.x * wavesFrequency/100, position.z * wavesFrequency/100 + Time.time * wavesSpeed/100).g * wavesHeight/100 * water.localScale.x;
    }

    void OnValidate() {
        if(!WaterMat){
            SetVariables();
        }

        UpdateMaterial();
    }

    void UpdateMaterial(){
        WaterMat.SetFloat("_WavesFrequency", wavesFrequency/100);
        WaterMat.SetFloat("_WavesSpeed", wavesSpeed/100);
        WaterMat.SetFloat("_WavesHeight", wavesHeight/100);
    }
}
