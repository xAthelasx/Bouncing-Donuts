using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    #region  Public Variables
    public string gameScene;            //Variable que guardará la escena a la que se va a ir.
    #endregion
    #region Public Method
    public void PlayGame() 
    {
        Scoring.gamescore = 0;          //Inicializamos la puntuación.
        GameState.level = 1;            //Retornamos el valor de la constante al arranque.
        SceneManager.LoadScene("Scenes/Level 1"); //Método que carga la escena de jugar.
    }   
    public void ExitGame() { Application.Quit(); }                  //Método que se encarga de cerrar el juego.
    #endregion
}
