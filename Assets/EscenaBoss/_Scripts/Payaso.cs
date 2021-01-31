using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Payaso : MonoBehaviour
{
    public Animator animator;
    public GameObject manoDerechaObj;
    public GameObject manoIzquierdaObj;
    int randomNumero;
    public BoxCollider2D manoDerecha;
    public BoxCollider2D manoIzquierda;
    public Image barVidaPayaso;
    float vida = 2000;
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
        manoDerechaObj.SetActive(false);
        manoIzquierdaObj.SetActive(false);
        manoDerechaObj.transform.localScale = new Vector3(0, manoDerechaObj.transform.localScale.y, 0);
        manoIzquierdaObj.transform.localScale = new Vector3(0, manoIzquierdaObj.transform.localScale.y, 0);
    }
    void AnimacionArcoiris ()
    {
        manoDerechaObj.SetActive(true);
        manoIzquierdaObj.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("disparoPJ"))
        {
            Destroy(collision.gameObject);
            vida = vida - 20;
            if (vida == 0) SceneManager.LoadScene("menu");
            barVidaPayaso.fillAmount = vida / 2000;
        }
    }

}
