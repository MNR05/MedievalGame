using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personaje1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float velMov = 8f;
    public float velRot = 200f;
    public Animator anim;
    public float x, y;
    public Rigidbody rb;
    public float fuerzaSalto=8;
    public bool pSaltar;
    public bool atacking;
    public bool avanzosolo;
    public float impulso=10f;
    public int nivelpersonaje;
    public int velCorrer=8;
    public float velIni;
    public bool conArma;
    public float vMax;
    public Image imgnHp;
    //Audios
    public GameObject SonidoSalto;
    public GameObject SonidoMoneda;
    public GameObject SonidoPocion;
    public GameObject SonidoQueja;
    public GameObject SonidoDolor;
    public GameObject SonidoAgarrar;
    public GameObject SonidoHealth;

    void Start()
    {
        anim = GetComponent<Animator>();
        vMax=100;
    }
    void FixedUpdate()
    {
        if (!avanzosolo)
        {
            transform.Rotate(0, x * Time.deltaTime * velRot, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velMov);
        }
        else{
            rb.velocity = transform.forward * impulso;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && pSaltar && !atacking)
        {
            velMov = velCorrer;
            if (y > 0)
            {
                anim.SetBool("correr", true);

            }
            else           {
                anim.SetBool("correr", false);
            }
        }
        else
        {
            anim.SetBool("correr", false);
            if (pSaltar)
            {
              velMov=velIni;
            }
        }
        
        
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.C) && pSaltar && !atacking)
        {
            if (conArma)
            {
                anim.SetTrigger("punch2");
                atacking = true;
                Instantiate(SonidoSalto);

            }
            else
            {
                anim.SetTrigger("punch");
                atacking = true;
                Instantiate(SonidoSalto);
            }
        }
        
        anim.SetFloat("EjeX",x);
        anim.SetFloat("EjeY",y);

        if (pSaltar) {

            if (!atacking)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(SonidoSalto);
                    anim.SetBool("Jump", true);
                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                }
            }

            anim.SetBool("Fall", true);
        }
        else
        {
            falling();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Pociones")
        {
            Debug.Log("Cogio el objeto" + other.name);
            Destroy(other.gameObject);
            vMax = vMax + 20;
            imgnHp.fillAmount = vMax / 100;
            Instantiate(SonidoHealth);

        }

        if (other.tag == "Monedas")
        {
            Debug.Log("Cogio el objeto" + other.name);
            Destroy(other.gameObject);
            Instantiate(SonidoAgarrar);
        }
    }
    public void falling()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Fall", false);

    }

    public void dejeGolpear()
    {
        atacking = false;
    }
    public void AvansoSolo()
    {
        avanzosolo = true;
    }
    public void dejodevanzar()
    {
        avanzosolo = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {

            Debug.Log("Impacto con enemigo");
            vMax = vMax - 5;
            imgnHp.fillAmount = vMax / 100;
            Instantiate(SonidoDolor);
            if (vMax <= 0)
            {
                Instantiate(SonidoQueja);
                SceneManager.LoadScene("PERDISTE");
            }
        }
        if (collision.collider.tag == "Dragon")
        {

            Debug.Log("Impacto con dragon");
            vMax = vMax - 15;
            imgnHp.fillAmount = vMax / 100;
            Instantiate(SonidoDolor);
            if (vMax <= 0)
            {
                Instantiate(SonidoQueja);
                SceneManager.LoadScene("PERDISTE");
            }
        }
        if (collision.collider.tag == "cactus")
        {

            Debug.Log("Impacto con cactus");
            vMax = vMax - 2;
            imgnHp.fillAmount = vMax / 100;
            Instantiate(SonidoDolor);
            if (vMax <= 0)
            {
                Instantiate(SonidoQueja);
                SceneManager.LoadScene("PERDISTE");
            }
        }
    }
}

