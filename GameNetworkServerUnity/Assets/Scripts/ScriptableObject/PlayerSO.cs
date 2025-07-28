using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "ScriptableObject/Plaeyr")]
public class PlayerSO : ScriptableObject
{
    public float playerWarkSpeed = 5f;
    public float playerRunSpeed = 3f;
    public float PlayerRotateSpeed = 3f;
    public float playerJumpForce = 5f;
    public Animator playerAnimator;
    public Rigidbody playerRigidbody;

    void ride_bicycle()
    {
        playerWarkSpeed += 5f;
    }
}
