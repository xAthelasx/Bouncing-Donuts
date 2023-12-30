using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    #region Public Variables
    public static int gamescore;                        //Variable que guardará la puntuación alcanzada.
    #endregion
    #region Monobehaviour method
    private void Start()
    {
        gamescore = 0;                                  //Inicializamos el gamescore.
    }
    #endregion
    #region OnGUI method
    private void OnGUI()
    {
        GUI.skin.box.fontSize = 30;                                     //Crea el tamaño del texto.
        GUI.Box(new Rect(20, 20, 200, 50), "Score:" + gamescore);       //Crea la caja de la UI.
        GUI.Box(new Rect(Screen.width - 220, 20, 200, 50), "Level:" + GameState.level); //Insertamos otra caja para el nivel.
        
        if(GameState.state == GameState.gameOver)
        {
            GUI.skin.box.fontSize = 60;
            GUI.Box(new Rect(
                Screen.width / 2 - 200,
                Screen.height / 2 - 50,
                400,
                100),
                "Game Over");
        }
        if (GameState.state == GameState.levelComplete)
        {
            GUI.skin.box.fontSize = 60;
            GUI.Box(new Rect(
                Screen.width / 2 - 250,
                Screen.height / 2 - 50,
                500,
                100),
                "Level Complete");
        }
    }
    #endregion
}
