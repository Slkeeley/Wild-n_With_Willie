using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class screenSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiObjs;
    public GameObject postPictureObjs;

    private void Start()
    {
        postPictureObjs.SetActive(false);
        if (!uiObjs.activeInHierarchy) uiObjs.SetActive(true); 
    }

    public void hideObjs()
    {
            uiObjs.SetActive(false);
            postPictureObjs.SetActive(true); 
       
    }

    public void backToCameraScreen()
    {
            postPictureObjs.SetActive(false);
            uiObjs.SetActive(true);
    }

}
