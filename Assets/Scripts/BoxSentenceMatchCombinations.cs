using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSentenceMatchCombinations : MonoBehaviour
{
    public List<SentenceCombination> _sentenceCombinations = new List<SentenceCombination>();
    public List<string> SentenceCombinations;
    public Dictionary<string, PlayerStateType> SentenceCombinations02 = new Dictionary<string, PlayerStateType>();
    #region GameMechanicBools
    private bool referencebool = true;
    private bool skaderFjender = false;
    private bool skaderJeg = false;
    private bool healerFjender = false;
    private bool healerJeg = false;

    public bool SkaderFjender { get => skaderFjender; set => skaderFjender = value; }
    public bool SkaderJeg { get => skaderJeg; set => skaderJeg = value; }
    public bool HealerFjender { get => healerFjender; set => healerFjender = value; }
    public bool HealerJeg { get => healerJeg; set => healerJeg = value; }
    public bool Referencebool { get => referencebool; set => referencebool = value; }

    #endregion

    private void Awake()
    {
        SentenceCombinations = new List<string>();
    }

    private void Start()
    {
        //SentenceCombinations.Add(("Fjender Skader Jeg").Replace(" ","").ToLower());
        //SentenceCombinations.Add(("Jeg Skader Fjender").Replace(" ", "").ToLower());
        //SentenceCombinations.Add(("Jeg Healer Fjender").Replace(" ", "").ToLower());
        //SentenceCombinations.Add(("Fjender Healer Jeg").Replace(" ", "").ToLower());

        //SentenceCombinations.Add($"{WordType.fjender}{WordType.skader}{WordType.jeg}");
        //SentenceCombinations.Add($"{WordType.jeg}{WordType.skader}{WordType.fjender}");
        //SentenceCombinations.Add($"{WordType.jeg}{WordType.healer}{WordType.fjender}");
        //SentenceCombinations.Add($"{WordType.fjender}{WordType.healer}{WordType.jeg}");
        FindAllWords();
    }

    private void FindAllWords()
    {
        foreach (SentenceCombination item in _sentenceCombinations)
        {
            string tmp = "";
            tmp += (item.firstWord == WordType.none ? "" : item.firstWord.ToString());
            tmp += (item.secoundWord == WordType.none ? "" : item.secoundWord.ToString());
            tmp += (item.thirdWord == WordType.none ? "" : item.thirdWord.ToString());
            tmp += (item.fourthWord == WordType.none ? "" : item.fourthWord.ToString());
            tmp += (item.fifthWord == WordType.none ? "" : item.fifthWord.ToString());
            SentenceCombinations.Add(tmp);
            SentenceCombinations02.Add(tmp,item.playerStateType);
        }
    }

    private void FixedUpdate()
    {
        if(referencebool == false && (skaderJeg != false || skaderFjender != false ||healerFjender != false || healerJeg != false))
        {
            skaderFjender = false;
            skaderJeg = false;
            healerJeg = false;
            healerFjender = false;
        }
    }

    public bool SentenceCompare(string BoxMadeString)
    {
        bool found = false;

        foreach (string item in SentenceCombinations)
        {
            if(string.Equals(item, BoxMadeString))
            {
                found = true;
                break;
            }
        }

        GameMechanicBoolCheck(BoxMadeString);

        if(found == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GameMechanicBoolCheck(string boxMadeString)
    {
        if(boxMadeString == SentenceCombinations[0])
        {
            skaderJeg = true;
            referencebool = true;
        }
        else if(boxMadeString == SentenceCombinations[1])
        {
            skaderFjender = true;
            referencebool = true;
        }
        else if(boxMadeString == SentenceCombinations[2])
        {
            healerFjender = true;
            referencebool = true;
        }
        else if(boxMadeString == SentenceCombinations[3])
        {
            healerJeg = true;
            referencebool = true;
        }
    }
}
