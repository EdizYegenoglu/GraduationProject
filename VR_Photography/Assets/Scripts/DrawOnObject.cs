using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOnObject : MonoBehaviour
{
    [Header("Pen Properties")]
    public Transform tip;
    public Material drawingMaterial;
    public Material tipMaterial;
    [Range(0.001f, 0.1f)]
    public float penWidth = 0.01f;
    public Color[] penColors;

    [Header("Drawing Object")]
    public GameObject drawingObject;

    private LineRenderer currentDrawing;
    private int index;
    private int currentColorIndex;
    private bool isTouchingObject;

    private void Start()
    {
        currentColorIndex = 0;
        tipMaterial.color = penColors[currentColorIndex];
    }

    private void Update()
    {
        if (isTouchingObject)
        {
            Draw();
        }
        else if (currentDrawing != null)
        {
            currentDrawing = null;
        }
    }

    private void Draw()
    {
        if (currentDrawing == null)
        {
            index = 0;
            currentDrawing = new GameObject().AddComponent<LineRenderer>();
            currentDrawing.material = drawingMaterial;
            currentDrawing.startColor = currentDrawing.endColor = penColors[currentColorIndex];
            currentDrawing.startWidth = currentDrawing.endWidth = penWidth;
            currentDrawing.positionCount = 1;
            currentDrawing.SetPosition(0, tip.position);
        }
        else
        {
            var currentPos = currentDrawing.GetPosition(index);
            if (Vector3.Distance(currentPos, tip.position) > 0.01f)
            {
                index++;
                currentDrawing.positionCount = index + 1;
                currentDrawing.SetPosition(index, tip.position);
            }
        }
    }

    private void SwitchColor()
    {
        if (currentColorIndex == penColors.Length - 1)
        {
            currentColorIndex = 0;
        }
        else
        {
            currentColorIndex++;
        }
        tipMaterial.color = penColors[currentColorIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == drawingObject)
        {
            isTouchingObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == drawingObject)
        {
            isTouchingObject = false;
        }
    }
}