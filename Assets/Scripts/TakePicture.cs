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
    public GameObject photoBorder;
    public GameObject subMenu;
    [SerializeField] private screenSwitch ss; 
    private Vector2 pivot = new Vector2(0, 0);
    public Sprite mySprite;

    private void Awake()
    {
        subMenu.SetActive(false); 
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

    public void hideSubMenu()
    {
        subMenu.SetActive(false); 
    }

    public void showSubMenu()
    {
        subMenu.SetActive(true); 
    }
    public void deleteImage()
    {
        if(mySprite!=null)
        {
            photo.sprite = null;
            photo.enabled = false; 
        }
        photoBorder.SetActive(false);
        hideSubMenu(); 

    }

   
}
