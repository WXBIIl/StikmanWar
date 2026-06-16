using UnityEngine;

public class MoveMent : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * speed * Time.deltaTime;
    }
}