using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 10f;
    private bool isFalling;
    [SerializeField] private Animator animator;
    private AudioSource audioSource;

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LandAnimal();
    }

    // Teleport animal and make it float downwards
    public void SelectAnimal(Vector3 fallPosition)
    {
        isFalling = true;
        animator.enabled = true;
        transform.position = fallPosition;
        // TODO: Spawn balloons
        // TODO: Play sound


    }

    private void LandAnimal()
    {
        isFalling = false;
        // TODO: Pop balloons

        GamerManager.landedAnimals++;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }
}
