﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveChilds : MonoBehaviour
{
    List<Material> materials = new List<Material>();
    public float value = 0f;
    bool dissolveInProgress = false;
    bool dissolveComplete = false;

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
        if (Input.GetKeyDown(KeyCode.Keypad0)) {
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
}
