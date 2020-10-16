using UnityEngine;
using System.Collections;
public class LevelSelectionPopUp : MonoBehaviour
{
    bool EscapePressed = false;
    
    [SerializeField]
    private GameObject LevelSelection;

    private void FixedUpdate()
    {
        EscapePressed = Input.GetKey(KeyCode.Escape);
        //Delay using DeltaTime for LevelSelectionFun OR Use KeyPressedUP
        LevelSelectionFun(EscapePressed);
    }


    void LevelSelectionFun(bool EscapePressed)
    {
        if (EscapePressed)
        {
            if (LevelSelection.activeSelf)
            {
                
                LevelSelection.SetActive(false);
            }
            else
            {
                
                LevelSelection.SetActive(true);
            }
        }
    }
}
