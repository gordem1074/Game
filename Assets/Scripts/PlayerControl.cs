using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed=3;
    public Rigidbody2D body;
    private Animator anim;
    private float h;
    // Update is called once per frame

    private void Start()
    {
        h = 0;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (SpawnControl.IsGame)
        {
            body.velocity = new Vector2(h * speed, body.velocity.y);
            if (h == 0)
            {
                anim.SetBool("IsRuning", false);
            }
            else
            {
                anim.SetBool("IsRuning", true);
            }
            h = Input.GetAxisRaw("Horizontal");
        }
    }
    public void MoveRight()
    {
        h = 1;

    }
    public void MoveLeft() 
    {
        h = -1;
    }
    public void ButtonUP() 
    {
       h=0;
    }
}
