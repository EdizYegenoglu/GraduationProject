using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveChilds3 : MonoBehaviour
{
    List<Material> materials = new List<Material>();
    public float value = 0f;
    bool dissolveInProgress = false;
    bool dissolveComplete = false;
    bool audio = false;

    void Start() {
        var renders = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renders.Length; i++) {
            materials.AddRange(renders[i].materials);
        }
        SetValue(1);
    }

    private void Reset() {
        Start();
        SetValue(1);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            Dissolve();
        }
    }

    public void Dissolve(){
        if (!dissolveInProgress && !dissolveComplete) {
            StartCoroutine(DissolveCoroutine());
            dissolveInProgress = true;
        }
        if (dissolveComplete) {
            StartCoroutine(UndissolveCoroutine());
            dissolveComplete = false;
        }
        PlayAllAudioComponents(transform);
    }

    IEnumerator DissolveCoroutine() {
        while (value < 1f) {
            value += Time.deltaTime;
            SetValue(value);
            yield return null;
        }

        dissolveInProgress = false;
        dissolveComplete = true;
    }

    IEnumerator UndissolveCoroutine() {
        while (value > 0f) {
            value -= Time.deltaTime;
            SetValue(value);
            yield return null;
        }

        dissolveInProgress = false;
        dissolveComplete = false;
    }

    public void SetValue(float value) {
        for (int i = 0; i < materials.Count; i++) {
            materials[i].SetFloat("_Dissolve", value);
        }
    }

    private IEnumerator FadeOutAudio(AudioSource audioSource, float fadeDuration){
        float initialVolume = audioSource.volume;
        float timer = 0f;

        while (timer < fadeDuration){
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(initialVolume, 0f, timer / fadeDuration);
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = initialVolume;
    }

    private void PlayAllAudioComponents(Transform parent){
        foreach (Transform child in parent){
            AudioSource audioSource = child.GetComponent<AudioSource>();
            if (audioSource != null){
                if (audioSource.isPlaying){
                    Debug.Log("audio false");
                    StartCoroutine(FadeOutAudio(audioSource, 1.0f));
                }
                else{
                    Debug.Log("audio true");
                    audioSource.Play();
                }
            }
            PlayAllAudioComponents(child);
        }
    }

}
