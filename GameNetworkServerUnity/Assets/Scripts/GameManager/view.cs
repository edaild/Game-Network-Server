using UnityEngine;

public class view : MonoBehaviour
{
    private void Start()
    {
        // 배경색 설정
        Camera.main.backgroundColor = Color.black;
    }

    private void Update()
    {
        // 만약 해상도나 전체화면 설정이 바뀌었다면 다시 설정
        if (Screen.width != 1920 || Screen.height != 1080 || Screen.fullScreenMode != FullScreenMode.FullScreenWindow)
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        }
    }
}
