using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System;

public class NPC_Controller : MonoBehaviour, DamageListener
{
    public float speed = 1.0f;
    Animator animator;
    float actionTimer = 0;
    int[] direction = { -1, 0, 1, 0 };
    float[] actionTime = { 2f, 1f, 2f, 1f };
    int actionIdx = 0;
    Rigidbody2D rigidbody2D;
    private float attackedFromDirection = 0;
    private float attackDrag = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        actionTimer = actionTime[actionIdx];
        GetComponent<DamageController>().SetDamageListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (actionTimer > 0)
        {
            actionTimer -= Time.deltaTime;
        }
        else
        {
            actionIdx++;
            actionIdx = actionIdx % actionTime.Length;
            actionTimer = actionTime[actionIdx];
            if (direction[actionIdx] != 0)
            {
                transform.localScale = new Vector3(direction[actionIdx]*(-1), transform.localScale.y);
            }
        }

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        
        if (attackDrag < Math.Abs(attackedFromDirection))
        {
            position.x = position.x + attackedFromDirection * attackDrag * Time.deltaTime * 3;
            attackDrag += Time.deltaTime;
        } 
        else
        {
            position.x = position.x + speed * direction[actionIdx] * Time.deltaTime;
            attackedFromDirection = attackDrag = 0;
        }
        animator.SetBool("Walking", direction[actionIdx] != 0);
        rigidbody2D.MovePosition(position);
    }

    public void hurt(float attackDirection)
    {
        animator.SetTrigger("Hurt");
        attackedFromDirection = attackDirection;
    }

    public void dead()
    {
        //throw new System.NotImplementedException();
    }
}
