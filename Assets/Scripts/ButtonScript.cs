using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Reference: https://stackoverflow.com/a/41392130

public class ButtonScript : MonoBehaviour
{
    public Button plusButton;
    public Button minusButton;
    public Button viewButton;

    void OnEnable()
    {
        //Register Button Events
        plusButton.onClick.AddListener(() => buttonCallBack(plusButton));
        minusButton.onClick.AddListener(() => buttonCallBack(minusButton));
        viewButton.onClick.AddListener(() => buttonCallBack(viewButton));
    }

    private void buttonCallBack(Button buttonPressed)
    {
        Debug.Log("Clicked: " + buttonPressed.name);
        if (buttonPressed == plusButton)
        {
             Camera.main.GetComponent<TouchManager>().MoveForward(true);
        }

        if (buttonPressed == minusButton)
        {
            Camera.main.GetComponent<TouchManager>().MoveForward(false);

        }
        if (buttonPressed == viewButton)
        {
            Camera.main.GetComponent<TouchManager>().ClearSelection();

        }
    }

    void OnDisable()
    {
        //Un-Register Button Events
        plusButton.onClick.RemoveAllListeners();
        minusButton.onClick.RemoveAllListeners();
        viewButton.onClick.RemoveAllListeners();
    }
}