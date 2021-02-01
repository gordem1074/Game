using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject end;
    public GameObject player;
    public Text textScore;
    public void OnTriggerEnter2D(Collider2D collision)
    {
    
        Destroy(player);
        Instantiate(end);
    }
}
