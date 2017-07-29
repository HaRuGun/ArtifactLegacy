using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour

{
    public const int iMaxCharacter = 4;
    public const int iMaxMonster = 1;
    
    private GameObject[] gCharacter;
    private GameObject[] gMonster;

    // Init
    public void Awake ()
    {
        gCharacter = new GameObject[iMaxCharacter];
        gMonster = new GameObject[iMaxMonster];

        //*
        GameObject wall = new GameObject("Wall");
        wall.GetComponent<Transform>().SetParent(this.gameObject.transform);
        wall.GetComponent<Transform>().localScale = new Vector2(0.5f, 100.0f);
        wall.GetComponent<Transform>().Translate(new Vector2(-3.0f, 0.0f));
        wall.AddComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        wall.AddComponent<BoxCollider2D>();
        Instantiate(wall, this.gameObject.transform).GetComponent<Transform>().Translate(new Vector2(6.0f, 0.0f));


        //*/

        InitObject();
        SetObject();
	}

    private void InitObject()
    {
        for (int i = 0; i < iMaxCharacter; i++)
        {
            gCharacter[i] = Resources.Load("Prefab/Character") as GameObject;
            gCharacter[i] = Instantiate(gCharacter[i], this.gameObject.transform);
            gCharacter[i].GetComponent<Character>().Init();

            Vector2 vCharPos;
            switch (i)
            {
                case 0: vCharPos = new Vector2(-2.0f, -3.0f); break;
                case 1: vCharPos = new Vector2(-0.7f, -4.0f); break;
                case 2: vCharPos = new Vector2(0.7f, -4.0f); break;
                case 3: vCharPos = new Vector2(2.0f, -3.0f); break;
                default: vCharPos = new Vector2(0.0f, 0.0f); break;
            }
            gCharacter[i].GetComponent<Transform>().Translate(vCharPos);
        }

        for (int i = 0; i < iMaxMonster; i++)
        {
            gMonster[i] = Resources.Load("Prefab/Monster") as GameObject;
            gMonster[i] = Instantiate(gMonster[i], this.gameObject.transform);
            gMonster[i].GetComponent<Monster>().Init();
        }
    }

    private void SetObject()
    {
        for (int i = 0; i < iMaxMonster; i++)
        {
            gMonster[i].GetComponent<Monster>().SetCharacter(gCharacter);
        }
        for (int i = 0; i < iMaxCharacter; i++)
        {
            gCharacter[i].GetComponent<Character>().SetMonster(gMonster[0]);
            gCharacter[i].GetComponent<Character>().SetCharacter(gCharacter);
        }
    }
}
