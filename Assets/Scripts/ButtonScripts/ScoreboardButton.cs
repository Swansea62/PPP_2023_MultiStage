using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScoreboardButton : MonoBehaviour, IPointerClickHandler
{

    public Button scoreboardButton;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        scoreboardButton.interactable = (DBManager.LoggedIn);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Left & DBManager.LoggedIn)
        {
            Loader.Load(Loader.Scene.Scoreboard);
        }
    }
}
