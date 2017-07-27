using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharGahui : Character
{
    protected override void InitData()
    {
        iHp = 100;
        iAtk = 10;
        fRange = 6.0f;
        fPower = 10.0f;
        fDelay = 1.0f;
        fCritical = 0.5f;
    }

    // ----- Skills -----

    protected override void Passive1()
    {
        iAtk = (int)(iAtk / 0.8f);
    }

    protected override void Passive2()
    {
        for (int i = 0; i < Dungeon.iMaxCharacter; i++)
        {
            gCharacter[i].GetComponent<Character>().AtkBoost(3);
            AtkBoost(gCharacter[i]);
        }
    }

    protected override void Passive3()
    {
        // ??
    }

    // ----- Others -----

    IEnumerator AtkBoost(GameObject ally)
    {
        ally.GetComponent<Character>().AtkBoost(-3);
        ally.GetComponent<Character>().AtkBoost(3);

        yield return new WaitForSeconds(3.0f);
    }
}
