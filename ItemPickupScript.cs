using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupScript : MonoBehaviour
{
    public GameObject ePanel;
    public void Start() {
       SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
       sc.radius = gameObject.transform.localScale.x * 2;
    }
   
}
