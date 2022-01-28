using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource fireSound;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SoundOfFire()
    {
        fireSound.Play();
    }
}
