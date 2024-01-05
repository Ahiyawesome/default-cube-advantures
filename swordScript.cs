using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class swordScript : MonoBehaviour
{
    private Rigidbody rb;
    public Transform playerHand;
    public GameObject Epanel;
    public GameObject player;
    public GameObject enemy;
    private Animator anim;
    private bool inUse = false;
    void Start()
    {
        rb = gameObject.GetComponent < Rigidbody >();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Epanel.activeSelf == true && !inUse && rb.useGravity == true)
        {
            inUse = true;
            //rb.useGravity = false;
            //rb.isKinematic = true;
            Destroy(rb);
            transform.parent = player.transform;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            gameObject.transform.position = playerHand.transform.position;
            gameObject.transform.rotation = new Quaternion(180, 0, 180, transform.rotation.w);
            Epanel.SetActive(false);
        }
        
        if (Input.GetMouseButtonDown(0) && inUse)
        {
            anim.SetBool("SWING", true);
        }
        else if (anim.GetBool("SWING") == true && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f) anim.SetBool("SWING", false);


    }
    
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Rigidbody>() != null && rb.useGravity == true && other.tag == "Player") {
            Epanel.SetActive(true);
        }
    }
}
