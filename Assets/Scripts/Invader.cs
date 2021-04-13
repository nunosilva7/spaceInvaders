using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour {
    [SerializeField]
    GameObject fire;

    [SerializeField]
    float cadencia;

    [SerializeField]
    float cadenciaMin = 0.5f;

    [SerializeField]
    float cadenciaMax = 2.5f;

    [SerializeField]
    float invaderHealth = 10; // numeros de disparos para matar o invasor indestrutivel

    float tempoQuepassou = 0f;

    private void Start () {

        TempoDisparo();
       
    }
    void TempoDisparo()
    {
        cadencia = Random.Range(cadenciaMin, cadenciaMax);
    }

    void Update () {
        if (tag == "Destrutivel") {
            tempoQuepassou += Time.deltaTime;
            if (tempoQuepassou >= cadencia) {
                Instantiate (fire, transform.position, transform.rotation);
                tempoQuepassou = 0f;
                TempoDisparo();

            }
        }

    }

    private void OnCollisionEnter2D (Collision2D collision) {

        if (tag == "Destrutivel") {
            if (collision.gameObject.tag == "ProjetilAmigo") {
                Destroy (gameObject);
                Destroy (collision.gameObject);
            }

        } else {
            invaderHealth--;
            Destroy (collision.gameObject);
            if (invaderHealth == 0) {
                Destroy (gameObject);
            }
        }

    }
}