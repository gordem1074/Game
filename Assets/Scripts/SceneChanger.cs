using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string Scene;
    public void VOTONOBLAHA()
    {
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
    }
}
