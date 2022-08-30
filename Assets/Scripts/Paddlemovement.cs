using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddlemovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        this.speed = 7.0f;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed *= -1;
        }
    }
    void FixedUpdate()
    {
        rb.rotation += speed;
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
