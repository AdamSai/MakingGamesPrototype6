using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamerManager : MonoBehaviour
{

    [SerializeField] private GameObject[] Animals = new GameObject[10];

    [SerializeField] private Transform[] FallLocations = new Transform[3];

    [SerializeField] private Button[] animalButtons = new Button[10];
    [SerializeField] private int maxAllowedAnimals = 3;
    [SerializeField] private float endOfRoundWaitTime = 3;

    private GameObject[] spawnedAnimals = new GameObject[3];

    public static int nextPos = 0; // Next position to spawn an animal from

    public static int landedAnimals = 0;

    private void Update()
    {
        if (landedAnimals == 3)
        {
            // TODO: Do what happens when 3 animals have landed
            StartCoroutine(EndRound());

        }
    }

    private IEnumerator EndRound()
    {
        landedAnimals = 0;
        // TODO: Play sounds? 
        yield return new WaitForSeconds(endOfRoundWaitTime);

        foreach (var animal in spawnedAnimals)
            Destroy(animal);
        foreach (var button in animalButtons)
        {
            button.gameObject.SetActive(true);
        }
        nextPos = 0;
    }

    public void SelectAnimal(int id)
    {
        if (nextPos != maxAllowedAnimals)
        {

            animalButtons[id].gameObject.SetActive(false);
            var animal = Instantiate(Animals[id]);
            spawnedAnimals[nextPos] = animal;
            animal.GetComponent<AnimalController>().SelectAnimal(FallLocations[nextPos++].position);
        }

    }

    public static void CompareNotes()
    {
        //TODO: Loop through spawnedAnimals and compare notes
    }

}
