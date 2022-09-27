using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource openMenu;
    public AudioSource closeMenu;
    public AudioSource buttonClick;
    public GameObject creditsPanel;
    public GameObject settingsPanel;

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToRecipes()
    {
        SceneManager.LoadScene("RecipeSelect");
    }

    public void PlayButtonClick()
    {
        buttonClick.Play();

    }

    public void PlayOpenMenu()
    {
        openMenu.Play();

    }

    public void PlayCloseMenu()
    {
        closeMenu.Play();

    }

    public void StartGame()
    {
        buttonClick.Play();
        //StartCoroutine(ExecuteAfterTime(2f));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //A coroutine to allow a button sound to play before next action
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
    }

    public void OpenCreditsPanel()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCreditsPanel()
    {
        creditsPanel.SetActive(false);
    }

    public void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    public void Mute()
    {
        AudioListener.volume = 0;
    }
}
