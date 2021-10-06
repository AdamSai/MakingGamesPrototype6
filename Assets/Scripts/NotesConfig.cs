using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NotesConfig
{
  public static Dictionary<string, string[]> notes =
  new Dictionary<string, string[]>
  {
    { "C", new string[] {"C","E","G"} },
    { "D", new string[] {"D","F#","A"} },
    { "E", new string[] {"E","G#","B"} },
    { "F", new string[] {"F","A","C"} },
    { "G", new string[] {"G","B#","D"} },
    { "A", new string[] {"A","D#","E"} },
    { "B", new string[] {"B","D#","F#"} },
    { "F#", new string[] {"B","D#","F#"} },
    { "G#", new string[] {"E","G#","B"} },
    { "D#", new string[] {"A","D#","E"} },
};
}
