using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disintegrate : MonoBehaviour
{
    public float countdownTime = 1.5f;
    private bool isDisappearing = false;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartCountdown());
        }
    }

    private IEnumerator StartCountdown()
    {
        isDisappearing = true;

        yield return new WaitForSeconds(countdownTime);


        gameObject.SetActive(false);
    }
}
