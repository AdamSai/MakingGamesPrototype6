using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 10f;
    [SerializeField] private Animator animator;
    private AudioSource audioSource;

    private Button button;
    private bool isFalling;

    private Collider2D airTrigger;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PopBalloons();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            KeepBalloons();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AirTrigger"))
        {
            isFalling = false;
            airTrigger = collision;
            GamerManager.CompareNotes();
        }
        else if (collision.CompareTag("GroundTrigger"))
        {
            LandAnimal();
        }
    }


    /// <summary>
    /// Call this on badly composed notes
    /// </summary>
    public void PopBalloons()
    {
        fallSpeed += 10f;
        Physics2D.IgnoreCollision(airTrigger, GetComponent<BoxCollider2D>());
        isFalling = true;
    }
    /// <summary>
    /// Call this on succesfully composed notes
    /// </summary>
    public void KeepBalloons()
    {
        isFalling = true;
        Physics2D.IgnoreCollision(airTrigger, GetComponent<BoxCollider2D>());
    }

    // Teleport animal and make it float downwards
    public void SelectAnimal(Vector3 fallPosition)
    {
        isFalling = true;
        animator.enabled = true;
        print("Animator enabled? " + animator.enabled);
        transform.position = fallPosition;
        // TODO: Spawn balloons
        // TODO: Play sound


    }

    private void LandAnimal()
    {
        isFalling = false;
        // TODO: Pop balloons
        animator.enabled = false;
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
