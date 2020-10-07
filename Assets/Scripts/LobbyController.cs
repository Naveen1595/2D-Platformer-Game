using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button PlayButton;
    private void Awake()
    {
        PlayButton.onClick.AddListener(LevelOne);
    }
    
    public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }
}
