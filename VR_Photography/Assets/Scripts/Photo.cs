using System.Collections;
using UnityEngine;

// [RequireComponent(typeof(ApplyPhysics))]
public class Photo : MonoBehaviour
{
    public MeshRenderer imageRenderer = null;
    Color colorStart = Color.black;
    Color colorEnd = Color.white;
    public float fadeDuration = 1.0f;


    private Collider currentCollider = null;
    // private ApplyPhysics applyPhysics = null;

    private void Awake()
    {
        currentCollider = GetComponent<Collider>();
        // applyPhysics = GetComponent<ApplyPhysics>();
    }

    private void Start()
    {
        StartCoroutine(EjectOverSeconds(1.5f));        
        StartCoroutine(FadeObject());
    }

    public IEnumerator EjectOverSeconds(float seconds)
    {
        // applyPhysics.DisablePhysics();
        currentCollider.enabled = false;

        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            transform.position += transform.forward * Time.deltaTime * 0.1f;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        currentCollider.enabled = true;
    }

    public IEnumerator FadeObject(){
        float t = 0.0f;
        while (t < fadeDuration){
            t += Time.deltaTime;
            imageRenderer.material.color = Color.Lerp(colorStart, colorEnd, t / fadeDuration);
            yield return null;
        }
    }

    public void SetImage(Texture2D texture)
    {
        // imageRenderer.material.color = Color.white;
        imageRenderer.material.mainTexture = texture;
    }

    // public void EnablePhysics()
    // {
    //     applyPhysics.EnablePhysics();
    //     transform.parent = null;
    // }
}
