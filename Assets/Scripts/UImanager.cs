using System.Collections;
using Assets.SimpleSlider.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject[] otherUI;


    // Update is called once per frame
    void Update()
    {
        if(HorizontalScrollSnap.Instance.GetCurrentPage() == 2)
        {
           foreach(var ui in otherUI)
            {
                ui.SetActive(false);
            }
             
            startButton.SetActive(true);      
        }
    }

    public void OnNext()
    {
        HorizontalScrollSnap.Instance.SlideNext(); 
    } 

    public void OnSkip()
    {
        var calls = 2 - HorizontalScrollSnap.Instance.GetCurrentPage();

        HorizontalScrollSnap.Instance.SlideNext();
        HorizontalScrollSnap.Instance.SlideNext();
    }

    public void OnStart()
    {
        SceneManager.LoadScene("AR");
    }
}
