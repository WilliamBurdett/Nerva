using UnityEngine;
using System.Collections;

public class PrintLog : MonoBehaviour {
	static string myLog = "";
	private string output;
	private string stack;

	void OnEnable(){
		Application.logMessageReceived += Log;
	}

	void OnDisable(){
		Application.logMessageReceived -= Log;
	}

	public void Log(string logString, string stackTrace, LogType type){
		output = logString;
		stack = stackTrace;
		myLog = output + "\n" + myLog;
		if (myLog.Length > 5000)
		{
			myLog = myLog.Substring(0, 4000);
		}
	}

	void OnGUI()
	{
		//if (!Application.isEditor) //Do not display in editor ( or you can use the UNITY_EDITOR macro to also disable the rest)
		{
			int size=300;
			myLog = GUI.TextArea(new Rect(size,size, Screen.width - size, Screen.height - size), myLog);
		}
	}
}
