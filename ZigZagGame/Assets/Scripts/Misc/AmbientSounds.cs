using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    [SerializeField] public AudioClip[] sounds;
    private float soundTimer;

    // Start is called before the first frame update
    void Start()
    {
        soundTimer = Random.Range(1, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if(soundTimer < 0)
        {
            PlaySound();
            soundTimer = Random.Range(1, 8);
        }
        else
        {
            soundTimer -= Time.deltaTime;
        }
    }

    private void PlaySound()
    {
        var sound = GetRandomClip();
        AudioSource.PlayClipAtPoint(sound, transform.position, 1f);
    }

    private AudioClip GetRandomClip()
    {
        return sounds[Random.Range(0, sounds.Length)];
    }
}
