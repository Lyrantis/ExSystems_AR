using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScenes : MonoBehaviour
{
    public void OpenSceneByName(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void OpenSceneByIndex(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
}
