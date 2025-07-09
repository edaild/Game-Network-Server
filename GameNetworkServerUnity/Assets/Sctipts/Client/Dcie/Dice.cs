using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class Dice : MonoBehaviour
{
    [SerializeField] private float rotatespeed = 5f;
    [SerializeField] private AudioSource DiceSound;

    private bool isbord;

    private void Update()
    {
        if (!isbord)
        {
            transform.Rotate(rotatespeed * Time.deltaTime, 0, rotatespeed * Time.deltaTime);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bord") && !isbord)
        {
            isbord = true;
            DiceSound.Play(); //���
            Invoke("countDice", 2f);
            Invoke("delectDice", 3f);
        }
    }

    void countDice()
    {
        Debug.Log("�ֻ��� ���� ���� ���");
    }

    void delectDice()
    {
        Destroy(gameObject);
    }
 }

