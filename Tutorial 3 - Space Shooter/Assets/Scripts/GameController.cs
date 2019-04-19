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

    public Text PointsText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;

    private bool gameOver;
    private bool restart;
    private int points;

    public AudioClip win;
    public AudioClip lose;

    //testing
    //public GameObject s;
    public BGScroller BGSpeed;
    public BGScroller SFSpeed;

    private void Start() {

        gameOver = false;
        restart = false;

        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";

        points = 0;
        UpdatePoints();
        StartCoroutine (SpawnWaves());


    }

    private void Update() {

        if (restart) {

            if(Input.GetKeyDown(KeyCode.E)) {

                SceneManager.LoadScene("Main");

            }

        }

        if (Input.GetKey("escape")) {

            Application.Quit();

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

        PointsText.text = "Points: " + points.ToString();
        if(points >= 100) {

            winText.text = "You Win!";
            gameOverText.text = "GAME CREATED BY MARIA BARAHONA";
            gameOver = true;
            restart = true;

            //testing
            BGSpeed.scrollSpeed = -10.00f;
            SFSpeed.scrollSpeed = -10.00f;


            AudioSource audio = GetComponent<AudioSource>();
            audio.Stop(); audio.clip = win;
            audio.Play();
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
