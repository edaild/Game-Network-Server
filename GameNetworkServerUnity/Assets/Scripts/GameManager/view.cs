using UnityEngine;

public class view : MonoBehaviour
{
    private void Start()
    {
        // ���� ����
        Camera.main.backgroundColor = Color.black;
    }

    private void Update()
    {
        // ���� �ػ󵵳� ��üȭ�� ������ �ٲ���ٸ� �ٽ� ����
        if (Screen.width != 1920 || Screen.height != 1080 || Screen.fullScreenMode != FullScreenMode.FullScreenWindow)
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        }
    }
}
