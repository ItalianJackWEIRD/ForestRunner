using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    
    private Animator animator;
    public SwipeManager swipeManager;

    private float timerForDestroyingBoxes = 1;

    private bool canAttack = true;
    public bool attacking = false;

    private float timerForAttack = 1;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            swipeManager.tap = true;
            swipeManager.isDraging = true;
            swipeManager.startTouch = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            if (swipeManager.isDraging && (swipeManager.swipeDelta.magnitude < swipeManager.deadZone) && canAttack)
            {
                PlayerAttack();
            }
            swipeManager.Reset();
        }
    }

    private void PlayerAttack()
    {
        canAttack = false;
        Invoke("ResetCanAttack", timerForAttack);
        animator.SetTrigger("Attack");
        attacking = true;
        Invoke("ResetCanDestroyBoxes", timerForDestroyingBoxes);
    }

    private void ResetCanDestroyBoxes()
    {
        attacking = false;
    }

    private void ResetCanAttack()
    {
        canAttack = true;
    }

    public bool canDestroy ()
    {
        return attacking;
    }
}