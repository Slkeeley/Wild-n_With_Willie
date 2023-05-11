using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

public class socialMediaButtons : MonoBehaviour
{
    [SerializeField] private TakePicture PhoneCamera;
    public void clickShare()
    {
        StartCoroutine(shareToSocials()); 
    }

    IEnumerator shareToSocials()
    {
        yield return new WaitForEndOfFrame();
        if (PhoneCamera.mySprite != null)
        {
            PhoneCamera.saveSprite(); 
            Texture2D photoToShare = PhoneCamera.mySprite.texture;
         
            string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
            File.WriteAllBytes(filePath, photoToShare.EncodeToPNG());

            Destroy(photoToShare);

            new NativeShare().AddFile(filePath).SetSubject("Rockin' With Ru").SetText("#RockinWithRu").Share(); 
        }
    }

}
