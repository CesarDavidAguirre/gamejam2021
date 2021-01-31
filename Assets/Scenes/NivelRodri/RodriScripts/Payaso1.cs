using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Payaso1 : MonoBehaviour
{
    public Image barVidaPayaso;
    float vida = 2000;

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
