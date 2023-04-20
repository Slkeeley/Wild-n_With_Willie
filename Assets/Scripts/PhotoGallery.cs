using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 

public class PhotoGallery : MonoBehaviour
{
    [SerializeField] private Image p1;
    [SerializeField] private Image p2;
    public Image currPhoto;
    public Image nextPhoto;
    private int photoIndex; 
    public Sprite[] photos;
    // Start is called before the first frame update
    void Start()
    {
        setPhotoOne(); 
        photoIndex = 0; 
        currPhoto.sprite= photos[photoIndex];
        setNextPhoto();       
    }


    void setPhotoOne()
    {
        currPhoto = p1;
        nextPhoto = p2;
        currPhoto.color = new Color(1, 1, 1, 1);
        nextPhoto.color = new Color(1, 1, 1, 0);
    }

    void setPhototwo()
    {
        currPhoto = p2;
        nextPhoto = p1;
        currPhoto.color = new Color(1, 1, 1, 1);
        nextPhoto.color = new Color(1, 1, 1, 0);
    }
    void setNextPhoto()
    {
        photoIndex++;
        if (photoIndex >= photos.Length) photoIndex = 0;
        nextPhoto.sprite = photos[photoIndex];
        StartCoroutine(changePhoto());
    }
    void setCurrPhoto()
    {
        if (currPhoto == p1)
        {
            Debug.Log("Setting Photo Two"); 
            setPhototwo();
            setNextPhoto(); 
        }
        else
        {
            Debug.Log("Setting Photo One");
            setPhotoOne();
            setNextPhoto(); 
        }
    }

    IEnumerator changePhoto()
    {   
        yield return new WaitForSeconds(3);
        StartCoroutine(fadeOut());
        StartCoroutine(fadeIn()); 
    }

    IEnumerator fadeOut()
    {
        // loop over 1 second backwards
        for (float i = 1.5f; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            currPhoto.color = new Color(1, 1, 1, i);
            yield return null;
        }
       
    }

    IEnumerator fadeIn()
    {
        for (float i = 0; i <= 1.5f; i += Time.deltaTime)
        {
            // set color with i as alpha
            nextPhoto.color = new Color(1, 1, 1, i);
            yield return null;
        }
        setCurrPhoto(); 
    }
}
