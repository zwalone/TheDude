using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void OpenMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    public void CloseMenu()
    {
        pauseMenuUI.SetActive(false);
    }

    public void BackToMenu()
    {
        GameManager.Instance.ChangeScene("Menu");
    }
}
