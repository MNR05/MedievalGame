using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerArmas : MonoBehaviour
{

    public BoxCollider[] armasBoxcol;
    public BoxCollider punoBoxcol;
    
    //
    public GameObject[] armas;

    public Personaje1 p1;
    // Start is called before the first frame update
    void Start()
    {
        DesactivarColliderArmas();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DesactivarArmas();
        }


    }

    public void ActivarArmas(int num)
    {
        for(int i=0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

        armas[num].SetActive(true);

        p1.conArma = true;
    }
    public void DesactivarArmas()
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

        p1.conArma = false;
    }

    public void ActivarColliderArmas()
    {
        for(int i=0; i < armasBoxcol.Length; i++)
        {
            if (p1.conArma)
            {
                if (armasBoxcol[i]!=null)
                {
                    armasBoxcol[i].enabled = true;
                }
            }
            else
            {
                punoBoxcol.enabled = true;
            }
        }
    }
    public void DesactivarColliderArmas()
    {
        for (int i = 0; i < armasBoxcol.Length; i++)
        {
            if (armasBoxcol[i] != null)
                {
                    armasBoxcol[i].enabled = false;
                }          
        }
        punoBoxcol.enabled = false;
    }
}
