using UnityEngine;
using System.Collections;

public class BanderaVictoria : MonoBehaviour
{
    public GameObject VictoryScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SecuenciaVictoria());
        }
    }

    IEnumerator SecuenciaVictoria()
    {
        yield return new WaitForSeconds(3f);

        if (VictoryScreen = null)
        {
            VictoryScreen.SetActive(true);
        }
    }
}