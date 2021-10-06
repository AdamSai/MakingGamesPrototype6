using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 10f;
    [SerializeField] private Animator animalAnimator;
    [SerializeField] private GameObject balloons;
    [SerializeField] private Animator balloonAnimator;
    public AudioSource audioSource {get; private set;  }
    private AnimalNote note;

    private Button button;
    private bool isFalling;

    private Collider2D airTrigger;
    public string noteName;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animalAnimator = GetComponentInChildren<Animator>();
        balloonAnimator = balloons.GetComponent<Animator>();
        note = new AnimalNote(noteName, NotesConfig.notes[noteName]);
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
        if (collision.CompareTag("AirTrigger"))
        {
            isFalling = false;
            airTrigger = collision;
            GamerManager.singingAnimals++;
        }
        else if (collision.CompareTag("GroundTrigger"))
        {
            LandAnimal();
        }
    }

    public AnimalNote getNote()
    {
        return this.note;
    }

    /// <summary>
    /// Call this on badly composed notes
    /// </summary>
    public void PopBalloons()
    {
        audioSource.Stop();
        balloonAnimator.Play("Pop");
        fallSpeed += 10f;
        Physics2D.IgnoreCollision(airTrigger, GetComponent<BoxCollider2D>());
        isFalling = true;
    }
    /// <summary>
    /// Call this on succesfully composed notes
    /// </summary>
    public void KeepBalloons()
    {
        audioSource.Stop();
        isFalling = true;
        Physics2D.IgnoreCollision(airTrigger, GetComponent<BoxCollider2D>());
    }

    // Teleport animal and make it float downwards
    public void SelectAnimal(Vector3 fallPosition)
    {
        audioSource.Play();
        isFalling = true;
        animalAnimator.enabled = true;
        transform.position = fallPosition;
        // TODO: Spawn balloons
        // TODO: Play sound


    }

    private void LandAnimal()
    {
        isFalling = false;
        // TODO: Pop balloons
        animalAnimator.enabled = false;
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
