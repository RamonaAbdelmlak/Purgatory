using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Movement : MonoBehaviour
{
    public Animator animator;
    public float speed = 1;
    public float stickX = 0;
    public float stickY = 0;
    public bool canMove = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.Translate(speed * stickX * Time.deltaTime,speed * stickY * Time.deltaTime,0);
        // UP
        if ((stickX == 0 && stickY == 0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Walking Away Anim"))
        {
            animator.Play("Standing Back Anim");
        }
        // DOWN
        if ((stickX == 0 && stickY == 0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Walking Forward Anim"))
        {
            animator.Play("Standing Front Anim");
        }
        // RIGHT
        if ((stickX == 0 && stickY == 0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Walking Right Anim"))
        {
            animator.Play("Standing Right Anim");
        }
        // LEFT
        if ((stickX == 0 && stickY == 0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Walking Left Anim"))
        {
            animator.Play("Standing Left Anim");
        }
    }
    public void OnMove(InputValue value)
    {
        if (canMove)
        {
            stickX = value.Get<Vector2>().x;
            stickY = value.Get<Vector2>().y;
            // UP
            if (stickY == 1)
            {
                animator.Play("Walking Away Anim");
            }
            // DOWN
            if (stickY == -1)
            {
                animator.Play("Walking Forward Anim");
            }
            // RIGHT
            if (stickX == 1)
            {
                animator.Play("Walking Right Anim");
            }
            // LEFT
            if (stickX == -1)
            {
                animator.Play("Walking Left Anim");
            }
        }
    }
}
