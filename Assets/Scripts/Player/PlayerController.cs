using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public bool isDead = false;
    private Vector2 screenBounds;
    public GameObject deadEffect;
    public float timer;

    // Start is called before the first frame update
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("space"))
        {
            Fly();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPos.x > -10)
            {
                Fly();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.GetComponent<VirusController>())
        {
            Dead();
        }
        if (c.gameObject.CompareTag("Enemy"))
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(this.gameObject);
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        isDead = true;
    }

    private void Fly()
    {
        rb.AddForce(new Vector2(0, speed));
    }
}