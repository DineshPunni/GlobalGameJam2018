using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GazeGestureManager : MonoBehaviour {

	GameObject focusedObject;
	UnityEngine.XR.WSA.Input.GestureRecognizer recognizer;

	public static Action<GameObject> OnTapped;

    public Color korschBlue;

	void Start () {

		recognizer = new UnityEngine.XR.WSA.Input.GestureRecognizer();
		recognizer.TappedEvent += (source,tapCount,ray) =>
		{
			if (OnTapped != null)
				OnTapped(focusedObject);
		};

		recognizer.StartCapturingGestures();
	}
	
	void Update () {

		GameObject oldFocusObject = focusedObject;

		var headPosition = Camera.main.transform.position;
		var gazeDirection = Camera.main.transform.forward;

		RaycastHit hitInfo;
		if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
		{
			focusedObject = hitInfo.collider.gameObject;
		}
		else
		{
			focusedObject = null;
		}

		if (focusedObject != oldFocusObject)
		{
			recognizer.CancelGestures();
			recognizer.StartCapturingGestures();
        }
    }
}
