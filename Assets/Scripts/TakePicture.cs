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
    public Sprite mySprite;
   

    public void takePhoto()
    {
        screenSwitch?.Invoke();
        captureImage();
    
    }


    public void captureImage() //wait for a tenth of a second for the UI elements to disappear before taking the photo
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
     //   saveSprite();
    }


    public void saveSprite()
    {
        if (mySprite != null)
        {
            Texture2D photoSaved = mySprite.texture;
            byte[] bytes = photoSaved.EncodeToPNG();
            NativeGallery.SaveImageToGallery(bytes, "DCIM/album/filename", "Wild'n.jpg");
        }
        else return; 
    }

    public void deleteImage()
    {
        if(mySprite!=null)
        {
            mySprite = null;
        }

        //Debug.Log("Deleting image");
      //  File.Delete("/storage/emmc/DCIM/album/filename/Wild'n.jpg");
        //    NativeGallery.GetImageFromGallery(NativeGallery.MediaPickCallback callback, 
   //    NativeGallery.GetImageFromGallery(callback, string title = "", string mime = "image/*"));
        //bring up are you sure menu in the futre
       // screenSwitch?.Invoke();
    }
}
