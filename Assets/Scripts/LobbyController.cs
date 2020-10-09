using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button PlayButton;

    [SerializeField]
    private GameObject LevelSelection;
    private void Awake()
    {
        PlayButton.onClick.AddListener(LevelOne);
    }
    
    public void LevelOne()
    {
        // SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }
}
