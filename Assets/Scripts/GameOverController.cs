using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Button buttonRestart;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        gameObject.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
        

    }
}
