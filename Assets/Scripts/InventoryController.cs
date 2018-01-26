using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    
    public GameObject content;
    public Scrollbar horizontalScrolbar;


    private void OnEnable()
    {
        InputController.OnNextPageClicked += NextPage;
        InputController.OnPreviousPageClicked += PreviousPage;

    }


    private void OnDisable()
    {
        InputController.OnNextPageClicked -= NextPage;
        InputController.OnPreviousPageClicked -= PreviousPage;
    }


    //TODO finish implementation that you can change the slider
    // dynamically instad of having it hardcoded like this
    public void NextPage()
    {
        horizontalScrolbar.value += 1;
    }


    public void PreviousPage()
    {        
        horizontalScrolbar.value -= 1;
    }
}
