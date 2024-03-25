using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    int yy;
    public void LoadNewScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
