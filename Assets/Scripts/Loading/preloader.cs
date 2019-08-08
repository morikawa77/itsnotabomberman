using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class preloader : MonoBehaviour
{
    public int sceneIndex;

    private AsyncOperation progress;

    private int progresso;
    public Text carregando;
    private string progressoTexto;


    private void Start()
    {
        StartCoroutine(LoadLevel());
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(LoadLevel());
        //}

        if (progress != null)
        {
            // Debug.Log((int)(progress.progress*100));
            progresso = (int)(progress.progress * 100);
            progressoTexto = progresso.ToString();

            if (progress.progress >= 0.9f && Input.GetKeyDown(KeyCode.Return))
            {
                progress.allowSceneActivation = true;
            }
        }
    }

    private IEnumerator LoadLevel()
    {
        progress = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        progress.allowSceneActivation = false;

        while (progress.progress < 0.9f)
        {
            Debug.Log(progresso + " %");
            
            carregando.text = "Carregando: " + progressoTexto + "%   ";

            yield return null;
        }
        
        Debug.Log("Load is done");
        carregando.text = "Carregando: 100%   \n Aperte ENTER para começar   ";
    }
}