using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Transform player;
    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(input != Vector2.zero)
        {
            player.Translate(_movementSpeed * input * Time.deltaTime);
            player.position = new Vector3(Mathf.Clamp(player.position.x, MapModel.MinFreeMapPosition.x - 1, MapModel.MaxFreeMapPosition.x + 1), Mathf.Clamp(player.position.y, MapModel.MinFreeMapPosition.y - 0.5f, MapModel.MaxFreeMapPosition.y + 1.5f));
        }
    }
}
