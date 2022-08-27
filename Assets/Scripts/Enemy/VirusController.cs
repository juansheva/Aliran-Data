using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirusController : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float speed;
    //private Vector2 screenBounds;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //rb.velocity = Vector2.left * speed;
        //rb.velocity = new Vector2(-speed - Time.deltaTime, 0);

        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    //// Update is called once per frame
    //private void FixedUpdate()
    //{
    //    //if (transform.position.x < -screenBounds.x * 2)
    //    //{
    //    //    Destroy(this.gameObject);
    //    //}
    //}
    public void FirstLaunch(float _speed)
    {
        rb.velocity = new Vector2(-_speed - Time.deltaTime, 0);
    }
}