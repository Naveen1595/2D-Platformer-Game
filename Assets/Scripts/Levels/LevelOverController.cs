using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    int currentSceneIndex, nextSceneIndex;
    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        currentSceneIndex = scene.buildIndex;
        nextSceneIndex = currentSceneIndex + 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() !=null)
        {
            LevelManager.Instance.MarkCurrentLevelComplete();
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

}
