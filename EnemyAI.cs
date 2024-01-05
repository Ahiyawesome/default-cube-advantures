using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class EnemyAI : MonoBehaviour
{
    private Animator swordAnim;
    private Animator enemyAnim;
    private bool closeEnough;
    public GameObject player;
    private NavMeshAgent nav;
    private int health = 5;
    public LayerMask playerMask;
    // Start is called before the first frame update
    void Start()
    {
        swordAnim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        enemyAnim = gameObject.transform.GetChild(1).GetComponent<Animator>();
        nav = gameObject.GetComponentInChildren<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        closeEnough = Physics.CheckSphere(transform.position, 5f, playerMask);

        if (!closeEnough)
        {
            move();
            swordAnim.SetBool("SWING", false);
            enemyAnim.SetBool("Attacking", false);
        }
        else if (closeEnough)
        {
            //Debug.Log("SWINGIN");
            swordAnim.SetBool("SWING", true);
            enemyAnim.SetBool("Attacking", true);
        }/*
        else if (swordAnim.GetBool("SWING") == true && swordAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f) {
            swordAnim.SetBool("SWING", false); 
            enemyAnim.SetBool("Attacking", true);
        }*/
    }
    private void move()
    {
        nav.SetDestination(player.transform.position);
        transform.LookAt(player.transform);
    }
    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
        Debug.Log("HIT");
    }
}
