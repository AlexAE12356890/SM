using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;
    PlayerController _playerScript;

    void Awake()
    {
        _playerScript = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
        
        if(collision.gameObject.layer == 7)
        {
            //Destroy(collision.gameObject);
            GoombaMove _enemyScript;
            _enemyScript = collision.gameObject.GetComponent<GoombaMove>();
            _enemyScript.GoombaDeath();

            _playerScript.Bounce();

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }
}
