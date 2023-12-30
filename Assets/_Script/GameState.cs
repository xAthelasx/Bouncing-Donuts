using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    #region Public Variables
    public static int state;            //Variable que guardar� el estado del juego.
    public static int level = 1;        //Indica el nivel que se est� ejecutando.

    public const int gamePlay = 1;      //Constante que nos indicar� que el juego se est� ejecutando.
    public const int gameOver = 2;      //Cosntante que nos indicar� que se ha llegado al final del juego.
    public const int levelComplete = 3; //Constante que nos indicar� qu eel nivel ha sido completado.
    #endregion
    #region Monobehaviour Method
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //Impedimos que el GO se destruya.
    }
    private void Start()
    {
        state = gamePlay;               //Inicializamos la variable a que el juego se est� ejecutando.
    }
    #endregion
}
