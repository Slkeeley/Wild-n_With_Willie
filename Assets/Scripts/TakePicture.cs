using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 
using TMPro;

public class TakePicture : MonoBehaviour
{
    public Image photo;
    public UnityEvent screenSwitch;
    private Vector2 pivot = new Vector2(0, 0);
    Sprite mySprite;
   

    public void captureImage()
    {
        screenSwitch?.Invoke(); 
        var texture = ScreenCapture.CaptureScreenshotAsTexture();
        if (mySprite == null)
        {
            mySprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot);
        }
        else
        {
            mySprite = null;
            mySprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), pivot);
        }
        photo.sprite = mySprite;
    }
}
