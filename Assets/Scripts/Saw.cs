using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 2;//����ζ��ٶ�
    public float movetime = 3;//����ƶ��೤ʱ��ı䷽��
    private bool directionRight = true;//�ж����ڵ����ƶ�����
    private float timer;//ÿ�ۼƵ�3��directionRight�����ı䣬Ȼ����ı䷽��
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (directionRight)//�жϵ���Ƿ������ƶ�
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        timer += Time.deltaTime;
        if (timer > movetime)
        {
            timer = 0;
            directionRight ^= true;
        }

    }
}
