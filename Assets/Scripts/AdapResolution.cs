using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdapResolution : MonoBehaviour
{
    private Vector2 screenBounds;
    public bool kananA;
    public bool kiriA;
    public bool kananB;
    public bool kiriB;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

    // Update is called once per frame
    void Update()
    {
        if (kananA == true && kiriA==false)
        {
            this.transform.position = new Vector2(screenBounds.x -1, screenBounds.y - 1);
        }
        if (kiriA == true&&kananA==false)
        {
            this.transform.position = new Vector2(-screenBounds.x +2, screenBounds.y - 1);
        }
        if (kananB == true && kiriB == false)
        {
            this.transform.position = new Vector2(screenBounds.x - 5, -screenBounds.y +2);
        }
        if (kiriB == true && kananB == false)
        {
            this.transform.position = new Vector2(-screenBounds.x + 5, -screenBounds.y + 2);
        }

    }
}
