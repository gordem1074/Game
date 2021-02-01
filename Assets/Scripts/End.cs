using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject popup;
    public GameObject player;
    public Text textScore;

    public void Start()
    {
        popup.SetActive(false) ;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        textScore.text = "Score:\n" + SpawnControl.score / 100;
        Destroy(player);
        popup.SetActive(true);
    }
}
