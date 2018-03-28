using UnityEngine;
using System.Collections;

public static class GizmosController {

    public static Vector2 AngleToVector2(float angle, float distanceFromPoint)
    {
        return Quaternion.Euler(0, 0, -angle) * Vector2.up * distanceFromPoint;
    }

    public static void DrawPlus(Vector2 pos, float size)
    {
        DrawPlus(pos, size, Color.red);
    }

    public static void DrawCross(Vector2 pos, float size)
    {
        DrawCross(pos, size, Color.red);
    }

    public static void DrawPlus(Vector2 pos, float size, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawLine(pos - Vector2.up * size, pos + Vector2.up * size);
        Gizmos.DrawLine(pos - Vector2.left * size, pos + Vector2.left * size);
    }

    public static void DrawCross(Vector2 pos, float size, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawLine(pos - AngleToVector2(45, size), pos + AngleToVector2(45, size));
        Gizmos.DrawLine(pos - AngleToVector2(-45, size), pos + AngleToVector2(-45, size));
    }
}
