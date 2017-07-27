using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour
{
    public const int iMaxCharacter = 4;
    public const int iMaxMonster = 3;

    public GameObject gWallL;
    public GameObject gWallR;
    public GameObject gOutline;

    public GameObject[] gCharacter;
    public GameObject[] gMonster;

    // Init
    public void Awake ()
    {
        InitObject();
        SetObject();
	}

    private void InitObject()
    {
        for (int i = 0; i < iMaxCharacter; i++)
        {
            gCharacter[i].GetComponent<Character>().Init();
        }
        for (int i = 0; i < iMaxMonster; i++)
        {
            gMonster[i].GetComponent<Monster>().Init();
        }
    }

    private void SetObject()
    {
        for (int i = 0; i < iMaxCharacter; i++)
        {
            gCharacter[i].GetComponent<Character>().SetMonster(gMonster[0]);
            gCharacter[i].GetComponent<Character>().SetCharacter(gCharacter);
        }
        for (int i = 0; i < iMaxMonster; i++)
        {
            gMonster[i].GetComponent<Monster>().SetCharacter(gCharacter);
        }
    }
}
