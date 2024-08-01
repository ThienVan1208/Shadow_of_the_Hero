using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Sprite cursorSprite;
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        ChangeCursor(cursorSprite);
    }

    // Hàm này để thay đổi con trỏ bằng sprite đã cắt
    public void ChangeCursor(Sprite newCursorSprite)
    {
        Texture2D cursorTexture = new Texture2D((int)newCursorSprite.rect.width, (int)newCursorSprite.rect.height);
        cursorTexture.SetPixels(newCursorSprite.texture.GetPixels((int)newCursorSprite.textureRect.x,
                                                                   (int)newCursorSprite.textureRect.y,
                                                                   (int)newCursorSprite.textureRect.width,
                                                                   (int)newCursorSprite.textureRect.height));
        cursorTexture.Apply();
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    // Hàm này để đặt lại con trỏ mặc định
    public void ResetCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
