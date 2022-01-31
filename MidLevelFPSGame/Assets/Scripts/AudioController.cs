using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource fireSound;
    public AudioSource walkSound;
    public AudioSource runSound;

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

    public void SoundOfWalk()
    {
        walkSound.Play();
    }

    public void SoundOfRun()
    {
        runSound.Play();
    }
}
