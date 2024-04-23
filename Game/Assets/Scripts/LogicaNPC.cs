using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaNPC : MonoBehaviour
{
    public GameObject simboloMision;
    public Personaje1 player;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numObj;
    public GameObject botondeMision;



    // Start is called before the first frame update
    void Start()
    {
        numObj = objetivos.Length;
        textoMision.text = "Obten las botellas porfavor, buena suerte!!" + "\n Restantes: " + numObj;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Personaje1>();
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && aceptarMision == false && player.pSaltar == true)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, player.gameObject.transform.position.y, transform.position.z);
            player.gameObject.transform.LookAt(posicionJugador);


            player.anim.SetFloat("EjeX", 0);
            player.anim.SetFloat("EjeY", 0);

            player.enabled = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        jugadorCerca = true;
        if (aceptarMision == false)
        {
            panelNPC.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
        }
    }
    public void No()
    {
        player.enabled = true;
        panelNPC2.SetActive(false);
        panelNPC.SetActive(true);
        
    }

    public void Si()
    {
        player.enabled = true;
        aceptarMision = true;
        for(int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }
        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false); 
        panelNPC2.SetActive(false); 
        panelNPCMision.SetActive(true);
    }
}
