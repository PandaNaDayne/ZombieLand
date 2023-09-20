using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    public CameraCapture cameraCapture;
    public AudioSource flashSound;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Save);
    }

    private void Save()
    {
        flashSound.Play();
        cameraCapture.CaptureScreenshot();
        cameraCapture.Save();
    }
}