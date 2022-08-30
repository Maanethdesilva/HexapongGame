using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public static Ball instance;
    private Rigidbody2D rb;
    private int prevScore = 0;
    void Start()
    { 
        Physics.gravity = new Vector3(0,0,0);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, 6.0f);
    }

    public void Reset(){
        rb.position = new Vector2(1.85f,0.0f);
        rb.velocity = new Vector2(0.0f, 6.0f);
    }

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Score.instance.score > prevScore && Score.instance.score % 5 == 0)
        {
            rb.velocity *= 1.02f;
            prevScore = Score.instance.score;
        } 
    }
    
}
