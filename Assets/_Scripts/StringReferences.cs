using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringReferences : MonoBehaviour
{
    public static StringReferences Instance { get; private set; }

    //Tags
    string _playerTag() => "Player";

    //Tags
    public string PlayerTag => _playerTag();
}
