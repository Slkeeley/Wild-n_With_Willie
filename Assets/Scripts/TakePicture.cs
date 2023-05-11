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
    //public GameObject shareMenu;
    [SerializeField] private screenSwitch ss; 
    private Vector2 pivot = new Vector2(0, 0);
    public Sprite mySprite;
    public TMP_Text savedFeedback; 

    private void Awake()
    {
        subMenu.SetActive(false);
        savedFeedback.text = "";
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
            StartCoroutine(textFeedback(2, savedFeedback));
        }
        else return; 
    }

    public void hideSubMenu()//hide the are you sure menu 
    {
        subMenu.GetComponent<Animator>().SetBool("movingDown", false);
    }

    public void showSubMenu()//show the are you sure menu 
    {
        if (photo.sprite != null)
        {
            subMenu.SetActive(true);
            subMenu.GetComponent<Animator>().SetBool("movingDown", true);
        }
    }
    public void deleteImage()//remove the image by making it null 
    {
        if(mySprite!=null)
        {
            photo.sprite = null;
            photo.enabled = false; 
        }
        photoBorder.SetActive(false);
        subMenu.GetComponent<Animator>().SetBool("movingDown", false);
       // hideSubMenu(); 

    }

    IEnumerator textFeedback(float t, TMP_Text i)
    {
        savedFeedback.text = "Image Saved!";
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        savedFeedback.text = ""; 
    }
   
}
