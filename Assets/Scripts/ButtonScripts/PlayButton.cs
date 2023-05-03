using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour, IPointerClickHandler
{
    public Button playButton; 

    // Start is called before the first frame update
    void Start()
    {
        playButton.interactable = (DBManager.LoggedIn); //Stops the play button from being interactable
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left & DBManager.LoggedIn) //Stops the play button from being interactable
        {
            Loader.Load(Loader.Scene.MultiStage_Level_1);
        }
    }
}
