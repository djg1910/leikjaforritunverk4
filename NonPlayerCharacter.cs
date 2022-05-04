using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    //býr til taltextann
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;
   
    void Start()
    {
        //lætur taltextann ekki vera á um leið og leikurinn byrjar
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        //kveikir á taltexta
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
