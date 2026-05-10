using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Clue Counter")]
    public TextMeshProUGUI clueCounterText;

    [Header("Final UI")]
    public GameObject finalUI;
    public TextMeshProUGUI finalText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateClueCounter();
        finalUI.SetActive(false);
    }

    public void UpdateClueCounter()
    {
        clueCounterText.text = "Clues Found: " +
            ClueManager.cluesFound + "/7";
    }

    public void ShowFinalUI()
    {
        finalUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        finalText.text =
            "INVESTIGATION COMPLETE\n\n" +
            "Evidence collected:\n\n" +
            "• Neighbour witnessed the couple quarrelling and confirmed they were not on good terms\n\n" +
            "• Body found outside with visible cut marks\n\n" +
            "• Bloody axe recovered — confirmed murder weapon\n\n" +
            "• Two cups found in the room — a second person was present\n\n" +
            "• Blood on the floor marks the location of the attack\n\n" +
            "• Divorce papers found — couple was in serious conflict\n\n" +
            "• Footprints leading out of the bedroom indicate the suspect fled the scene\n\n" +
            "CONCLUSION: This was a premeditated murder.";
    }

    public void CloseFinalUI()
    {
        finalUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}