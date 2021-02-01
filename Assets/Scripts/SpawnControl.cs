using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnControl : MonoBehaviour
{


    private float yourDesiredSize = 15;
    private const float Size = 5;
    private const float MaxSize = 15;
    private const float pos = 0;
    private const float Maxpos = -10;
    public static bool IsGame = false;

    public Text text;
    public int score = 0;

    private Vector2 spawn;
    private Vector2 spawnPlayer;
    private Vector2 spawnStick;

    private Rigidbody2D body;
    private Rigidbody2D bodyPl;
    private Rigidbody2D bodySt;

    public GameObject bodyMoon;
    public GameObject bodyPlayer;
    public GameObject bodyStick;
    public GameObject canvas;

    private Quaternion rotmon;
    private Quaternion rotplayer;
    private Quaternion rotstick;

    private int Health = 2;

    // Start is called before the first frame update
    void Start()
    {

        IsGame = true;
        spawn = bodyMoon.transform.position;
        spawnPlayer = bodyPlayer.transform.position;
        spawnStick = bodyStick.transform.position;

        rotmon = bodyMoon.transform.rotation;
        rotplayer = bodyMoon.transform.rotation;
        rotstick = bodyMoon.transform.rotation;


        body = bodyMoon.GetComponent<Rigidbody2D>();
        bodyPl = bodyPlayer.GetComponent<Rigidbody2D>();
        bodySt = bodyStick.GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if (IsGame)
        {
            float a = 0.2f;
            if (yourDesiredSize >= Size)
            {
                CameraMoov(a);
            }
            if (Camera.main.transform.position.y <= pos)
            {
                CameraTransform(a);
            }
            if (Health >= 0)
            {
                score++;
                text.text = "Score: " + score / 100;
            }
        }
        else {
            float a = -0.2f;
            if (yourDesiredSize <= MaxSize)
            {
                CameraMoov(a);
            }
            if (Camera.main.transform.position.y >= Maxpos)
            {
                CameraTransform(a);
            }
            if (Health >= 0)
            {
                score++;
                text.text = "Score: " + score / 100;
            }

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Moon")
        {
            bodyMoon.transform.position = spawn;
            body.constraints = RigidbodyConstraints2D.FreezeAll;
            body.constraints = RigidbodyConstraints2D.None;

        }
        if (collision.name == "Stick" || collision.name == "Player")
        {

            if (Health > 0)
            {
                Health--;
                bodyMoon.transform.position = spawn;
                bodyMoon.transform.rotation = rotmon;
                body.constraints = RigidbodyConstraints2D.FreezeAll;
                body.constraints = RigidbodyConstraints2D.None;


                bodyPlayer.transform.position = spawnPlayer;
                bodyPlayer.transform.rotation = rotplayer;
                bodyPl.constraints = RigidbodyConstraints2D.FreezeAll;
                bodyPl.constraints = RigidbodyConstraints2D.None;

                bodyStick.transform.position = spawnStick;
                bodyStick.transform.rotation = rotstick;
                bodySt.constraints = RigidbodyConstraints2D.FreezeAll;
                bodySt.constraints = RigidbodyConstraints2D.None;
            }
            else
            {
                StartCoroutine(EndGame());
            }
        }
    }

    public IEnumerator EndGame() {
        Health--;
        Destroy(bodyMoon);
        Destroy(bodyStick);
        //Destroy(canvas);
        IsGame = false;
        bodyPl.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(0f);
        bodyPl.constraints = RigidbodyConstraints2D.None;
    }
 
    public void CameraMoov(float a)
    {
        Camera.main.orthographicSize = yourDesiredSize;
        yourDesiredSize -= a;
    }
    public void CameraTransform(float a)
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + a, Camera.main.transform.position.z);
    }




}