using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSounds : MonoBehaviour
{
    [SerializeField] public AudioClip changeSound;
    private Color previousColorType;
    private Color currentColorType;
    
    // Start is called before the first frame update
    void Start()
    {
        previousColorType = FindObjectOfType<TrackController>().GetColor();
        currentColorType = FindObjectOfType<TrackController>().GetColor();
    }

    // Update is called once per frame
    void Update()
    {
        currentColorType = FindObjectOfType<TrackController>().GetColor(); 
        PlayChangeSound();
    }

    private void PlayChangeSound()
    {
        if(currentColorType != previousColorType)
        {
            AudioSource.PlayClipAtPoint(changeSound, transform.position, 1f);
            previousColorType = currentColorType;
        }
    }
}
