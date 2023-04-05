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
        captureImage();      
    }


    void captureImage() //wait for a tenth of a second for the UI elements to disappear before taking the photo
    {     
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
        saveSprite();
    }


    public void saveSprite()
    {
        Texture2D photoSaved = mySprite.texture;
        byte[] bytes = photoSaved.EncodeToPNG();
        NativeGallery.SaveImageToGallery(bytes, "DCIM/album/filename", "Wild'n.jpg");
    }

    public void deleteImage()
    {
        
        File.Delete(NativeGallery.GetImageFromGallery(MediaPickCallback callback, string title = "", string mime = "image/*"))
        //bring up are you sure menu in the futre
        screenSwitch?.Invoke();
    }
}
