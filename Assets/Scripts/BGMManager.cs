using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip gameMusic;
    private AudioSource _audioSource;
    private GameObject player;
    private bool isStopped = false;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _audioSource.clip = gameMusic;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    void Update()
    {
        if (isStopped) return;

        if (player == null || !player.GetComponent<PlayerController>().enabled)
        {
            StopBGM();
        }
    }

    void StopBGM()
    {
        _audioSource.Stop();
        isStopped = true;
    }
}