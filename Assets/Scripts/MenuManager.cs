using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject creditsOverlay;

	public void StartGame() {
        SceneManager.LoadScene("TestLights");
    }

    public void ToggleCredits() {
        creditsOverlay.SetActive(!creditsOverlay.activeSelf);
    }
	
	public void QuitGame() {
        Application.Quit();
    }
}
