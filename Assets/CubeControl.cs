using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {

    bool isGreen;
    NetworkController netController;

    private void OnEnable()
    {
        netController = FindObjectOfType<NetworkController>();
        InputController.OnCubeClicked += (tappedObject) => ChangeColor(tappedObject);
    }


    void ChangeColor(GameObject tappedObj)
    {
        if (isGreen)
        {
            tappedObj.GetComponent<Renderer>().material.color = Color.red;
            isGreen = false;
        }
        else
        {
            tappedObj.GetComponent<Renderer>().material.color = Color.green;
            isGreen = true;
        }


    }



    // Use this for initialization
    void Start () {

        transform.Translate(0, 0.2f, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
