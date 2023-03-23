using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    Quaternion originalRotation;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.rotation;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = new Vector3(0, 180, 0);
        originalRotation.eulerAngles = eulerAngles;
        transform.rotation = cam.rotation * originalRotation;
    }
}
