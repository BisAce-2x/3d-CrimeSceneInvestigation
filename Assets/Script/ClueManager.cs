using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    private List<GameObject> Children = new List<GameObject>();
    private GOInteraction myGOI;

    public static int cluesFound = 0;
    public static int totalClues = 4;
    public GameObject finalQuestionUI;

    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Information")
            {
                Children.Add(child.gameObject);
            }
        }

        myGOI = GetComponent<GOInteraction>();

        if (myGOI == null)
        {
            Debug.Log("No GOInteraction attached to this object.");
        }

        foreach (GameObject child in Children)
        {
            child.SetActive(false);
        }
    }

    void Update()
    {
        if (myGOI.Interaction == true)
        {
            foreach (GameObject child in Children)
            {
                if (child.activeSelf)
                {
                    child.SetActive(false);
                }
                else
                {
                    child.SetActive(true);
                    CountClue();
                }
            }
            myGOI.Interaction = false;
        }
    }

    void CountClue()
    {
        cluesFound++;
        Debug.Log("Clues found: " + cluesFound);

        if (cluesFound >= totalClues)
        {
            if (finalQuestionUI != null)
            {
                finalQuestionUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}