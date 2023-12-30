using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    #region Public Variables
    public static int state;            //Variable que guardará el estado del juego.
    public static int level = 1;        //Indica el nivel que se está ejecutando.

    public const int gamePlay = 1;      //Constante que nos indicará que el juego se está ejecutando.
    public const int gameOver = 2;      //Cosntante que nos indicará que se ha llegado al final del juego.
    public const int levelComplete = 3; //Constante que nos indicará qu eel nivel ha sido completado.
    #endregion
    #region Monobehaviour Method
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //Impedimos que el GO se destruya.
    }
    private void Start()
    {
        state = gamePlay;               //Inicializamos la variable a que el juego se está ejecutando.
    }
    #endregion
}
