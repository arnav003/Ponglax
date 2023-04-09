using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public ScoreManager scoreManager;
	public BallControl ballControl;
	public GameObject pauseMenu;

	public int topScore = 10;

	// Use this for initialization
	void Start () {
		
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape))
    {
			if (!pauseMenu.activeSelf)
			{
				PauseGame();
			}
			else
			{
				ResumeGame();
			}
    }
	}

	public void PauseGame()
    {
		pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

	public void ResumeGame()
    {
		pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

	public void mainMenuButton() {
        //SceneManager.LoadScene("Main Menu");
	}

	public void RestartButton() {
		Restart();
		ResumeGame();
	}

	public void ResumeButton()
	{
		ResumeGame();
	}

	public void Restart(){
		scoreManager.resetScore();
		ballControl.ResetBall();
	}
}
