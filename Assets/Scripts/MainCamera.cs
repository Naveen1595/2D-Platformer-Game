using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public GameObject PlayerObject;
    public GameObject mainCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 mainCameraposition = new Vector3(PlayerObject.transform.position.x, PlayerObject.transform.position.y,-50);
        mainCamera.transform.position = mainCameraposition;

    }
}
