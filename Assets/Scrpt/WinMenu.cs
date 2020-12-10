using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public static bool isWin = false;
    public GameObject WinMenuUI;
	public GameObject sText;
    // Update is called once per frame
    void Update()
    {
        if(isWin){
		Win();
	}
    }

    public void Restart()
    {
	isWin = false;
        WinMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
	sText.GetComponent<Text>().text = "Score: " + scoreText.score.ToString();
        WinMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
