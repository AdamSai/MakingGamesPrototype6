using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;
    [SerializeField] float spawnCooldown = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator SpawnClouds()
    {
        while (true)
        {
            var random = Random.Range(0, clouds.Length);
            var cloud = Instantiate(clouds[random], transform.position, Quaternion.identity, transform);
            var randomYOffset = Random.Range(-4f, 3f);
            cloud.transform.position += Vector3.up * randomYOffset;
            yield return new WaitForSeconds(spawnCooldown);
        }
    }
}
