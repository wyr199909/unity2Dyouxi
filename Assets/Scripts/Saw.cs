using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 2;//电锯游动速度
    public float movetime = 3;//电锯移动多长时间改变方向
    private bool directionRight = true;//判断现在电锯的移动方向
    private float timer;//每累计到3秒directionRight发生改变，然后电锯改变方向
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (directionRight)//判断电锯是否向右移动
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
