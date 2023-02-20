using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject inputField;

	public int topScore = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
			ExitButton();
        }
    }

    public void StartButton() {
        SceneManager.LoadScene("Main");
    }

    public void SetScoreLimit() {
        string text = inputField.GetComponent<TMP_InputField>().text;
        int.TryParse(text, out topScore);
    }

    public void ExitButton() {
        Debug.Log("Exiting");
        Application.Quit();
    }
}
