using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIColor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;
    
    public void ChangeColor()
    {
        var colorType = FindObjectOfType<GameManager>().colorType;
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
                    SetColor(color1);
                    break;
                }
            case 2:
                {
                    SetColor(color2);
                    break;
                }
            case 3:
                {
                    SetColor(color3);
                    break;
                }
            case 4:
                {
                    SetColor(color4);
                    break;
                }
            case 5:
                {
                    SetColor(color5);
                    break;
                }
            case 6:
                {
                    SetColor(color6);
                    break;
                }
        }
    }

    public void SetColor(Color color)
    {
        uiText.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, color);
    }
}
