using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject actor;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - actor.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = actor.transform.position + offset;
    }
}
