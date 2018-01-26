﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWindow : MonoBehaviour
{
    TextMesh textMesh;

	void Start()
	{
		textMesh = gameObject.GetComponent<TextMesh>();
	}


    void OnEnable()
	{
		Application.logMessageReceived += LogMessage;
	}

	void OnDisable()
	{
		Application.logMessageReceived -= LogMessage;
	}

	public void LogMessage(string message, string stackTrace, LogType type)
	{
		if (textMesh.text.Length > 300)
		{
			textMesh.text = message + "\n";
		}
		else
		{
			textMesh.text += message + "\n";
		}
	}

}

