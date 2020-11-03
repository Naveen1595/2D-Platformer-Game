using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Button buttonRestart,MainMenu;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        MainMenu.onClick.AddListener(MainMenufun);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);

    }

    private void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    private void MainMenufun()
    {
        SceneManager.LoadScene(0);
    }
}
