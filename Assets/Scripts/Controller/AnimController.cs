using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {

    [SerializeField]
    private Sprite[] sprites;

    private int index = 0;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float playPeriod = 1.0f; //两帧之间播放间隔
    private float timer = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer> playPeriod)
        {
            timer = 0;
            spriteRenderer.sprite = sprites[index++];

            if (index == sprites.Length)
                index = 0;
        }
    }
}
