using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int killCounter = 0;
    public int coinCounter = 0;
    public Text goombaText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  AddKill()
    {
        killCounter++;
        goombaText.text = killCounter.ToString();
    }

    public void AddCoin()
    {
        coinCounter++;
    }
}
