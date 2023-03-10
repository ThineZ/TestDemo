using UnityEngine;

public class PotalTexSetup : MonoBehaviour
{
    public Camera CameraTwo;
    public Material camMatTwo;

    public Camera MainCamera;
    public Material camMatMain;

    private void Start()
    {
        if (CameraTwo.targetTexture != null)
        {
            CameraTwo.targetTexture.Release();
        }

        CameraTwo.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camMatTwo.mainTexture = CameraTwo.targetTexture;       

        MainCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camMatMain.mainTexture = MainCamera.targetTexture;
    }
}
