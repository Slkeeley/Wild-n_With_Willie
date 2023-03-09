using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePicture : MonoBehaviour
{
 public void captureImage()
    {
        Debug.Log("Captured"); 
        ScreenCapture.CaptureScreenshot("Wild'n.png"); 
    }
}
