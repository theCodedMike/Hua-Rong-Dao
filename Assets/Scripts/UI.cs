using UnityEngine;

public class UI : MonoBehaviour
{
    public Texture gameOver;


    private void OnGUI()
    {
        if (GameController.gameOver)
        {
            GUI.DrawTexture(new Rect(200, 210, 300, 100), gameOver, ScaleMode.StretchToFill, true, 10.0F);
        }
    }
}
