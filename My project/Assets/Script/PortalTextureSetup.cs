using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraTwo;
    public Material cameraTwoMat;

    void Start () { 
    if (cameraTwo.targetTexture != null)
        {
            cameraTwo.targetTexture.Release();
        }
        cameraTwo.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraTwoMat.mainTexture = cameraTwo.targetTexture;
    }
}