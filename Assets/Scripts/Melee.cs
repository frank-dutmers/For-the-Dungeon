using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    GameObject currentTarget;

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
            Debug.Log("hitting stuff");
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        GameObject curentTarget = otherCollider.gameObject;

        if (curentTarget.GetComponent<Attacker>())
        {
            GetComponent<Animator>().SetTrigger("isAttacking");
        }
    }
}
