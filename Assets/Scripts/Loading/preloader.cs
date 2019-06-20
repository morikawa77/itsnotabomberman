using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    public int sceneIndex;

    private AsyncOperation progress;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadLevel());
        }

        if (progress != null)
        {
            Debug.Log(progress.progress);
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
        yield return null;
        Debug.Log("Load is done");
    }
}