using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaBarradevida : MonoBehaviour
{
    public int vMax;
    public float vActual;
    public Image imgnHp;
    // Start is called before the first frame update
    void Start()
    {
        vActual = vMax;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        if (vActual <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void RevisarVida()
    {
        imgnHp.fillAmount = vActual / vMax;
    }
    
}
