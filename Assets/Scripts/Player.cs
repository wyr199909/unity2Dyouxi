using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;//�ٶ�
    private Rigidbody2D _rigidbody2D;//����
    private Animator _animator;// ��ö��������������Ƽ�ͷ֮���ת����

    private float x;//����
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
            _rigidbody2D.transform.eulerAngles = new Vector3(0f,0f,0f);// �������ﰴָ������
            _animator.SetBool("run",true);  // ������ͷ�ؼ�
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

    private void OnCollisionEnter2D(Collision2D collision) // �����﷢����ײʱ�����ú���
    {
        if (collision.gameObject.tag == "Spike")  // ����������ײ������ı�ǩΪSpike�����ú���
        {
            GameController.Instance.ShowGameOverPanel(); // �����Զ��������ķ���
            Destroy(gameObject); // ʹ��������ʧ   
        }
        else if (collision.gameObject.tag == "Saw")
        {
            GameController.Instance.ShowGameOverPanel();        // �����Զ��������ķ���
            //gameObject.SetActive(false);
            Destroy(gameObject);            // ʹ��������ʧ   
        }
    }

    private void Run()
    {
        Vector3 movement = new Vector3(x,y,0);
        _rigidbody2D.transform.position += movement * speed *Time.deltaTime;

    }
}
