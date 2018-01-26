//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;


//public class NetworkController : NetworkBehaviour
//{

//    HolographicMenu holographicMenu;

//    string korschTubeThumbnailName;

//    //TODO find out if it's useful like this
//    [SyncVar(hook = "OnChangeThumbnail")]
//    public string KorschTubeThumbnailNetwork;


//    void Start()
//    {
//        holographicMenu = GetComponent<HolographicMenu>();

//        if (isLocalPlayer)
//            transform.Translate(0, 0.3f, 3);

//        if (!isLocalPlayer && isServer)
//            gameObject.SetActive(false);
//    }


//    void OnEnable()
//    {
//        InputController.OnLogoClicked += () => RpcToggleMainMenu();
//        InputController.OnManualClicked += () => RpcSwitchState(MenuState.Manual);
//        InputController.OnMultiLayerClicked += () => RpcSwitchState(MenuState.Multilayer);
//        InputController.OnSkypeClicked += () => RpcSwitchState(MenuState.Skype);
//        InputController.OnHologramClicked += () => RpcSwitchState(MenuState.Hologram);
//        InputController.OnFeedbackClicked += () => RpcSwitchState(MenuState.Feedback);
//        InputController.OnQRCodeClicked += () => RpcSwitchState(MenuState.QRCode);
//        InputController.OnKorschTubeClicked += () => RpcSwitchState(MenuState.KorschTube);

//        InputController.OnHomeClicked += () => RpcSwitchState(MenuState.MainMenu);

//        InputController.OnManualNextClicked += () => RpcPreviousManual(); ;
//        InputController.OnManualBackClicked += () => RpcNextManual();

//        InputController.OnRecordClicked += () => RpcRecordClicked();

//        InputController.OnThumbnailClicked += (tappedObject) => RpcPlayVideo();
//        InputController.OnVideoScreenClicked += () => RpcPlayPause();

//        VideoController.OnUpdateKey += (obj) => UpdateThumbnail(obj);
//    }

 
//    [ClientRpc]
//    void RpcPlayVideo()
//    {
//        // TODO Not really clean, fix later
//        Invoke("PlayVideo", 0.2f);
//    }


//    [ClientRpc]
//    void RpcPlayPause()
//    {
//        holographicMenu.korschTube.PlayPause();
//    }


//    void UpdateThumbnail(string keyThumbnailName)
//    {
//        KorschTubeThumbnailNetwork = keyThumbnailName;
//    }


//    void PlayVideo()
//    {
//        holographicMenu.korschTube.PlayVideo(korschTubeThumbnailName);
//    }


//    void OnChangeThumbnail(string obj)
//    {
//        korschTubeThumbnailName = obj;
//    }


//    [ClientRpc]
//    void RpcRecordClicked()
//    {
//        holographicMenu.feedback.ToggleRecording();
//    }


//    [ClientRpc]
//    void RpcSwitchState(MenuState state)
//    {
//        holographicMenu.SwitchState(state);
//    }


//    [ClientRpc]
//    void RpcPreviousManual()
//    {
//        holographicMenu.manual.NextSlide();
//    }


//    [ClientRpc]
//    void RpcNextManual()
//    {
//        holographicMenu.manual.PreviousSlide();
//    }


//    [ClientRpc]
//    void RpcToggleMainMenu()
//    {
//        holographicMenu.ToggleMainMenu();
//    }
//}
