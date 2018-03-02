using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

    public void PlayButton()
    {
        SceneManager.LoadScene("Week6_2");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
