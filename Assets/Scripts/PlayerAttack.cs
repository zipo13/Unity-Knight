using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.2f;
    public LayerMask enemyLayers;
    public int attackRate = 2; // number of attacket per second
    private float nextAttackTime;
    HashSet<Collider2D> attackedEnemies;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        nextAttackTime = Time.time;
        attackedEnemies = new HashSet<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetButtonDown("Attack")) && (Time.time > nextAttackTime))
        {
            StartAttackAnimation();
            nextAttackTime = Time.time + 1f / attackRate;
        }

        AnimatorStateInfo animatorState = animator.GetCurrentAnimatorStateInfo(0);
        if (animatorState.IsName("Attack"))
        {
            Attack();
        } 
        else
        {
            attackedEnemies.Clear();
        }
    }

    void StartAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    void Attack()
    {
       
        Collider2D[] hitEnemyies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemyies)
        {
            DamageController damageController = enemy.GetComponent<DamageController>();
            if ((damageController != null) && (!attackedEnemies.Contains(enemy)))
            {
                int attackDirection = transform.position.x > enemy.transform.position.x ? -1 : 1;
                damageController.wound(40, attackDirection);
                attackedEnemies.Add(enemy);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
            
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
