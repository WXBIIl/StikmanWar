using UnityEngine;

public class StickWarManager : MonoBehaviour
{
    public static StickWarManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<StickWarManager>();
                if (_instance == null)
                {
                    Debug.LogError("Скрипт StickWarManager не найден на сцене! Убедись, что он висит на объекте IsPlayerBase.");
                }
            }
            return _instance;
        }
    }
    private static StickWarManager _instance;

    public enum GameOrder { Defend, Attack }

    [Header("Настройки команд")]
    public GameOrder currentOrder = GameOrder.Defend; // Текущий приказ для твоих юнитов

    [Header("Экономика")]
    public int gold = 100;         // Стартовое золото
    public int goldPerClick = 10;  // Сколько дается за клик по базе

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Пассивный доход: +20 золота каждые 2 секунды
        InvokeRepeating(nameof(AddPassiveGold), 2f, 2f);
    }

    private void Update()
    {
        // Управление командами: Q - Оборона, E - Атака
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentOrder = GameOrder.Defend;
            Debug.Log("Приказ армии: ОБОРОНА! Стоим на месте.");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentOrder = GameOrder.Attack;
            Debug.Log("Приказ армии: АТАКА! Вперед на врага!");
        }
    }

    private void AddPassiveGold()
    {
        gold += 20;
    }

    // Метод кликера: сработает, если на объекте с этим скриптом есть любой Collider 2D
    private void OnMouseDown()
    {
        gold += goldPerClick;
        Debug.Log($"Клик по базе! Текущее золото: {gold}");
    }
}