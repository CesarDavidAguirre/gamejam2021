using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payaso : MonoBehaviour
{
    public Animator animator;
    int randomNumero;
    public BoxCollider2D manoDerecha;
    public BoxCollider2D manoIzquierda;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        Invoke("AnimacionesDeAtaque", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AnimacionesDeAtaque ()
    {
        
        randomNumero = Random.Range(0, 3);
        Debug.Log(randomNumero);
        if(randomNumero == 0)
        {
            animator.SetBool("Ataque1", true);
        }
        if (randomNumero == 1)
        {
            animator.SetBool("Ataque2", true);
        }
        if (randomNumero == 2)
        {
            animator.SetBool("Ataque3", true);
            manoDerecha.enabled = true;
            manoIzquierda.enabled = true;

        }
        Invoke("AnimacionesDeAtaque", 5f);
    }
    void FinAnimAtaqu1 ()
    {
        animator.SetBool("Ataque1", false);
        randomNumero = 3;
    }
    void FinAnimAtaque2()
    {
        animator.SetBool("Ataque2", false);
        randomNumero = 3;
    }
    void FinAnimAtaque3()
    {
        animator.SetBool("Ataque3", false);
        randomNumero = 3;
    }
    void FinAnimAtaque3Colliders()
    {
        manoDerecha.enabled = false;
        manoIzquierda.enabled = false;
    }
}
