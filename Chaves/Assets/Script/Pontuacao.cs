using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{

    [SerializeField]

    private Text textoPontuacao;

    private int pontos;

    private AudioSource somPontuacao;

    private void Awake()
    {
        somPontuacao = GetComponent<AudioSource>();
    }



    public void AdicionarPontos()
    {
        pontos += 1;
        somPontuacao.Play();
        AtualizarTexto();
    }

    private void AtualizarTexto()
    {
        textoPontuacao.text = pontos.ToString();
    }

    public void Reiniciar()
    {
        pontos = 0;
        AtualizarTexto();
    }


}

