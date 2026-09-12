using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character_Movement : MonoBehaviour
{
    public Animator animator;
    public float speed = 1;
    public float stickX = 0;
    public float stickY = 0;
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
        Debug.Log(stickX);
        Debug.Log(stickY);
        if (stickX == 0 && stickY == 0)
        {
            animator.Play("Standing Anim");
        }
    }
    public void OnMove(InputValue value)
    {
        stickX = value.Get<Vector2>().x;
        stickY = value.Get<Vector2>().y;
        animator.Play("Walking Anim");
    }
}
