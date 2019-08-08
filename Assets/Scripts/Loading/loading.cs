using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class loading : MonoBehaviour
{
    public string TextoLoading;
    public float lps, tempo;
    int i;
    public Text[] caixaTexto;
    public Text textoAtual;
     void Start()
    {
        TextoLoading = File.ReadAllText("Assets/Texts/loading.txt");

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
