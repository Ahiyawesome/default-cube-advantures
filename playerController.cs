using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    CharacterController characterController;
    public float moveSpeed = 6f;
    public float gravity = 20f; 
    private Animator animator;
    public float vlc = 1f;
    public GameObject enemy;
    private Vector3 moveDirection = Vector3.zero;
    private float time = 0.0f;
    private bool AlreadyRunning = false;
    private bool touchingEnemy;

    void Start() 
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        AimTowardsMouse();
        
        if(characterController.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection *= moveSpeed;
        }
        moveDirection.y -= Time.deltaTime*gravity;
        characterController.Move(moveDirection*Time.deltaTime); 

        if(characterController.velocity.magnitude < vlc) {
            animator.SetBool("IsWalking", false);
            if (AlreadyRunning == false) {
                StartCoroutine(TimeWatch());
            }
        }
        if(characterController.velocity.magnitude > vlc) {
            animator.SetBool("IsWalking", true);
            animator.SetBool("Idle10", false);
            animator.SetBool("Idle11", false);
            AlreadyRunning = false;
            }
        if (animator.GetBool("IsWalking") == false && time > 8f) {
            animator.SetBool("Idle10", true);
        }
        if (animator.GetBool("IsWalking") == false && time > 8.55f) {
            animator.SetBool("Idle11", true);
        }
            
        if(AlreadyRunning == false) {
            time = 0;
        }
        if (Input.GetMouseButtonDown(0) && touchingEnemy && enemy != null) {
            enemy.GetComponent<EnemyAI>().takeDamage(1);
        }


    }   
    IEnumerator TimeWatch () {
        while (true) {
            time += Time.deltaTime;
            AlreadyRunning = true;
            yield return null;
        }
    }
    void AimTowardsMouse()
    {
        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity)) {
            var direction = hitInfo.point - transform.position;
            direction.y = 0f;
            direction.Normalize();
            transform.forward = direction;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy")) {
            touchingEnemy = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            touchingEnemy = false;
        }
    }
}
