using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour {

    public GameObject gameOverOverlay;
    public TMP_Text gameOverText;

    public PlayerInventory inventory;

    public LightDetector lightDetector;

    public GameObject pauseOverlay;
    public GameObject tutorialOverlay;

    public Transform courageBar;
    float innitalSize;

    public TMP_Text timer;
    string timerPreset;

    public int innitialTime = 900;
    float startTime;

    string tutorial = "ad f";

    public float maxCourage = 100f;
    public float courageScale = 1f;
    float courage;

    bool gameEnded = false;

    void Start() {
        timerPreset = timer.text;
        innitalSize = courageBar.localScale.x;
        courage = maxCourage;
        Time.timeScale = 1f;
        startTime = Time.time;
    }

    public void Resume() {
        // Disable pause overlay
        pauseOverlay.SetActive(false);
        // Game speed back to normal
        Time.timeScale = 1f;
        startTime = Time.time;
    }

    public void EndGame(string message) {
        Time.timeScale = 0f;
        gameOverOverlay.SetActive(true);
        gameOverText.SetText(message);
        gameEnded = true;
    }

    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameEnded) {
            gameOverOverlay.SetActive(false);
            // If player is in dark
            if (lightDetector.inDark) {
                // Reduce his courage
                courage -= Time.deltaTime * courageScale;
            // If player is holding something
            } else if(inventory.holding != null) {
                // Reduce his corage in half the speed
                courage -= Time.deltaTime * courageScale / 2;
            }
            // If courage ended, kill the player
            if (courage <= 0) {
                EndGame("You were too frightened to continue\nBetter luck next time");
            }
            // Resize the courage bar
            Vector3 s = courageBar.localScale;
            s.x = innitalSize * (1 - Mathf.Sqrt(1 - courage / maxCourage));
            courageBar.localScale = s;
            // If player presses ESC
            if (Input.GetKeyDown(KeyCode.Escape)) {
                // Toggle the pause
                pauseOverlay.SetActive(!pauseOverlay.activeSelf);
                // Set the time scale according to the game state
                Time.timeScale = pauseOverlay.activeSelf ? 0 : 1;
            } else if (!pauseOverlay.activeSelf && Input.anyKeyDown) {
                // If button pressed is in the preset string
                if (tutorial.Contains(Input.inputString)) {
                    // Remove it
                    tutorial = tutorial.Remove(tutorial.IndexOf(Input.inputString), 1);
                    // And if the string's empty
                    if (tutorial.Length == 0) {
                        // Remove the tutorial
                        tutorialOverlay.SetActive(false);
                    }
                }
            }
            // Set timer text according to current time
            int time = Mathf.FloorToInt(innitialTime - (Time.time - startTime));
            timer.SetText(timerPreset + time);
            if (time <= 0) {
                EndGame("You ran out of time\nBetter luck next time");
            }
        } else if (Input.anyKeyDown) {
            GoToMenu();
        }
	}
}
