using ImGuiNET;
using ClickableTransparentOverlay;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using System.Numerics;
using SixLabors.ImageSharp.Processing;

partial class Program : Overlay
{
    const int WD = 400; 
    const int HG = 400;

    Vector2 point1 = new Vector2(50, 50);
    Vector2 point2 = new Vector2(350, 50);
    Vector2 point3 = new Vector2(200, 350);

    Image<Rgba32> img = new Image<Rgba32>(WD, HG); 
    nint imgid = 0; 

    public Program(int wd, int hg) : base(wd, hg)
    {
        ReplaceFont("Cousine-Regular.ttf", 28, FontGlyphRangeType.Cyrillic);
    }

    public static void Main()
    {
        new Program(800, 600).Start().Wait();
    }

    void DrawTriangle() 
    {
        img.Mutate(context =>
        {
            context.Clear(Color.Pink);
            var pen = new SolidPen(Color.Black, 3);
            context.DrawPolygon(pen, new PointF[] { point1, point2, point3 });
        });
    }

    protected override void Render()
    {
        ImGui.Begin("Треугольник");

        ImGui.Text("Введите координаты точек треугольника:");
        ImGui.InputFloat2("Введите точку 1", ref point1);
        ImGui.InputFloat2("Введите точку 2", ref point2);
        ImGui.InputFloat2("Введите точку 3", ref point3);

        if (ImGui.Button("Нарисовать"))
        {
            DrawTriangle();
        }

        if (ImGui.Button("Выход")) Close();

        ImGui.End();

        RemoveImage("img");
        AddOrGetImagePointer("img", img, false, out imgid);
        ImGui.Image(imgid, new(WD, HG)); 
    }
}