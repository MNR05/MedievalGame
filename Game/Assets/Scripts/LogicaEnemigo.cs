using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEnemigo : MonoBehaviour
{
    public int hp;
    public int danoArma;
    public int danoPuno;
    public Animator anim;
    GameObject jugador;
    private int comportamiento = 1;//1->perseguir   2->patrulle
                                   // Start is called before the first frame update
    public GameObject SonidoEspada;
    public GameObject SonidoQueja;
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        comportamiento = Random.Range(1, 3);
        if (comportamiento == 2)
        {

            InvokeRepeating("cambiarDireccion", 3, 4);
        }

    }

    // Update is called once per frame
    void Update()
    {
        /*if (comportamiento == 1)
        {
            transform.LookAt(jugador.transform);
            GetComponent<Rigidbody>().velocity = transform.forward;
        }*/
        transform.LookAt(jugador.transform);
        GetComponent<Rigidbody>().velocity = transform.forward;
        /* else
         {
             GetComponent<Rigidbody>().velocity = transform.forward;
         }*/
    }
    void cambiarDireccion()
    {

        transform.Rotate(0, Random.Range(0, 360), 0);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "armaImpacto")
        {
            if (anim != null)
            {
                anim.Play("New Animation");
            }
            hp -= danoArma;
            Instantiate(SonidoEspada);
            if (hp <= 0)
            {
                Instantiate(SonidoQueja);
            }
        }
        if(other.gameObject.tag == "golpeImpacto")
        {
            if (anim != null)
            {
                anim.Play("New Animation");
            }
            hp -= danoPuno;
            
            if (hp <= 0)
            {
                Instantiate(SonidoQueja);
            }

        }   
        if (other.gameObject.tag == "cactus")
        {

            Debug.Log("Impacto con cactus");
            hp = hp - 1;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }
}
