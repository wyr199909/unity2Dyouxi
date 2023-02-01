using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;//速度
    private Rigidbody2D _rigidbody2D;//刚体
    private Animator _animator;// 获得动画控制器（控制箭头之间的转换）

    private float x;//方向
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
            _rigidbody2D.transform.eulerAngles = new Vector3(0f,0f,0f);// 控制人物按指定方向
            _animator.SetBool("run",true);  // 触发箭头控件
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

    private void OnCollisionEnter2D(Collision2D collision) // 当人物发生碰撞时触发该函数
    {
        if (collision.gameObject.tag == "Spike")  // 当与人物碰撞的物体的标签为Spike触发该函数
        {
            GameController.Instance.ShowGameOverPanel(); // 调用自定义死亡的方法
            Destroy(gameObject); // 使得人物消失   
        }
        else if (collision.gameObject.tag == "Saw")
        {
            GameController.Instance.ShowGameOverPanel();        // 调用自定义死亡的方法
            //gameObject.SetActive(false);
            Destroy(gameObject);            // 使得人物消失   
        }
    }

    private void Run()
    {
        Vector3 movement = new Vector3(x,y,0);
        _rigidbody2D.transform.position += movement * speed *Time.deltaTime;

    }
}
