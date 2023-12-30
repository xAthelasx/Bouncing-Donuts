using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region SerializeField Variables
    [SerializeField] private Transform donutsPosition;  //Variable para saber la posici�n del donuts.
    #endregion
    #region Monobehaviour Method
    private void Update()
    {
        this.transform.position = new Vector3(donutsPosition.position.x, this.transform.position.y, this.transform.position.z);    //Movemos la c�mara con el donuts en x.
    }
    #endregion
}
