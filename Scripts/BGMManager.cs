using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip bgm;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(bgm);
    }

    // void Update()
    // {
    //     if (shootSE != null)
    //     {
    //         audioSource.Play();
    //     }
    // }

    public void BGMStop()
    {
        audioSource.Stop();
    }
}
