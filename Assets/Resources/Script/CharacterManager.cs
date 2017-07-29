using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    public List<GameObject> lCharacter;

    public override void Init()
    {
        lCharacter = new List<GameObject>();
    }

    public void AddCharacter(GameObject Character)
    {
        lCharacter.Add(Character);
    }
}