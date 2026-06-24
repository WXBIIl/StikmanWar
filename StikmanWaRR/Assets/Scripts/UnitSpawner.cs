using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitPrefab;    // Префаб юнита
    public Transform spawnPoint;     // Точка спавна у базы

    [Header("Настройки Игрока")]
    public bool isPlayerBase = true;
    public int unitCost = 100;

    [Header("Настройки ИИ Врага")]
    public float enemySpawnInterval = 5f; // Враг спавнит юнита раз в 5 секунд

    void Start()
    {
        // Если это база врага, запускаем авто-спавн юнитов
        if (!isPlayerBase)
        {
            InvokeRepeating(nameof(SpawnEnemyUnit), 2f, enemySpawnInterval);
        }
    }

    void Update()
    {
        // Если это наша база — спавним вручную по нажатию на кнопку «1»
        if (isPlayerBase && Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (StickWarManager.Instance.gold >= unitCost)
            {
                StickWarManager.Instance.gold -= unitCost;
                Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }

    void SpawnEnemyUnit()
    {
        Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);
    }
}