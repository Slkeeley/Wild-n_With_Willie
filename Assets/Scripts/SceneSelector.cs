using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneSelector : MonoBehaviour
{
    public GameObject subMenu; 
    public void toInstructions()//go to the instructions screen; 
    {
        SceneManager.LoadScene("InstructionsScreen"); 
    }

    public void toCamera()//go to the camera scene 
    {
        SceneManager.LoadScene("CameraScreen"); 
    }

    public void toInfo()//after the picture was taken go to the post picture screen
    {
        SceneManager.LoadScene("InfoScreen"); 
    }

    public void closeApp()//if a user would like to exit the app from the camera screen use this
    {
        Debug.Log("Attempting to Quit"); 
        Application.Quit(); 
    }

    public void toWelcomeScreen()
    {
        SceneManager.LoadScene("WelcomeScreen"); 
    }

    public void hideSubMenu()//hide the are you sure menu 
    {
        subMenu.GetComponent<Animator>().SetBool("movingDown", false);
    }

    public void showSubMenu()//show the are you sure menu 
    {
            subMenu.SetActive(true);
            subMenu.GetComponent<Animator>().SetBool("movingDown", true);
    }
}


