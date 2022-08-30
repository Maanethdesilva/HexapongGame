using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public static MouseMovement instance;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 80;
        rb = this.GetComponent<Rigidbody2D>();
        this.speed = 11.5f;
    }

    public void Reset(){
        rb.rotation *= 0;
    }
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.rotation += speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.rotation -= speed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Score.instance.addScore();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        StartCoroutine(ExampleCoroutine());
        Score.instance.resetScore();
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
    }
}
