using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartMenu : MonoBehaviour
{
    public static bool isDead = false;
    public GameObject restartMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Lose();
        }
    }

    public void Restart()
    {
        restartMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Lose()
    {
        restartMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
