using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour {

    // Main Menu Input
	public static Action OnLogoClicked;
	public static Action OnManualClicked;
	public static Action OnMultiLayerClicked;
	public static Action OnSkypeClicked;
	public static Action OnHologramClicked;
	public static Action OnFeedbackClicked;
	public static Action OnQRCodeClicked;
    public static Action OnKorschTubeClicked;

    // Manual Input
	public static Action OnManualBackClicked;
	public static Action OnManualNextClicked;
	public static Action OnHomeClicked;
    
    // Videostream Input
	public static Action OnCortanaClicked;

    //Hologram Input
    public static Action OnMachinePartClicked;

    //Feedback Input
    public static Action OnRecordClicked;

    //KorschTube Input
    public static Action OnNextPageClicked;
    public static Action OnPreviousPageClicked;
    public static Action<GameObject> OnThumbnailClicked;
    public static Action OnVideoScreenClicked;

    public static Action<GameObject> OnCubeClicked;


	void OnEnable()
	{
		GazeGestureManager.OnTapped += (tappedObject) =>
		{
			if (tappedObject != null)
			{
                Debug.Log("something got clikced");

                if (tappedObject.name == "Cube(Clone)" && OnCubeClicked != null)
                {
                    Debug.Log("Cube got clicked");
                    OnCubeClicked(tappedObject);
                    return;
                }

				if (tappedObject.name == "Logo" && OnLogoClicked != null)
				{
					OnLogoClicked();
					return;
				}

				if (tappedObject.name == "Manual" && OnManualClicked != null)
				{
					OnManualClicked();
					return;
				}

				if (tappedObject.name == "Multi Layer" && OnMultiLayerClicked != null)
				{
					OnMultiLayerClicked();
					return;
				}

				if (tappedObject.name == "Skype" && OnSkypeClicked != null)
				{
					OnSkypeClicked();
					return;
				}

				if (tappedObject.name == "Hologram" && OnHologramClicked != null)
				{
					OnHologramClicked();
					return;
				}

				if (tappedObject.name == "Feedback" && OnFeedbackClicked != null)
				{
					OnFeedbackClicked();
					return;
				}

                if(tappedObject.name == "KorschTube" && OnKorschTubeClicked != null)
                {
                    OnKorschTubeClicked();
                    return;
                }

				if (tappedObject.name == "ManualBack" && OnManualBackClicked != null)
				{
					OnManualBackClicked();
					return;
				}

				if (tappedObject.name == "ManualNext" && OnManualNextClicked != null)
				{
					OnManualNextClicked();
					return;
				}

				if (tappedObject.name == "Home" && OnHomeClicked != null)
				{
					OnHomeClicked();
					return;
				}

				if (tappedObject.name == "Cortana" && OnCortanaClicked != null)
				{
					OnCortanaClicked();
					return;
				}

				if (tappedObject.name == "QR-Code" && OnQRCodeClicked != null)
				{
					OnQRCodeClicked();
					return;
				}

                if(tappedObject.name == "MachinePart" && OnMachinePartClicked != null)
                {
                    OnMachinePartClicked();
                    return;
                }

                if (tappedObject.name == "Record" && OnRecordClicked!= null)
                {
                    OnRecordClicked();
                    return;
                }

                if(tappedObject.name == "NextPage" && OnNextPageClicked != null)
                {
                    OnNextPageClicked();
                    return;
                }
                if(tappedObject.name == "PreviousPage" && OnPreviousPageClicked != null)
                {
                    OnPreviousPageClicked();
                    return;
                }
                if (tappedObject.name == "Thumbnail" && OnThumbnailClicked != null)
                {
                    OnThumbnailClicked(tappedObject);
                    return;
                }
                if (tappedObject.name == "VideoScreen" && OnVideoScreenClicked!= null)
                {
                    OnVideoScreenClicked();
                    return;
                }
            }
        };
	}

}
