﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class NetworkController : NetworkBehaviour
{

    public bool isGreen;

    void Start()
    {
        //if (isLocalPlayer)
        //    transform.Translate(0, 0.3f, 3);

        //if (!isLocalPlayer && isServer)
        //    gameObject.SetActive(false);
    }


    void OnEnable()
    {
        //InputController.OnLogoClicked += () => RpcToggleMainMenu();
        //InputController.OnManualClicked += () => RpcSwitchState(MenuState.Manual);

        InputController.OnCubeClicked += (tappedObject) => RpcChangeColor(tappedObject);

    }

    private void RpcChangeColor(GameObject tappedObj)
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

    //[ClientRpc]
    //void RpcPlayVideo()
    //{
    //    // TODO Not really clean, fix later
    //    Invoke("PlayVideo", 0.2f);
    //}

    
}
