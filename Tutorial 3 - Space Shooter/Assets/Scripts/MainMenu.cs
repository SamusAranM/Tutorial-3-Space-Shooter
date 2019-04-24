using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayMain () {
        
        SceneManager.LoadScene("Main");

    }

    public void PlayHard () {

        SceneManager.LoadScene("Hard");

    }

    public void QuitButton() {

        Application.Quit();

    }


}
