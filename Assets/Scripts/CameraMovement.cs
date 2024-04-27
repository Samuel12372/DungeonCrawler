using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public float movementSpeed;
    void Start()
    {
        Offset = transform.position - Target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, movementSpeed * Time.deltaTime);
    }
}
