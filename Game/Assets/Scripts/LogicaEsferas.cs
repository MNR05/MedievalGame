using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaEsferas : MonoBehaviour
{
    public LogicaNPC logicanpc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(other.transform.parent.gameObject);
            logicanpc.numObj--;
            logicanpc.textoMision.text = "Obten todas las botellas " + "\n restantes: " + logicanpc.numObj;

            if (logicanpc.numObj <= 0)
            {
                logicanpc.textoMision.text = "Completaste la misión, felicidades :) ";
                logicanpc.botondeMision.SetActive(true);
                SceneManager.LoadScene("GANASTE");
            }
            transform.parent.gameObject.SetActive(false);
        }
    }
}
