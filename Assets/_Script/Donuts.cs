using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Donuts : MonoBehaviour
{
    #region Private Variables
    private Rigidbody2D _rb;                        //Variable que contendrá el rigidbody del objeto.
    private AudioSource _audioSource;               //Variable que contendrá el audiosource del GameObject.
    private float levelCompleteTimer;               //Tiempo a restar si se ha completado el nivel.
    private float gameOverTimer;                    //Tiempo a restar si se ha fallado en la finalización.
    #endregion
    #region Serializefield Variables
    [SerializeField] AudioClip boingA;              //Sonido de rebote 1.
    [SerializeField] AudioClip bointB;              //Sonido de rebote 2.
    #endregion
    #region MonoBehaviour Method
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();          //Capturamos el rigidbody.
        _audioSource = GetComponent<AudioSource>(); //Capturamos el audiosource.
        levelCompleteTimer = 5.0f;                  //Inicializamos la variable.
        gameOverTimer = 5.0f;                       //Inicializamos la variable.
    }
    private void Update()
    {
        //Si el juego se está ejecutando.
        if(GameState.state == GameState.gamePlay)
        {
            //El donuts se ha caido y por lo tanto es Game Over.
            if(transform.position.y < -10) { GameState.state = GameState.gameOver; }
        }
        //Si el juego ha llegado a completarse.
        if(GameState.state == GameState.levelComplete)
        {
            _rb.velocity = Vector2.zero;            //Paramos el donuts.
            levelCompleteTimer -= Time.deltaTime;   //Reducimos 1 cada segundo el valor de la variable.
            
            if(levelCompleteTimer < 0.0f) 
            {
                if (GameState.level == 1)
                {
                    GameState.level++;                                           //Sumamos 1 al nivel.
                    SceneManager.LoadScene("Scenes/Level "+GameState.level);    //Cambiamos de escena.
                }
                else
                {
                    GameState.state = GameState.gameOver;       //Cambiamos el valor de gamestate.
                }
            } 
            //Si el juego ha acabado en Game Over.
            if(GameState.state == GameState.gameOver)
            {
                gameOverTimer -= Time.deltaTime;                //Reducimos el valor de lal variable.
                if(gameOverTimer < 0.0f)                        //Si este valor llega a 0
                {
                    GameState.state = GameState.gamePlay;       //Ponemos estado de juego en gameplay.
                    SceneManager.LoadScene("Scenes/Title");     //Cargamos la escena inicial.
                }
            }
        }
    }
    #endregion
    #region Private Method
    /// <summary>
    /// Método que se encarga de ejecutar el sonido en función de cual sea el rebote.
    /// </summary>
    /// <param name="sound">Sonido a ejecutar.</param>
    private void PlaySound(AudioClip sound)
    {
        _audioSource.clip = sound;                              //Cargamos el sonido en el audioSource.
        _audioSource.Play();                                    //Hacemos sonar el sonido.
    }
    #endregion
    #region OnCollision Method
    /// <summary>
    /// Método que se encarga de ver contra que se ha chocado y en función de ello, actuar.
    /// </summary>
    /// <param name="collision">Objeto con el cual se ha colisionado.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WoodPlank") 
        { 
            Scoring.gamescore += 10;                            //Si es una plataforma +10 puntos.
            PlaySound(bointB);                                  //Ejecutamos el rebote 2.
        }  
        if(collision.gameObject.name == "Sphere") 
        { 
            Scoring.gamescore += 50;                            //Si es la esfera +50 puntos. 
            PlaySound(boingA);                                  //Ejecutamos el rebote 1.
        }      
        if (collision.gameObject.name == "DonutBox")
        {
            Scoring.gamescore += 100;                                               //Si es la caja de donuts +100 puntos.
            GameState.state = GameState.levelComplete;                              //Finalizamos el juego.
        }
    }
    #endregion
}
