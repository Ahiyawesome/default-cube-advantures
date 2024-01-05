using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScrip : MonoBehaviour
{
    public GameObject barrierObj;
    public float NumberOfWait = 10f;
    public GameObject Epanel;
    public GameObject EpanPanel;
    public GameObject EText;
    public GameObject player;
    public GameObject sWoRd;
    private bool coAlreadystar;
    private Animator EpanAnim;
    private Animator EtextAnim;
    private Animator BarAnim;
    private Animator SworDAnim;
    private Rigidbody rb;
    public GameObject SwordLight;
    public GameObject enemy;

    void Start() {
        EpanAnim = EpanPanel.GetComponent<Animator>();
        EtextAnim = EText.GetComponent<Animator>();
        BarAnim = barrierObj.GetComponent<Animator>();
        SworDAnim = sWoRd.GetComponent<Animator>();
        rb = sWoRd.GetComponent<Rigidbody>();
        coAlreadystar = false;
        Epanel.SetActive(false);
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            Epanel.SetActive(true);
        }
    }
    void OnTriggerExit (Collider other) {
        if (other.tag == "Player") {
            Epanel.SetActive(false);
        }
    }

    IEnumerator DestroyBar() {
        coAlreadystar = true;
        EpanAnim.SetBool("IfClick", true);
        yield return new WaitForSeconds (0.5f);
        Epanel.SetActive(false);
        BarAnim.SetBool("BarBreak", true);
        yield return new WaitForSeconds(NumberOfWait);
        Destroy(barrierObj);
        Destroy(SwordLight);
        rb.useGravity = true;
        sWoRd.GetComponent<MeshCollider>().enabled = true;
        enemy.SetActive(true);

    }

    void Update () {
        GameObject epanel = Epanel;
        if (Epanel.activeSelf == true && coAlreadystar == false && barrierObj != null) {
            if (Input.GetKeyDown(KeyCode.E)) {
                EtextAnim.SetBool("IsClick", true);
                StartCoroutine(DestroyBar());
            }
            

        }
    }
        
}
