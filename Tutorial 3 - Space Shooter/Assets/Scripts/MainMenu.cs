using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayMain () {
        
        SceneManager.LoadScene("Main");

    }

    public void PlayTime () {

        SceneManager.LoadScene("Time");

    }

    public void QuitButton() {

        Application.Quit();

    }


}
