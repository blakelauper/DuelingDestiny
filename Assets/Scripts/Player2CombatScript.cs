using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2CombatScript : MonoBehaviour
{

    public Transform attackPoint2;
    public float attackRange2 = 0.7f;
    public LayerMask enemyLayers;

    public int attackDamage = 50;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Attack2();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
    }

    private void Attack2()
    {
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange2, enemyLayers);
        foreach (Collider2D enemy2 in hitEnemies2)
        {
            Debug.Log("We hit " + enemy2.name);
            enemy2.GetComponent<EnemyScript>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint2 == null)
            return;
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange2);
    }
}