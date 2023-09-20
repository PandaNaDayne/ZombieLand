using UnityEngine;
using System.IO;

public class CameraCapture : MonoBehaviour
{
    public Camera captureCamera;
    private byte[] capturedBytes;

    private void Awake()
    {
        QualitySettings.antiAliasing = 8; // Установите желаемое значение сглаживания
        captureCamera.targetTexture = new RenderTexture(captureCamera.pixelWidth, captureCamera.pixelHeight, 24);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CaptureScreenshot();
        }
    }

    public void CaptureScreenshot()
    {
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = captureCamera.targetTexture;
        captureCamera.Render();

        Texture2D image = new Texture2D(captureCamera.targetTexture.width, captureCamera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, captureCamera.targetTexture.width, captureCamera.targetTexture.height), 0, 0);
        image.Apply();

        RenderTexture.active = currentRT;

        capturedBytes = image.EncodeToPNG();
    }

    public void Save()
    {
        if (capturedBytes != null)
        {
            string base64Data = System.Convert.ToBase64String(capturedBytes);
            string jsCode = @"
                var existingImage = document.getElementById('screenshot-image');
                if (existingImage) {
                    existingImage.remove();
                }

                var container = document.createElement('div');
                container.style.display = 'flex';
                container.style.alignItems = 'center';
                container.style.justifyContent = 'center';
                container.style.position = 'fixed';
                container.style.top = '50%';
                container.style.left = '50%';
                container.style.transform = 'translate(-50%, -50%)';
                container.style.width = '50%';
                container.style.height = '70%';
                container.style.backgroundColor = 'rgba(128, 0, 128, 0.8)';
                container.style.border = '2px solid black';
                container.style.zIndex = '9999';
                
                var text = document.createElement('p');
                text.innerHTML = 'ПКМ чтобы скачать';
                text.style.color = 'white';
                text.style.position = 'absolute';
                text.style.bottom = '10px';
                text.style.right = '10px';
                text.style.fontSize = '14px';
                
                var img = new Image();
                img.id = 'screenshot-image';
                img.src = 'data:image/png;base64," + base64Data + @"';
                img.style.objectFit = 'contain'; 
                img.style.width = '100%';
                img.style.height = '100%';

                var closeButton = document.createElement('button');
                closeButton.innerHTML = 'Закрыть';
                closeButton.style.position = 'absolute';
                closeButton.style.top = '10px';
                closeButton.style.right = '10px';
                closeButton.style.padding = '8px 16px';
                closeButton.style.backgroundColor = 'white';
                closeButton.style.color = 'black';
                closeButton.style.border = 'none';
                closeButton.style.borderRadius = '0';
                closeButton.addEventListener('click', function() {
                    container.remove();
                });
                

                container.appendChild(img);
                container.appendChild(text);
                container.appendChild(closeButton);
                document.body.appendChild(container);
            ";

            Application.ExternalEval(jsCode);
        }
        else
        {
            Debug.LogWarning("No captured image to save.");
        }
    }
}
