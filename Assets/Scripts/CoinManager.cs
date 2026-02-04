using UnityEngine;

public class CoinManager : MonoBehaviour

{
    private BoxCollider2D _boxCollider;
    private GameManager _gameManager;
    public AudioClip coinSFX;
    private AudioSource _audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Cointaker()
    {
        _audioSource.PlayOneShot(coinSFX);
        _gameManager.AddCoin();
        Destroy(gameObject, 0.5f);
        _boxCollider.enabled = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
