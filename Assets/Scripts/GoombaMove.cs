using UnityEngine;

public class GoombaMove : MonoBehaviour
{
    public Vector3 startPosition;

    public float movementSpeed = 5f;
    public int direction = 1;
    public Rigidbody2D rBody2D;
    
    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
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

        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
