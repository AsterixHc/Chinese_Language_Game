using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbumBoxDetection : MonoBehaviour
{
    private BoxSentenceMatchCombinations box;
    public string BoxType;
    public WordType BoxWord;
    private RayDetection rayDetection;
    [SerializeField] private bool sentenceCorrect;
    string SentenceCombination;

    public bool SentenceCorrect { get => sentenceCorrect; set => sentenceCorrect = value; }

    private void Awake()
    {
        box = FindObjectOfType<BoxSentenceMatchCombinations>();
        rayDetection = GetComponent<RayDetection>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BoxTypeDecetion();
    }

    private void BoxTypeDecetion()
    {
        if (rayDetection.RayHitGameObjectLeft != null && rayDetection.RayHitGameObjectRight != null)
        {
            GameObject LeftGameObject = rayDetection.RayHitGameObjectLeft;
            GameObject RightGameObject = rayDetection.RayHitGameObjectRight;

            if (BoxTypeCheck(LeftGameObject, RightGameObject))
            {
                SentenceCombination = LeftGameObject.GetComponent<GeneralBoxDetection>().BoxWord.ToString() + BoxWord.ToString() + RightGameObject.GetComponent<GeneralBoxDetection>().BoxWord.ToString();


                if (box.SentenceCombinations.Contains(SentenceCombination))
                {
                    GameEvent.current.CallPlayerState(box.SentenceCombinations02[SentenceCombination]);
                }

                SentenceCorrect = box.SentenceCompare(SentenceCombination);
            }

            if (LeftGameObject != rayDetection.RayHitGameObjectLeft.gameObject && RightGameObject != rayDetection.RayHitGameObjectRight.gameObject)
            {
                box.Referencebool = false;
            }
        }
        else
        {
            GameEvent.current.CallPlayerState(PlayerStateType.fjendenSkaderJeg);
        }
    }

    private bool BoxTypeCheck(GameObject gameObject1, GameObject gameObject2)
    {
        string BoxTypeGameObject1 = gameObject1.GetComponent<GeneralBoxDetection>().BoxType;
        string BoxTypeGameObject2 = gameObject2.GetComponent<GeneralBoxDetection>().BoxType;
        if (BoxType != BoxTypeGameObject1 && BoxType != BoxTypeGameObject2)
        {
            return true;
        }

        return false;
    }
}
