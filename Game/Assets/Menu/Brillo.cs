using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brillo : MonoBehaviour
{
    public Slider slider;
    public float slidervalue;
    public Image pBrillo;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("brillo",0.5f);
        pBrillo.color = new Color(pBrillo.color.r, pBrillo.color.g, pBrillo.color.b, slider.value);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSlider(float valor)
    {
        slidervalue = valor;
        PlayerPrefs.SetFloat("brillo", slidervalue);
        pBrillo.color = new Color(pBrillo.color.r, pBrillo.color.g, pBrillo.color.b, slider.value);
    }
}
