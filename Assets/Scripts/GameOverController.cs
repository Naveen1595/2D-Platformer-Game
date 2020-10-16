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
        SoundManager.Instance.Play(Sounds.ButtonClick);
        gameObject.SetActive(true);

    }

    private void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    private void MainMenufun()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
