using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generar_enemigos : MonoBehaviour
{
    public GameObject prefabEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("crearEnemigo", 30, 4);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E)) {

            crearEnemigo();
        }*/
    }
    void crearEnemigo()
    {
        Instantiate(prefabEnemigo);
    }

}
