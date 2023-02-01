using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (x > 0)
        {
            _rigidbody2D.transform.eulerAngles = new Vector3(0f,0f,0f);
            _animator.SetBool("run",true);
        }

         if (x < 0)
        {
            _rigidbody2D.transform.eulerAngles = new Vector3(0f,180f,0f);
            _animator.SetBool("run",true);
        }


        if (x < -0.001f && x > -0.001f)
        {
            _animator.SetBool("run",false);
        }


        Run ();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            GameController.Instance.ShowGameOverPanel();
            Destroy(gameObject); // 使得人物消失   
        }
    }

    private void Run()
    {
        Vector3 movement = new Vector3(x,y,0);
        _rigidbody2D.transform.position += movement * speed *Time.deltaTime;

    }
}
