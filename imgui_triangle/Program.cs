using System.Numerics;

public static class Helpers
{
    public static bool IsValidTriangle(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        float area = 0.5f * MathF.Abs(
            p1.X * (p2.Y - p3.Y) +
            p2.X * (p3.Y - p1.Y) +
            p3.X * (p1.Y - p2.Y));

        return area > 0; 
    }
    public static uint Rgb(int r, int g, int b)
    {
        return (uint)(((r << 24) | (g << 16) | (b << 8) | 255) & 0xffffffffL);
    }
    public static Vector2 GetCentroid(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        return new Vector2(
            (p1.X + p2.X + p3.X) / 3,
            (p1.Y + p2.Y + p3.Y) / 3);
    }
}


