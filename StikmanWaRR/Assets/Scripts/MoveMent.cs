using Unity.Netcode;
using UnityEngine;

public class MoveMent : NetworkBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        // Исправлено: IsOwner вместо IsOvner
        if (!IsOwner)
        {
            return;
        }

        var horizontal = Input.GetAxis("Horizontal");

        // Если игрок нажимает на кнопки движения
        if (horizontal != 0)
        {
            // Отправляем значение оси на сервер
            MoveServerRpc(horizontal);
        }
    }

    [ServerRpc]
    // Передаем horizontal как параметр в RPC метод
    void MoveServerRpc(float horizontalInput)
    {
        // Сервер изменяет позицию, и она автоматически синхронизируется через NetworkTransform
        transform.position += new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;
    }
}