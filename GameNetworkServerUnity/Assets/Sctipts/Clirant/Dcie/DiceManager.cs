using Unity.VisualScripting;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private Transform DicePrifab;
    [SerializeField] private Transform DicePoint;

    private bool isTurn;


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
            }
        }
    }
}
