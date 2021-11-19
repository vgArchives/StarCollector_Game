using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletableController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private Renderer collectableLight;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
        ChangeColor();
    }

    public void ChangeColor()
    {
        var colorType = FindObjectOfType<GameManager>().colorType;
        var intensity = 6.5f;
        var color1 = new Color(2.55f, 2.55f, 2.55f, 1f);
        var color2 = new Color(1.91f, 0.0f, 0.88f, 1f);
        var color3 = new Color(0.0f, 0.10f, 2.55f, 1f); 
        var color4 = new Color(1.91f, 0.86f, 0.08f, 1f);
        var color5 = new Color(0.09f, 1.91f, 0.75f, 1f);
        var color6 = new Color(1.35f, 1.91f, 0.09f, 1f);

        switch (colorType)
        {
            case 1:
                {
                    SetColor(color1, 3.5f);
                    break;
                }
            case 2:
                {
                    SetColor(color2, intensity);
                    break;
                }
            case 3:
                {
                    SetColor(color3, intensity);
                    break;
                }
            case 4:
                {
                    SetColor(color4, intensity);
                    break;
                }
            case 5:
                {
                    SetColor(color5, intensity);
                    break;
                }
            case 6:
                {
                    SetColor(color6, intensity);
                    break;
                }
        }
    }

    public void SetColor(Color color, float intensity)
    {
        collectableLight.material.SetColor("_EmissionColor", color * intensity);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<TrackController>().UpdateColor();
            FindObjectOfType<UIColor>().ChangeColor();
            FindObjectOfType<CollectableUIColor>().ChangeColor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Track"))
        {
            Destroy(gameObject, 3f);
        }
    }
}
