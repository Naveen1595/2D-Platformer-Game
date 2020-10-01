using UnityEngine;
public class MainCameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerObject;

    [SerializeField]
    private GameObject mainCamera;

    float minPosition = -6f;

   
    // Update is called once per frame
    private void Update()
    {
        Vector3 mainCameraPosition = new Vector3(PlayerObject.transform.position.x, PlayerObject.transform.position.y,-50);
        if (PlayerObject.transform.position.y < minPosition)
        {
            mainCameraPosition.y = minPosition;
        }
        mainCamera.transform.position = mainCameraPosition;


    }
}
