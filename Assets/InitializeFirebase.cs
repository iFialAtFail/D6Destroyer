using Firebase;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeFirebase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://d6-destroyer.firebaseio.com/");
	}
	
}
