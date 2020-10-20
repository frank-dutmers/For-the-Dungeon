using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{

    GameObject currentTarget;
    



    private void OnTriggerEnter2D(Collider2D otherColider)
    {
        GameObject otherObject = otherColider.gameObject;
        
        

        if (otherObject.GetComponent<Attacker>())
        {
            Debug.Log("I'm attackin!!!!!");
            GetComponent<Animator>().SetBool("isAttacking", true);
            MeleeAttack(otherObject);
            

        }



    }


    // Update is called once per frame
    void Update()
    {

        UpdateAnimationState();
        
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }
    private void MeleeAttack(GameObject target)
    {
        
         

        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

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









    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }





}



