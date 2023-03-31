using System.Collections;
using System.Collections.Generic;
using System.IO; 
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
   

    public void takePhoto()
    {
        screenSwitch?.Invoke();
        StartCoroutine(captureImage());
        
    }


    IEnumerator captureImage()//wait for a tenth of a second for the UI elements to disappear before taking the photo
    {
        yield return new WaitForSeconds(.1f);
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


    void saveSprite()
    {
        Texture2D photoSaved = mySprite.texture;
        byte[] bytes = photoSaved.EncodeToPNG();
        NativeGallery.SaveImageToGallery(bytes, "DCIM/album/filename", "Wild'n.jpg");
    }
}
