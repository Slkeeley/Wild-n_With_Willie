using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneSelector : MonoBehaviour
{
    public void toInstructions()//go to the instructions screen; 
    {
        SceneManager.LoadScene("InstructionsScreen"); 
    }

    public void toCamera()//go to the camera scene 
    {
        SceneManager.LoadScene("CameraScreen"); 
    }

    public void toPostPicture()//after the picture was taken go to the post picture screen
    {
        SceneManager.LoadScene("PostPictureScreen"); 
    }

    public void closeApp()//if a user would like to exit the app from the camera screen use this
    {
        Debug.Log("Attempting to Quit"); 
        Application.Quit(); 
    }

    private void Update()//use this to simulate taking a photo for debugging purposes. 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("PostPictureScreen");
        }
    }
        
  }


