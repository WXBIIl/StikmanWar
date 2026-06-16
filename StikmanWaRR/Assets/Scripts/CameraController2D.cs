using UnityEngine;
using Unity.Cinemachine;

public class CinemachineZoom2D : MonoBehaviour
{
    [Header("Настройки Input Manager")]
    [SerializeField] private string zoomAxisName = "Zoom"; // Имя оси, которую мы создали

    [Header("Ограничения размера камеры")]
    [SerializeField] private float minZoom = 3f;
    [SerializeField] private float maxZoom = 15f;

    [Header("Параметры плавности")]
    [SerializeField] private float manualZoomSpeed = 5f;
    [SerializeField] private float lerpSpeed = 4f;

    private float targetZoom;
    private CinemachineCamera vCam;

    void Start()
    {
        vCam = GetComponent<CinemachineCamera>();

        if (vCam != null)
        {
            targetZoom = vCam.Lens.OrthographicSize;
        }
    }

    void Update()
    {
        if (vCam == null) return;

        // Считываем значение с оси Input Manager (-1, 0 или 1)
        float zoomInput = Input.GetAxisRaw(zoomAxisName);

        // В Input Manager кнопка Positive (+) — это P (приближение). 
        // Приблизить — значит уменьшить OrthographicSize. Поэтому мы вычитаем (!) значение инпута.
        if (zoomInput != 0)
        {
            targetZoom -= zoomInput * manualZoomSpeed * Time.deltaTime;
        }

        // Ограничиваем размеры
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        // Плавно меняем размер линзы камеры
        vCam.Lens.OrthographicSize = Mathf.Lerp(vCam.Lens.OrthographicSize, targetZoom, lerpSpeed * Time.deltaTime);
    }
}