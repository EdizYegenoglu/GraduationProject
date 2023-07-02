using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetActive : MonoBehaviour
{
    public float delayShow = 0f;
    public float delayHide = 0f;
    public GameObject ItemToTurnOff;

    void Start(){
        Invoke("Show", delayShow);
        Invoke("Hide", delayHide);
        ItemToTurnOff.SetActive(false);
    }

    public void PlayGame(){
        // Invoke("Show", delayShow);
        // Invoke("Hide", delayHide);
    }

    public void Show(){
        ItemToTurnOff.SetActive(true);
    }

    public void Hide(){
        ItemToTurnOff.SetActive(false);
    }
}
