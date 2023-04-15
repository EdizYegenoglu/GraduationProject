using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Polaroid : MonoBehaviour
{
    public GameObject photoPrefab = null;
    public MeshRenderer screenRenderer = null;
    public Transform spawnLocation = null;
    
    public int counter = 8;
    private bool filmCartridge = true;

    private Camera renderCamera = null;

    public TMP_Text frameCount;

    private void Awake()
    {
        renderCamera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        CreateRenderTexture();
        // TakePhoto();
    }

    void Update(){
        frameCount.text = counter.ToString();

        if (Input.GetKeyDown(KeyCode.Space)){
            TakePhoto();
        }
    }

    private void CreateRenderTexture()
    {
        RenderTexture newTexture = new RenderTexture(256, 256, 32, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
        newTexture.antiAliasing = 4;

        renderCamera.targetTexture = newTexture;
        screenRenderer.material.mainTexture = newTexture;
    }

    public void TakePhoto()
    {
        Debug.Log(filmCartridge);
        photoCounter();
        if(filmCartridge){
            Photo newPhoto = CreatePhoto();
            SetPhotoImage(newPhoto);
        }
    }

    private Photo CreatePhoto()
    {
        GameObject photoObject = Instantiate(photoPrefab, spawnLocation.position, spawnLocation.rotation, transform);
        return photoObject.GetComponent<Photo>();
    }

    private void SetPhotoImage(Photo photo)
    {
        Texture2D newTexture = RenderCameraToTexture(renderCamera);
        photo.SetImage(newTexture);
    }

    private Texture2D RenderCameraToTexture(Camera camera)
    {
        camera.Render();
        RenderTexture.active = camera.targetTexture;

        Texture2D photo = new Texture2D(256, 256, TextureFormat.RGB24, false);
        photo.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        photo.Apply();

        return photo;
    }

    public void photoCounter(){
        counter--;
        Debug.Log(counter);

        if(counter < 0){
            filmCartridge = false;
            counter = 0;
        }
    }

    // public void TurnOn()
    // {
    //     renderCamera.enabled = true;
    //     screenRenderer.material.color = Color.white;
    // }

    // public void TurnOff()
    // {
    //     renderCamera.enabled = false;
    //     screenRenderer.material.color = Color.black;
    // }
}
