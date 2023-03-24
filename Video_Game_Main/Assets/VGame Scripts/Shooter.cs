using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform castPosition;
    public float power = 20f;
    public float cooldownTime = 1.5f;
    float cooldownTimer;
    int timeShoot;

    public Vector3 projectileGlobalScale = new Vector3(1f, 1f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        timeShoot = 0;
        cooldownTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && cooldownTimer <= 0)
        {
            //if (Input.GetMouseButtonDown(0))
            //if (Input.GetKeyDown(KeyCode.E))
            //if (Input.GetButtonDown("Attack"))

            Shoot();
            cooldownTimer = cooldownTime;
        }
    }

    void Shoot()
    {
        //if (Input.GetMouseButtonDown(0)){
        timeShoot++;
        GameObject clone = GameObject.Instantiate(projectilePrefab, transform);
        Vector3 cameraDir = Camera.main.transform.forward;

        clone.transform.position = castPosition.position + cameraDir.normalized;
        clone.SetActive(true);
        //clone.transform.localPosition = new Vector3(0,0,0);
        clone.transform.parent = null;
        clone.transform.localScale = projectileGlobalScale;
        //clone.transform.position = transform.position; //100,0,0
        Destroy(clone, 5f);

        clone.GetComponent<Rigidbody>().AddForce(cameraDir * power, ForceMode.VelocityChange);


        //clone.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
    }
}