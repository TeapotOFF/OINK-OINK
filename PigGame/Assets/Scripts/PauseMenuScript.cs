using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _heartBar;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pauseMenu.activeSelf && _heartBar.activeSelf)
        {
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
            _heartBar.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _pauseMenu.activeSelf && !_heartBar.activeSelf)
        {
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
            _heartBar.SetActive(true);
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
