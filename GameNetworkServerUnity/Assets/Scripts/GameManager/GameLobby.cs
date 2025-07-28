using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLobby : MonoBehaviour
{
     public void GameStart()
    {
        Invoke("startGame", 1.5f);
    }

    void startGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
