using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDebugger :MonoBehaviour {
	private const bool DEBUG_ENABLE = false;
	private const string TAG = "CLF";


	internal static void Log(string message){
		if (DEBUG_ENABLE)
			Debug.logger.Log (TAG, message);
	}
	internal static void LogError(string message){
		if (DEBUG_ENABLE)
			Debug.logger.LogError (TAG, message);
	}

	internal static void Logs(string message)
	{
		if (DEBUG_ENABLE)
			Debug.logger.LogWarning (TAG, message);
	}	
}
