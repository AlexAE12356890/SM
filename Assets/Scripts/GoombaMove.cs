using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoombaMove : MonoBehaviour
{
    public Vector3 startPosition;

    public float movementSpeed = 5f;
    public int direction = 1;
    public Rigidbody2D rBody2D;
    private AudioSource _audioSource;
    public AudioClip deathSFX;
    public AudioClip MdeathSFX;
    private BoxCollider2D _boxCollider;
    private Animator _animator;
    private GameManager _gameManager;
    private bool marioMuerto = false;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
    
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(direction * movementSpeed, rBody2D.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tag Tuberia")|| collision.gameObject.layer == 7)
        {
            //La primera linea es el metodo intuitivo para saber que estas cambiando el valor de direction a -1. El segundo es el mas rapido de ya haber programado mas.
            //direction = direction * -1;
            direction *=-1;
        }

        if(collision.gameObject.CompareTag("Player") && !marioMuerto)
        {
            StartCoroutine(SecuenciaMuerteMario(collision.gameObject));
        }
    }

    IEnumerator SecuenciaMuerteMario(GameObject mario)
    {
        marioMuerto = true;
        _audioSource.PlayOneShot(MdeathSFX);

        mario.GetComponent<SpriteRenderer>().enabled = false; 
        mario.GetComponent<MonoBehaviour>().enabled = false;
        
        movementSpeed = 0;

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("GameOver");
    }

    public void GoombaDeath()
    {
        _gameManager.AddKill();
        
        _audioSource.PlayOneShot(deathSFX);

        movementSpeed = 0;

        _boxCollider.enabled = false;

        Destroy(gameObject, 0.5f);

        //_audioSource.clip = deathSFX; alternativa para reproducir
        //_audioSource.Play(deathSFX); util para poner la musiquita
    }
}