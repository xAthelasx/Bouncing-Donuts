using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlank : MonoBehaviour
{
    #region Private Variables
    private float verticalInput;            //Variable que guardar� los axis verticales.
    #endregion
    #region Serializefield Variables
    [SerializeField] private float speed;   //Variable que guardar� la velocidad de movimmiento del plank.
    #endregion
    #region Monobehaviour Method
    private void Update()
    {
        //S�lo podemos mover la plataforma en caso de que el juego se est� ejecutando.
        if (GameState.state == GameState.gamePlay)
        {
            verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime; //Capturamos los inputs.
        }

        if(verticalInput != 0) { Move(); }  //Si el valor de los inputs no es 0 movemos el plank.
    }
    #endregion
    #region Private Method
    /// <summary>
    /// M�todo que se ejecuta siempre y cuando se haya cambiado el valor de verticalInput.
    /// </summary>
    private void Move()
    {
        transform.Translate(new Vector2(verticalInput, 0));    //Movemos el objeto en cuesti�n.
    }
    #endregion
}
