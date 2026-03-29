using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Player parent= GetComponentInParent<Player>();
        if (parent != null)
        {
            parent.isGrounded = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        Player parent = GetComponentInParent<Player>();
        if (parent != null)
        {
            parent.isGrounded = false;
        }
    }
}
