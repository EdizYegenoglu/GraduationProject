using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    List<Material> materials = new List<Material>();
    public float value = 0f;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            Dissolve();
        }
    }
    void Start() {
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
    }

    public void SetValue(float value) {
        for (int i = 0; i < materials.Count; i++) {
            materials[i].SetFloat("_Dissolve", value);
        }
    }
}
