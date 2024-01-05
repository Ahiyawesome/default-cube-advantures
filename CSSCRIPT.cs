using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSSCRIPT : MonoBehaviour
{
    public GameObject cubeplayer;
    public GameObject cCam1;

    public float cD = 10f;
    void OnTriggerEnter(Collider other) 
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        cubeplayer.GetComponent<playerController>().enabled = false;
        cCam1.SetActive(true);
        StartCoroutine(FinishCut());
    }
    IEnumerator FinishCut() 
    {
        yield return new WaitForSeconds(cD);
        cubeplayer.GetComponent<playerController>().enabled = true;
        cCam1.SetActive(false);
    }
}
