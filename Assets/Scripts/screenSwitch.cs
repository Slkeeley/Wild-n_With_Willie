using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class screenSwitch : MonoBehaviour
{
    
    public GameObject[] uiObjs;
    public GameObject screenButtons;
    public GameObject postPictureObjs;
    public ARPlaneManager planeManager; 
   [SerializeField] private TakePicture PhoneCamera; 
   [SerializeField] private AudioClip[] sounds;
    private AudioSource source; 


    private void Start()
    {
        postPictureObjs.SetActive(false);
        source = GetComponent<AudioSource>(); 
        if (!screenButtons.activeInHierarchy) screenButtons.SetActive(true);
       
    }
    public void takePicture()
    {
        hideObjs();
        playSound(0); 
        StartCoroutine(showPostPictureCR());
    }

    public void hideObjs()
    {
        Debug.Log("Starting event"); 
        foreach (GameObject i in uiObjs)
        {
            i.GetComponent<Image>().color = new Color(255, 255, 255, 0.0f);
        }
    }

    public void backToCameraScreen()
    {
     /*   if (PhoneCamera.mySprite != null)
        {
            PhoneCamera.saveSprite(); 
        }*/
            foreach (GameObject i in uiObjs)
        {
            i.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

        PhoneCamera.photo.enabled = true; 
        postPictureObjs.SetActive(false);
        SetActiveAllPlanes(true); 
            
    }

    public void SetActiveAllPlanes(bool value)
    {
        foreach (var planes in planeManager.trackables)
        {
            planes.gameObject.SetActive(value); 
        }
    }

    public void playSound(int soundIndex)
    {
        Debug.Log("sound");
        source.PlayOneShot(sounds[soundIndex]);
    }

    public void showPostPicture()
    {
        StartCoroutine(showPostPictureCR());
    }
    IEnumerator showPostPictureCR()
    {
        //EFFECTS HERE 
        SetActiveAllPlanes(false);
        yield return new WaitForEndOfFrame();
        PhoneCamera.captureImage(); 
        postPictureObjs.SetActive(true);
        if(!PhoneCamera.photoBorder.activeInHierarchy)
        {
            PhoneCamera.photoBorder.SetActive(true); 
        }
        
    }
}
