using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DiceManager : MonoBehaviour
{
    [Header("Prifab")]
    [SerializeField] private Transform DicePrifab;
    [SerializeField] private Transform DicePoint;

    [Header("ShowDiceManger")]
    public int DiceNumber01;
    public int DiceNumber02;
    public int DiceSumNumber;
    public int[] dicecount = new int[2];
    private bool isTurn;

    [Header("UI")]
    public GameObject DiceCountUI;
    public Text DiceCountText;

    private void Start()
    {
        isTurn = true;
    }
    private void Update()
    {
        if(isTurn && Input.GetKeyDown(KeyCode.Space))
        {
            TurnButton();
        }
    }

    private void TurnButton()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(DicePrifab, DicePoint.position, Quaternion.identity);
            Dice dice = FindAnyObjectByType<Dice>();
            dice.diceIndex = i;
        }
    }
}
