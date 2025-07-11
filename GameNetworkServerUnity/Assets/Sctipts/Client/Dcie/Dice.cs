using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class Dice : MonoBehaviour
{
    [SerializeField] private float rotatespeed = 5f;
    [SerializeField] private AudioSource DiceSound;

    public int diceIndex = -1;
    public DiceManager diceManager;

    private bool isbord;

    private void Awake()
    {
        if (!diceManager)
        {
            diceManager = FindAnyObjectByType<DiceManager>();
            if( diceManager == null)
            {
                Debug.LogError("diceManger�� ã�� �� �����ϴ�.");
            }
        }

    }

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
            Invoke("countDice", 3.2f);
            Invoke("delectDice", 4.5f);
        }
    }

    int showDiceCout()
    {
        Vector3 worldUp = Vector3.up;

        float maxDot = -1f;
        int result = 0;

    if (Vector3.Dot(transform.up, worldUp) > maxDot)
    {
        maxDot = Vector3.Dot(transform.up, worldUp);
        result = 2; // up�� 2
    }

    if (Vector3.Dot(-transform.up, worldUp) > maxDot)
    {
        maxDot = Vector3.Dot(-transform.up, worldUp);
        result = 5; // down�� 5
    }

    if (Vector3.Dot(transform.forward, worldUp) > maxDot)
    {
        maxDot = Vector3.Dot(transform.forward, worldUp);
        result = 1; // forward�� 1
    }

    if (Vector3.Dot(-transform.forward, worldUp) > maxDot)
    {
        maxDot = Vector3.Dot(-transform.forward, worldUp);
        result = 6; // back�� 6
    }

    if (Vector3.Dot(-transform.right, worldUp) > maxDot)
    {
        maxDot = Vector3.Dot(-transform.right, worldUp);
        result = 3; // left�� 3
    }

    if (Vector3.Dot(transform.right, worldUp) > maxDot)
    {
        maxDot = Vector3.Dot(transform.right, worldUp);
        result = 4; // right�� 4
    }

    return result;
    }
    public void countDice()
    {
        int value = showDiceCout();
        Debug.Log("�ֻ��� ����: " + value);

        if(diceIndex >= 0 && diceIndex < diceManager.dicecount.Length)
        {
            diceManager.dicecount[diceIndex] = value;
        }
        else
        {
            Debug.LogWarning("�ֻ��� �ε����� ��ȿ���� �ʴ�. : " + diceIndex);
        }

        if (diceManager.dicecount[0] != 0 && diceManager.dicecount[1] != 0)
        {
            diceManager.DiceNumber01 = diceManager.dicecount[0];
            diceManager.DiceNumber02 = diceManager.dicecount[1];
            diceManager.DiceSumNumber = diceManager.DiceNumber01 + diceManager.DiceNumber02;
            
            // UI
            diceManager.DiceCountUI.gameObject.SetActive(true);
            diceManager.DiceCountText.text = $"{diceManager.DiceSumNumber}";

            Debug.Log($"ù��° �ֻ����� ��: " + diceManager.dicecount[0]);
            Debug.Log($"�ι�° �ֻ����� ��: " + diceManager.dicecount[1]);
            Debug.Log($"�� �ֻ����� ���� ��: {diceManager.DiceSumNumber}");
        }
    }

    void delectDice()
    {
        diceManager.DiceCountUI.gameObject.SetActive(false);
        Destroy(gameObject);
    }
 }

