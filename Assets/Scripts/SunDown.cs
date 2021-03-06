using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SunDown : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] tiles;
    [SerializeField] SpriteRenderer end;
    [SerializeField] Tilemap tileMap;
    [SerializeField] float sunDownSpeed = 0.05f;
    [SerializeField] float sunDownLimit = 0f;

    bool canSunDown = false;
    float currColor = 1f;
    float currAlpha = 0f;

    void Update()
    {
		if (canSunDown && currColor > sunDownLimit)
		{
            currColor -= sunDownSpeed * Time.deltaTime;
            currAlpha += sunDownSpeed * Time.deltaTime;
			for (int i = 0; i < tiles.Length; i++)
			{
                tiles[i].color = new Vector4(currColor, currColor, currColor, 1);
            }
            
            tileMap.color = new Vector4(currColor, currColor, currColor, 1);
            end.color = new Vector4(1, 1, 1, currAlpha);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        canSunDown = true;
	}
}
