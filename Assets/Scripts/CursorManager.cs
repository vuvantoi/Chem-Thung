using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D customCursor; // Kéo thả hình ảnh con trỏ vào đây
    public Vector2 hotspot = Vector2.zero; // Điểm neo của con trỏ

    void Start()
    {
        Cursor.SetCursor(customCursor, hotspot, CursorMode.Auto);
    }
}
