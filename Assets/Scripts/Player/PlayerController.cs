using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    //private Vector2 screenBounds;
    public GameObject deadEffect;

    private PlayerMovement playerMovement;
    private IVerticalMoveable verticalMove;

    private PlayerDead playerDead;
    private IDeadable deadable;

    // Start is called before the first frame update
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerMovement = new PlayerMovement(rb, speed);
        verticalMove = playerMovement;

        playerDead = new PlayerDead(gameObject, deadEffect);
        deadable = playerDead;
    }

    // Update is called once per frame
    private void Update()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            verticalMove.Fly();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPos.x > -10)
            {
                verticalMove.Fly();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Enemy"))
        {
            deadable.Dead();
        }
    }
}