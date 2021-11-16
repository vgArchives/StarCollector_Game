using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private PlayerController player;
 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip footRight;
    [SerializeField] private AudioClip footLeft;

    [SerializeField] private AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayJumpSound();
    }

    public void PlayJumpSound()
    {
        if (player.controller.isGrounded && Input.GetKey(KeyCode.W))
        {
            AudioSource.PlayClipAtPoint(jumpSound, player.transform.position);
        }
    }

    public void PlayRight()
    {
        if (player.controller.isGrounded)
        {
            audioSource.clip = footRight;
            audioSource.pitch = Random.Range(0.90f, 1.01f);
            audioSource.volume = Random.Range(0.2f, 0.4f);
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }

    public void PlayLeft()
    {
        if (player.controller.isGrounded)
        {
            audioSource.clip = footLeft;
            audioSource.pitch = Random.Range(0.90f, 1.01f);
            audioSource.volume = Random.Range(0.2f, 0.4f);
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
}
