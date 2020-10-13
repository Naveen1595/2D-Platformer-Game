using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button ResumeButton;

    [SerializeField]
    private Button QuitButton;

    [SerializeField]
    private Button NewButton;

    [SerializeField]
    private GameObject LevelSelection;
    private void Awake()
    {
        ResumeButton.onClick.AddListener(Levelslist);
        QuitButton.onClick.AddListener(QuitGame);
        QuitButton.onClick.AddListener(NewGame);
    }
    
    public void Levelslist()
    {
        // SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        Application.Quit();
    }
}
