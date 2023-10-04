using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour
{
    [SerializeField] Slider brightnessSlider;
    GameObject brightnessPlane;
    float alpha;
    float rgbValue;
    static BrightnessControl brightnessControl;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if(brightnessControl == null)
        {
            brightnessControl = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       brightnessPlane = gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        AdjustBrightness();
    }

    void AdjustBrightness()
    {
        if(brightnessSlider.value < 1)
        {
            alpha = 1 - brightnessSlider.value;
            rgbValue = 0;
        }
        if(brightnessSlider.value > 1)
        {
            alpha = brightnessSlider.value - 1;
            rgbValue = 1;
        }

        brightnessPlane.GetComponent<Image>().color = new Color(rgbValue, rgbValue, rgbValue, alpha);
    }
}
