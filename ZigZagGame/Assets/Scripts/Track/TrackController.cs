using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    [SerializeField] private Material trackLight;
    [SerializeField] public bool canUpdateColor = false;

    // Start is called before the first frame update
    void Start()
    {
        trackLight.EnableKeyword("_EMISSION");
    }

    public void DestroyTrack()
    {
        Destroy(gameObject, 5f);
    }

    public void UpdateColor()
    {
        var colorType = FindObjectOfType<GameManager>().colorType;
        var intensity = 2.5f;
        var color1 = new Color(2.55f, 2.55f, 2.55f, 1f);
        var color2 = new Color(1.91f, 0.28f, 1.49f, 1f);
        var color3 = new Color(0.28f, 0.33f, 1.91f, 1f);
        var color4 = new Color(1.91f, 0.50f, 0.28f, 1f);
        var color5 = new Color(0.50f, 1.91f, 0.43f, 1f);
        var color6 = new Color(1.71f, 1.91f, 0.34f, 1f);

        switch (colorType)
        {
            case 1:
                {
                    SetColor(color1, 1f);
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
                    SetColor(color5, 1.5f);
                    break;
                }
            case 6:
                {
                    SetColor(color6, 1.5f);
                    break;
                }
        }
    }

    public void SetColor(Color color, float intensity)
    {
        trackLight.SetColor("_EmissionColor", color * intensity);
    }

    public Color GetColor()
    {
        return trackLight.GetColor("_EmissionColor");
    }
}
