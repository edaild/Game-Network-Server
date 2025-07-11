using Unity.VisualScripting;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private Transform DicePrifab;
    [SerializeField] private Transform DicePoint;
     public int DiceNumber01;
     public int DiceNumber02;

    private bool isTurn;
    public int[] dicecount = new int[2];

    private void Start()
    {
        isTurn = true;
    }
    private void Update()
    {
        if(isTurn && Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < 2; i++)
            {
                Instantiate(DicePrifab, DicePoint.position, Quaternion.identity);
                Dice dice = FindAnyObjectByType<Dice>();
                dice.diceIndex = i; 
            }
        }
       
    }
}
