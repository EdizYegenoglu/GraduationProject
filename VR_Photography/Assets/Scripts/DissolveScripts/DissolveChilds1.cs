using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveChilds1 : MonoBehaviour
{
    List<Material> materials = new List<Material>();
    public float value = 0f;
    bool dissolveInProgress = false;
    bool dissolveComplete = false;
    bool audio = false;

    public float delayPlay = 0f;

    void Start() {
        Invoke("Dissolve", delayPlay);
        var renders = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renders.Length; i++) {
            materials.AddRange(renders[i].materials);
        }
    }

    public void Dissolve(){
        StartCoroutine(DissolveCoroutine());
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

    public void SetValue(float value) {
        for (int i = 0; i < materials.Count; i++) {
            materials[i].SetFloat("_Dissolve", value);
        }
    }
}
