using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class loading : MonoBehaviour
{
    public string TextoLoading;
    public float lps, tempo;
    int i;
    public Text[] caixaTexto;
    public Text textoAtual;

    void Start()
    {
        TextoLoading = "-0\nEm um mundo cheio de magia chamado Heragon, existem seres que possuíam o dom de dominar os 4 elementos da natureza: Fogo, Água, Terra e Ar. Nesse mundo eles entraram em conflito entre si por não haver um rei para governar.\n -1 \nPor conta disso eles criaram uma arena para decidir quem será o novo rei de Heragon.";


        caixaTexto[0].text = "";
        caixaTexto[1].text = "";
    }

    void Update()
    {
        lerTexto();
    }
    void lerTexto()
    {
        tempo += Time.deltaTime;
        if (tempo > (1f/lps) && i < TextoLoading.Length)
        {
          
            if (TextoLoading[i] == '-')
            {
                i++;
                int novotext = TextoLoading[i];
                novotext -= 48;
             
                textoAtual = caixaTexto[novotext];
            }
            else
            {
                textoAtual.text += TextoLoading[i];
            }
            tempo = 0;
                i++;
        }
    }

    

}
