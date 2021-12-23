using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectElement : MonoBehaviour
{
    public GameObject interaction;

    public void onSelectTree()
    {
        GameObject selectedButton = EventSystem.current.currentSelectedGameObject;
        GameObject prefab = Resources.Load("ChristmasTree1") as GameObject;
        switch (selectedButton.name)
        {
            case "Tree 1 Image Button":
                prefab = Resources.Load("ChristmasTree1") as GameObject;
                break;
            case "Tree 2 Image Button":
                prefab = Resources.Load("ChristmasTree2") as GameObject;
                break;
            case "Tree 3 Image Button":
                prefab = Resources.Load("ChristmasTree3") as GameObject;
                break;
            case "Tree 4 Image Button":
                prefab = Resources.Load("ChristmasTree4") as GameObject;
                break;
        }
        interaction.GetComponent<TapToPlace>().ChangePrefab(prefab);
    }

    public void onSelectOrnaments()
    {
        GameObject selectedButton = EventSystem.current.currentSelectedGameObject;
        GameObject prefab = Resources.Load("Ball_Blue") as GameObject;
        switch (selectedButton.name)
        {
            case "Ornaments 1 Image Button":
                prefab = Resources.Load("Ball_Blue") as GameObject;
                break;
            case "Ornaments 2 Image Button":
                prefab = Resources.Load("Ball_Cyan") as GameObject;
                break;
            case "Ornaments 3 Image Button":
                prefab = Resources.Load("Ball_Red") as GameObject;
                break;
            case "Ornaments 4 Image Button":
                prefab = Resources.Load("Candy_Blue") as GameObject;
                break;
            case "Ornaments 5 Image Button":
                prefab = Resources.Load("Candy_Purple") as GameObject;
                break;
            case "Ornaments 6 Image Button":
                prefab = Resources.Load("Gift_Red") as GameObject;
                break;
            case "Ornaments 7 Image Button":
                prefab = Resources.Load("Gift_White") as GameObject;
                break;
            case "Ornaments 8 Image Button":
                prefab = Resources.Load("Gift_Yellow") as GameObject;
                break;
        }
        interaction.GetComponent<TapToPlace>().ARPlaceObject(prefab);
    }
}
