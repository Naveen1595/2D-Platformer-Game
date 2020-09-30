
using UnityEngine;

public class MainCameraController : MonoBehaviour
{

    public GameObject PlayerObject;
    public GameObject mainCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 mainCameraPosition = new Vector3(PlayerObject.transform.position.x, PlayerObject.transform.position.y,-50);
        if (PlayerObject.transform.position.y < -6)
        {
            mainCameraPosition.y = -6f;
        }
        mainCamera.transform.position = mainCameraPosition;


    }
}
