using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
     [Range(0, 10)] public float jumVelocity = 5f;
    public LayerMask mask;      // 可认为是地面的列表信息
    public float boxHeight;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 playerSize;
    private Vector2 boxSize;

    private bool JumpRequest=false;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
         _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<SpriteRenderer>().bounds.size;
        boxSize = new Vector2(playerSize.x * 0.8f, boxHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")&&grounded)
        {
            JumpRequest=true;
            
        }
    }

    private void FixedUpdate()
    {
        if (JumpRequest)
        {
            _rigidbody.AddForce(Vector2.up * jumVelocity,ForceMode2D.Impulse);
            JumpRequest=false;
            grounded=false;
        }
        else
        {
            Vector2 boxCenter = (Vector2)transform.position + (Vector2.down * playerSize.y * 0.5f);

            if (Physics2D.OverlapBox(boxCenter, boxSize, 0, mask) != null)
            {
                grounded = true;
               
            }
            else
            {
                grounded = false;
                
            }
        }
    }

    private void OnDrawGizmos()     // 用于给判定箱上色
    {
        if (grounded)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Vector2 boxCenter = (Vector2)transform.position + (Vector2.down * playerSize.y * 0.5f);
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
