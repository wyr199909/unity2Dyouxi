using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
     public float jumpVelocity = 10f;

    private Rigidbody2D _rigidbody2D;
    private bool jumpRequest = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;
        }
    }

     // 一般为0.02s执行一次
    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
        }
    }
}
