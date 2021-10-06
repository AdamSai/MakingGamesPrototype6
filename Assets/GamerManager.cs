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

  public GameObject[] spawnedAnimals = new GameObject[3];

  public static int nextPos = 0; // Next position to spawn an animal from

  public static int landedAnimals = 0;
  public static int singingAnimals = 0;

  private bool endRound = false;

  private void Update()
  {

    if (landedAnimals == 3)
    {
      // TODO: Do what happens when 3 animals have landed
      StartCoroutine(EndRound());
    }
    if (singingAnimals == 3 && !endRound)
    {
      endRound = true;
      CompareNotes();
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
      GameObject animal = Instantiate(Animals[id]);
      spawnedAnimals[nextPos] = animal;
      animal.GetComponent<AnimalController>().SelectAnimal(FallLocations[nextPos++].position);
    }

  }

  public void CompareNotes()
  {
    //TODO: Loop through spawnedAnimals and compare notes
    foreach (GameObject obj in spawnedAnimals)
    {
      if (obj.GetComponent<AnimalController>() == null)
        return;
    }

    AnimalNote keyNote = spawnedAnimals[0].GetComponent<AnimalController>().getNote();
    Debug.Log(keyNote);
    if (!keyNote.isCompatible(spawnedAnimals[1].GetComponent<AnimalController>().getNote()))
    {
      Debug.Log("Notes not compatible");
      return;
    }
    if (!keyNote.isCompatible(spawnedAnimals[2].GetComponent<AnimalController>().getNote()))
    {
      Debug.Log("Notes not compatible");
      return;
    }
    Debug.Log("Notes are compatible");
  }


}
