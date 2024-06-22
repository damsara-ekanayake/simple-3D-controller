using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Animator animator;
    int horizontal;
    int vertical;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimatorValues(float horizontalMovement,float verticalMovement, bool isSprinting)
    {
        float snappedHorizontal;
        float snappedVertical;

        
        if(horizontalMovement > 0)
        {
            snappedHorizontal = 0.5f;
        }
        else if(horizontalMovement < 0)
        {
            snappedHorizontal = -0.5f;
        }
        else
        {
            snappedHorizontal = 0;
        }


       
        if (verticalMovement > 0)
        {
            snappedVertical = 0.5f;
        }
        else if (verticalMovement < 0)
        {
            snappedVertical = -0.5f;
        }
        else
        {
            snappedVertical = 0;
        }

        if (isSprinting)
        {
            snappedHorizontal = horizontalMovement;
            snappedVertical = 1;
        }

        animator.SetFloat(horizontal, snappedHorizontal , 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime);
    }
}
