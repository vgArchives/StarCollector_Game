using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSounds : MonoBehaviour
{
    [SerializeField] private AudioClip starSound;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(starSound, transform.position);
        }
    }
}
