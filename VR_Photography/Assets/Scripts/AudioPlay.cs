using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public float delayPlay = 0f;
    public AudioSource audio;

    void Start(){
        Invoke("playAudio", delayPlay);
    }
    public void playAudio(){
        audio.Play();
    }

}
