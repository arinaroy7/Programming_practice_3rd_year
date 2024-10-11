using ImGuiNET;
using SixLabors.ImageSharp; 
using SixLabors.ImageSharp.Drawing;
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
  float ballX, ballY;
  float speedX = 2;
  float speedY = 1.5f; 
  float ballRadius = 20;

  Image<Rgba32> img = new Image<Rgba32>(WD, HG);
  nint imgid=0;

  void Draw() 
  {
    Brush fone = Brushes.Solid(Color.White);
    img.Mutate(x => x.Fill(fone));
    img.Mutate(x => x.Fill(Brushes.Solid(Color.Green), new EllipsePolygon(ballX, ballY, ballRadius)));
  }
  void MovementBall()
  {
    ballX += speedX;
    ballY += speedY;
    if (ballX - ballRadius < 0)
    {
        ballX = ballRadius; 
        speedX = -speedX;   //смена направления движения 
    }
    if (ballX + ballRadius > WD)
    {
        ballX = WD - ballRadius; 
        speedX = -speedX;
    }
    if (ballY - ballRadius < 0)
    {
        ballY = ballRadius; 
        speedY = -speedY;
    }
    if (ballY + ballRadius > HG)
    {
        ballY = HG - ballRadius; 
        speedY = -speedY;
    }
  }
  protected override void Render()
  {
    ImGui.Begin("Win");
    if (ImGui.Button("Выход")) Close();

    Draw();
    MovementBall();
    ImGui.End();

    RemoveImage("img"); 
    AddOrGetImagePointer("img", img, false, out imgid); //загружаем новую текстуру
    ImGui.Image(imgid, new (WD,HG)); //отображаем
  }
}