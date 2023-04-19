using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; 

public class screenSwitch : MonoBehaviour
{
    
    public GameObject[] uiObjs;
    public GameObject screenButtons;
    public GameObject postPictureObjs;
   [SerializeField] private TakePicture PhoneCamera; 

    private void Start()
    {
        postPictureObjs.SetActive(false);
        if (!screenButtons.activeInHierarchy) screenButtons.SetActive(true); 
    }

    public void hideObjs()
    {
    
        foreach (GameObject i in uiObjs)
        {
            i.GetComponent<Image>().color = new Color(255, 255, 255, 0.0f);
        }
        PhoneCamera.captureImage(); 
        StartCoroutine(showPostPicture());
       
    }

    public void backToCameraScreen()
    {
        if (PhoneCamera.mySprite != null)
        {
            PhoneCamera.saveSprite(); 
        }
            foreach (GameObject i in uiObjs)
        {
            i.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

        PhoneCamera.photo.enabled = true; 
        postPictureObjs.SetActive(false);
            
    }

    IEnumerator showPostPicture()
    {
        yield return new WaitForSeconds(.2f);
        postPictureObjs.SetActive(true);
    }
}
