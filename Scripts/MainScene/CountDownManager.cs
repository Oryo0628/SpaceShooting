using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CountDownManager : MonoBehaviour
{
    Text countdownText;
    public GameObject player; 
    public bool Isflag = true;

    void Start()
    {
        countdownText = GetComponent<Text>();   
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        //if (player != null)
           // player.SetActive(false);

        countdownText.gameObject.SetActive(true);

        string[] countdownStrings = { "3", "2", "1", "Start!" };

        foreach (string count in countdownStrings)
        {
            countdownText.text = count;
            if (count == "1")
            {
                //player.SetActive(true);
                player.transform.DOMove(new Vector3(0, -3.0f, 0), 1.0f).SetEase(Ease.OutSine);
            } 
            yield return new WaitForSeconds(1f);
        }
        Isflag = false;
        countdownText.gameObject.SetActive(false);

        
    }
}
