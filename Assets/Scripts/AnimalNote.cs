using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalNote
{

  string noteName;
  string[] compatibleNotes;

  public AnimalNote(string noteName, string[] compatibleNotes)
  {
    this.noteName = noteName;
    this.compatibleNotes = compatibleNotes;
  }

  public string getNoteName()
  {
    return this.noteName;
  }

  public void setNoteName(string noteName)
  {
    this.noteName = noteName;
  }
  public string[] getCompatibleNotes()
  {
    return this.compatibleNotes;
  }

  public override bool Equals(object obj)
  {
    if ((obj == null) || !this.GetType().Equals(obj.GetType()))
    {
      return false;
    }
    else
    {
      AnimalNote note = (AnimalNote)obj;
      return noteName == note.noteName;
    }
  }

  public bool isCompatible(AnimalNote other)
  {
    for (int i = 0; i < compatibleNotes.Length; i++)
    {
      if (compatibleNotes[i] == other.getNoteName())
        return true;
    }
    return false;
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }

  public override string ToString()
  {
    return noteName;
  }
}
