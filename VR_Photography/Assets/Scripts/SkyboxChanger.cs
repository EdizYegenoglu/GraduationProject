using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour
{   
    public float delayTransition = 0f;
    public float transitionDuration = 2f; // Duur van de overgang in seconden
    public float currentExposure = 0f;
    public float targetExposure = 1f;
    private float transitionTimer = 0f;
    private bool isTransitioning = false;

    private void Start()
    {
        RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
        // Invoke("startTransition", delayTransition);
    }
    public void PlayGame(){
        Invoke("startTransition", delayTransition);
    }

    public void startTransition(){
        StartCoroutine(TransitionExposure());
    }
    private System.Collections.IEnumerator TransitionExposure()
    {
        isTransitioning = true;

        while (transitionTimer < transitionDuration)
        {
            transitionTimer += Time.deltaTime;
            float t = transitionTimer / transitionDuration;
            currentExposure = Mathf.Lerp(0f, targetExposure, t);
            RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
            yield return null;
        }

        currentExposure = targetExposure;
        RenderSettings.skybox.SetFloat("_Exposure", currentExposure);
        isTransitioning = false;
    }
}