using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumePauseBtn : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject gameManager;
    public GameObject[] UIOnPauseDisabled;

    public void pauseBtn()
    {
        pauseMenu.SetActive(true);
        gameManager.SetActive(false);
        Time.timeScale = 0;
        foreach (GameObject UIElement in UIOnPauseDisabled)
        {
            UIElement.SetActive(false);
        }
    }

    public void resumeBtn()
    {
        pauseMenu.SetActive(false);
        foreach (GameObject UIElement in UIOnPauseDisabled)
        {
            UIElement.SetActive(true);
        }
        Time.timeScale = 1;
        gameManager.SetActive(true);
    }

}
