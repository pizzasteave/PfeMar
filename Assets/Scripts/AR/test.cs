using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

[System.Serializable]
public class Pair
{
    public string doortitle;
    public GameObject doorModel;

}

public class test : MonoBehaviour
{

    public static GameObject chosenModel;


    public List<Pair> doorNames = new List<Pair>();

    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    [SerializeField]
    GameObject infoPanel;

    [SerializeField]
    TextMeshProUGUI imageName;

    [SerializeField]
    Button btn;


    string currentName;
    ARTrackedImage currentImage;


    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            currentImage = trackedImage;
          
            if(trackedImage.trackingState != TrackingState.Tracking)
            {
                ClearCurrentImage();
            }
            else
            {
                GetCurrentImage(trackedImage);
            }

        }

        foreach (var trackedImage in eventArgs.updated)
        {
            currentImage = trackedImage;

            if (trackedImage.trackingState != TrackingState.Tracking)
            {
                ClearCurrentImage();
            }
            else
            {
                GetCurrentImage(trackedImage);
            }
        }

    }

    private void ClearCurrentImage()
    {
        imageName.text ="Try to scan a target";
        btn.interactable = false;    
    }

    private void GetCurrentImage(ARTrackedImage trackedImage)
    {
        btn.interactable = true;
        currentName = imageName.text = trackedImage.referenceImage.name; 
    }




    public void OnValidate()
    {

        foreach (var element in doorNames)
        {
            if (currentName == element.doortitle)
            {
                chosenModel = element.doorModel;
                SceneManager.LoadScene("3D");
            }
        }

    }


}
