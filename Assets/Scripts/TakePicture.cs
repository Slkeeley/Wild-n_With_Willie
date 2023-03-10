using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TakePicture : MonoBehaviour
{
    public Image photo;
    private Rect rectObj = new Rect(0,0, 100f, 200);
    private Vector2 pivot = new Vector2(0, 0);

    public void captureImage()
    {
        Debug.Log("Captured");
        var texture = ScreenCapture.CaptureScreenshotAsTexture();
        Sprite mySprite = Sprite.Create(texture,rectObj, pivot);
        photo.sprite = mySprite;
    }
}
