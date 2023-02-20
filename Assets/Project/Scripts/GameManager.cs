using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static int PlayerScore1 = 0;
	public static int PlayerScore2 = 0;

	public GameObject pauseMenu;

	public int topScore = 10;

	public GUISkin layout;

	GameObject theBall;

	// Use this for initialization
	void Start () {
		theBall = GameObject.FindGameObjectWithTag ("Ball");
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

	public static void Score(string wallID) {
		if (wallID == "RightWall") {
			PlayerScore1++;
		} else {
			PlayerScore2++;
		}
	}

	void OnGUI() {
		GUI.skin = layout;
		GUI.Label (new Rect (Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
		GUI.Label (new Rect (Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

		if (GUI.Button (new Rect (Screen.width / 2 - 60, 35, 120, 53), "RESTART")) {
			Restart();
		}

		if (PlayerScore1 == topScore) {
			GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		} else if (PlayerScore2 == topScore) {
			GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
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
        SceneManager.LoadScene("Main Menu");
  }

	public void RestartButton() {
		Restart();
		ResumeGame();
	}

	public void Restart(){
			PlayerScore1 = 0;
			PlayerScore2 = 0;
			theBall.SendMessage ("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
	}
}
