using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderTest : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeSprite(0);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeSprite(1);
        }
    }

    void ChangeSprite(int numberSprite)
    {
        spriteRenderer.sprite = sprites[numberSprite];
    }
}
