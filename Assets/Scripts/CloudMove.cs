using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    private float rand;
    private int  IsRight;
  

    private void Start()
    {
        IsRight = Random.Range(0, 2);
        if (IsRight == 0)
            IsRight = -1;
        rand = Random.Range(0.004f, 0.012f);
    }

    void FixedUpdate()
    {if (gameObject.transform.position.x >= 12)
        {
            IsRight = -1;
            rand = Random.Range(0.004f, 0.012f);
        }
        if ((gameObject.transform.position.x <= -12)) {
            IsRight = 1;
            rand = Random.Range(0.004f, 0.012f);
        }
        gameObject.transform.position = new Vector2(transform.position.x + IsRight*rand,transform.position.y); 
    }
}
