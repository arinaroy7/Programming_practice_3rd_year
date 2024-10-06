using ImGuiNET;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Numerics;

partial class Program 
{
  const int WD=200;
  const int HG=200;
  float currentX = 100f;
  float currentY = 100f;

  public static void Main()
  {
    new Program(1920, 1080).Start.Wait();
  }
  void Draw() 
  {
    ImDrawListPtr drawList = ImGui.GetWindowDrawList();
    Vector2 position = new Vector2(currentX, currentY);
    float radius = 50f;
    uint color = ImGui.GetColorU32(new Vector4(0.0f, 1.0f, 0.0f, 1.0f));
    drawList.AddCircleFilled(position, radius, color); //рис закрашенный круг
  }
  protected override void Render() // метод для отрисовки шара в окне
  {
    ImGui.Begin("Win");
    if (ImGui.Button("Выход"))
    {
        Close();
    }
    Draw();
    ImGui.End();
  }
}