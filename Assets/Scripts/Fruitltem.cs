using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitltem : MonoBehaviour
{

     public GameObject collectedEffect;
    public int Score = 100;
    
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;



    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _spriteRenderer.enabled = false;    // 图像消失
            _circleCollider2D.enabled = false;    // 显示图像

            collectedEffect.SetActive(true);

            GameController.Instance.totalScore += Score;
            GameController.Instance.UPdateTotalScore();
            
            Destroy(gameObject,0.2f);       // 0.2秒之后执行删除操作
        }

    }
}
