using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Ссылки на объекты")]
    [SerializeField] private GameObject prefabToSpawn; // Наш UI-префаб
    [SerializeField] private Transform canvasTransform; // Ссылка на Canvas или нужную панель

    public void SpawnPrefab()
    {
        // Спавним префаб и сразу назначаем ему родителя
        GameObject spawnedObject = Instantiate(prefabToSpawn, canvasTransform);

        // Сбрасываем локальные координаты в ноль, чтобы он встал ровно по центру родителя
        spawnedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        // Корректируем масштаб (иногда UI-префабы спавнятся огромными)
        spawnedObject.transform.localScale = Vector3.one;
    }
}