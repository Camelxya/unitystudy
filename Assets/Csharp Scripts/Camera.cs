using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float transitionSpeed = 2;

    // Start is called before the first frame update
    private void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, transitionSpeed * Time.deltaTime);
        }
    }
}
