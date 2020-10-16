using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject LockedPopUp;

    [SerializeField]
    private Button CLoseButton;

    private Button button;

    [SerializeField]
    private string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
        CLoseButton.onClick.AddListener(CLoseButtonFun);
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                LockedPopUp.SetActive(true);
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;
        }
    }

    private void CLoseButtonFun()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LockedPopUp.SetActive(false);
    }

}
