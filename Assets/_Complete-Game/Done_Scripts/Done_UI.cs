using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Done_UI : MonoBehaviour {

    public Texture gameOver;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        //显示结束的UI
        if(Done_MouseEvent.over)
        {
            GUI.DrawTexture(new Rect(200, 210, 300, 100), gameOver, ScaleMode.StretchToFill, true, 10.0F);
            FindObjectOfType<Done_MouseEvent>().enabled = false;
        }
    }
}
