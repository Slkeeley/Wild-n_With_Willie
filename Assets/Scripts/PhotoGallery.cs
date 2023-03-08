using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events; 

public class PhotoGallery : MonoBehaviour
{
    [SerializeField] private Image currPhoto;
    private int photoIndex; 
    public Sprite[] photos;
    // Start is called before the first frame update
    void Start()
    {
        photoIndex = 0; 
        currPhoto.sprite= photos[photoIndex]; 
        StartCoroutine(changePhoto()); 
    }

    IEnumerator changePhoto()
    {
        yield return new WaitForSeconds(5);
        photoIndex++;
        if (photoIndex > photos.Length) photoIndex = 0; 
        currPhoto.sprite = photos[photoIndex]; 
        StartCoroutine(changePhoto());
    }
}
