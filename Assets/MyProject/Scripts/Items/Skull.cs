using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    private Player player;
    public int value;

    [Header("Up and Down Variables")]
    [SerializeField] private float strengh;
    private float initialPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        initialPos = transform.position.y;
    }

    private void Update()
    {
        Vector3 _newPos = transform.position;

        _newPos.y = initialPos + (Mathf.Sin(Time.timeSinceLevelLoad) * strengh);
        transform.position = _newPos;
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            player.GainSkulls(value);
            Destroy(gameObject);
        }
    }
}
