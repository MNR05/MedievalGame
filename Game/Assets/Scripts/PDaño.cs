using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDaño : MonoBehaviour
{
    public LogicaBarradevida logicaHP;


    public float daño = 1.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            logicaHP.vActual -= daño;
            
        }

    }
}
