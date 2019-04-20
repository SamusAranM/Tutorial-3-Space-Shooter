using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    //works
    public float currentTime;
    public float startingTime;

    public Text PointsText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text countdownText;
    public Text mainMenuText; //works

    private bool gameOver;
    private bool restart;
    private int points;

    public AudioClip win;
    public AudioClip lose;
    
    //works
    public BGScroller BGSpeed;
    public BGScroller SFSpeed;

    //testing
    //public Mover speed1;
    //public Mover speed2;
    //public Mover speed3;

    private void Start() {

        gameOver = false;
        restart = false;

        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        mainMenuText.text = "";

        points = 0;
        UpdatePoints();
        StartCoroutine (SpawnWaves());
        currentTime = startingTime;

    }

    private void Update() {

        Scene scene = SceneManager.GetActiveScene();

        string sceneName = scene.name;

        if (sceneName == "Main") {
            if (restart) {

                if (Input.GetKeyDown(KeyCode.E)) {

                    SceneManager.LoadScene("Main");

                }

                if (Input.GetKeyDown(KeyCode.M)) {

                    SceneManager.LoadScene("Menu");

                }

            }

        }

        if (sceneName == "Time" || sceneName == "Hard") {
            if (restart) {

                if (Input.GetKeyDown(KeyCode.E)) {

                    SceneManager.LoadScene("Time");

                }

                if (Input.GetKeyDown(KeyCode.M)) {

                    SceneManager.LoadScene("Menu");

                }

            }

        }

        if (Input.GetKey("escape")) {

            Application.Quit();

        }

        //works
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

    }

    IEnumerator SpawnWaves() {

        yield return new WaitForSeconds(startWait);
        
        while(true) {

            for (int i = 0; i < hazardCount; i++) {

                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);

            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver) {

                restartText.text = "Press 'E' to Restart";
                mainMenuText.text = "Press 'M' for Main Menu";

                restart = true;
                break;

            }

        }

    }

    public void AddPoints(int newPointsValue) {

        points += newPointsValue;
        UpdatePoints();

    }

    void UpdatePoints() {

        //works

        Scene scene = SceneManager.GetActiveScene();

        string sceneName = scene.name;

        PointsText.text = "Points: " + points.ToString();

        if (sceneName == "Main") {

            //use this for "Hard"
            //speed1.speed = -20f;
            //speed2.speed = -20f;
            //speed3.speed = -20f;

            if (points >= 100) {

                winText.text = "You Win!";
                gameOverText.text = "GAME CREATED BY MARIA BARAHONA";
                mainMenuText.text = "Press 'M' for Main Menu";
                gameOver = true;
                restart = true;

                //works
                BGSpeed.scrollSpeed = -10.00f;
                SFSpeed.scrollSpeed = -10.00f;

                //kind of
                AudioSource audio = GetComponent<AudioSource>();
                audio.Stop(); audio.clip = win;
                audio.Play();

            }

        }

        if (sceneName == "Time") {

            if (currentTime <= 0) {

                winText.text = "Great Job!";
                gameOverText.text = "GAME CREATED BY MARIA BARAHONA";
                mainMenuText.text = "Press 'M' for Main Menu";
                gameOver = true;
                restart = true;

                //works
                BGSpeed.scrollSpeed = -10.00f;
                SFSpeed.scrollSpeed = -10.00f;

                //Kind of
                AudioSource audio = GetComponent<AudioSource>();
                audio.Stop(); audio.clip = win;
                audio.Play();

            }

        }


    }

    public void GameOver() {

        gameOverText.text = "Game Over!";
        gameOver = true;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Stop(); audio.clip = lose;
        audio.Play();
    }

}
