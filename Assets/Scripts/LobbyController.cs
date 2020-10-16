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
        NewButton.onClick.AddListener(NewGame);
    }
    
    public void Levelslist()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }

    public void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
        
    }

    public void NewGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        PlayerPrefs.DeleteAll(); 
    }
}
