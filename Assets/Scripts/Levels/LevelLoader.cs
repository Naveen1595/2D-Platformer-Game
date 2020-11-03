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
                //Debug.Log("Sorry It's Locked");
                LockedPopUp.SetActive(true);
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }

    private void CLoseButtonFun()
    {
        LockedPopUp.SetActive(false);
    }

}
