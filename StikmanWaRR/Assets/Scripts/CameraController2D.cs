using UnityEngine;
using Unity.Cinemachine;

public class CinemachineZoom2D : MonoBehaviour
{
    [Header("Настройки Input Manager")]
    [SerializeField] private string zoomAxisName = "Zoom"; // Наша ось для колесика

    [Header("Ограничения размера камеры")]
    [SerializeField] private float minZoom = 3f;
    [SerializeField] private float maxZoom = 15f;

    [Header("Параметры плавности")]
    // Для колесика мыши скорость лучше поставить побольше (например, 20-30), 
    // чтобы камера реагировала на каждый "щелчок" колесика шустрее
    [SerializeField] private float manualZoomSpeed = 25f;
    [SerializeField] private float lerpSpeed = 5f;

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

        // Считываем кручение колесика
        float zoomInput = Input.GetAxisRaw(zoomAxisName);

        if (zoomInput != 0)
        {
            // На большинстве мышек прокрутка "вверх" (от себя) выдает положительное число.
            // Обычно "от себя" означает приблизить, поэтому мы вычитаем, уменьшая размер линзы.
            targetZoom -= zoomInput * manualZoomSpeed * Time.deltaTime;
        }

        // Ограничиваем размеры
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

        // Плавно применяем
        vCam.Lens.OrthographicSize = Mathf.Lerp(vCam.Lens.OrthographicSize, targetZoom, lerpSpeed * Time.deltaTime);
    }
}