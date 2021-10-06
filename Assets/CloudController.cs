using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 4f;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 30f);
        speed = Random.Range(minSpeed, maxSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
