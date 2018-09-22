using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IRecycle
{
    //Sprite array to choose from
    public Sprite[] sprites;

    public Vector2 colliderOffset = Vector2.zero;

    public void Restart()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];//Pick a random sprite from the array

        //Resize the colider for the sprite
        var collider = GetComponent<BoxCollider2D>();
        var size = renderer.bounds.size;//Set it to the sprite bounds
        size.y += colliderOffset.y;//Change the y offset of the collider

        collider.size = size;
        collider.offset = new Vector2(-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);

    }

    public void Shutdown()
    {

    }
}
