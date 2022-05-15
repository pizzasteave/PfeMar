using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager1 : MonoBehaviour
{
    [Header("Text")]
    public GameObject textButton;
    public GameObject selectedTextButton;
    public GameObject displayPanelText;

    [Header("Video")]
    public GameObject videoButton;
    public GameObject selectedVideoButton;
    public GameObject displayPanelVideo;
    
    
    public void OnText()
    {
        if (displayPanelText.activeSelf)
        {
            Closetext();
        }else
        {
            CloseVideo();
            OpenText();
        }
    }


    void Closetext()
    {
        selectedTextButton.SetActive(false);
        textButton.SetActive(true);

        displayPanelText.SetActive(false);
    }

    void OpenText()
    {
        selectedTextButton.SetActive(true);
        textButton.SetActive(false);

        displayPanelText.SetActive(true);

    }

    public void OnVideo()
    {
        if (displayPanelVideo.activeSelf)
        {
            CloseVideo();
        }
        else
        {
            Closetext();
            OpenVideo();
        }
    }


    void CloseVideo()
    {
        selectedVideoButton.SetActive(false);
        videoButton.SetActive(true);

        displayPanelVideo.SetActive(false);
    }

    void OpenVideo()
    {
        selectedVideoButton.SetActive(true);
        videoButton.SetActive(false);

        displayPanelVideo.SetActive(true);
    }
}
