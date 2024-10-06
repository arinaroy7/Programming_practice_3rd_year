// See https://raa.is/ImStudio/

/*using ImGuiNET;

partial class Program
{
    protected override void Render()
    {
        ImGui.Begin("Win");
        if (ImGui.Button("Выход"))
            Close();
        ImGui.Text("Hello");

        //ImGui.ShowDemoWindow();
        //ShowFone();
    }
    
}*/
// See https://raa.is/ImStudio/

using ImGuiNET;
using SixLabors.ImageSharp; // умеет в памяти создавать изображения сама
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

partial class Program
{
    const int WD = 200;
    const int HG = 200;
    Image<Rgba32> img = new Image<Rgba32>(WD, HG);
    nint imgid = 0;

    int inner = 20;
    int outer = 50;
    int prongs = 5;

    protected override void Render()
    {
        ImGui.Begin("Win"); 


        // по умолчанию все функции рисования, создают новые кратинки, перерисовывают 
        // исп функцию Mutate, чтобы новая картинка не рисовалась 


        if (ImGui.Button("Выход")) Close(); // добавление кнопки

        ImGui.InputInt("Inner", ref inner); // контуры ввода, которые вкладывают типы данных
        ImGui.InputInt("Outer", ref outer);
        ImGui.InputInt("Prongs", ref prongs);

        Draw();

        RemoveImage("img"); // 
        AddOrGetImagePointer("img", img, false, out imgid); // "имя", объект с нашим изображ
        // чтобы для картинки получ идентификатор, нужно создать функцию. out imgid - переменная, в которую кладем идентификатор
        ImGui.Image(imgid, new (WD,HG)); // вызов функции Image, которая добавляет кратинку в наш интерфейс
    }

    void Draw()
    {
        // вспомогательные функции вынесены здесь
        Brush fone = Brushes.Solid(Color.White);
        PatternBrush brush = Brushes.Horizontal(Color.Red, Color.Blue);
        PatternPen pen = Pens.DashDot(Color.Green, 5);
        Star star = new(x: outer, y: outer, prongs: prongs, innerRadii: inner, outerRadii: outer);

        img.Mutate(x => x
            .Fill(fone)
            .Fill(brush, star)
            .Draw(pen, star)
        );
    }
    // дз нарисовать детскую картинку домик, солнышко, дерево. 
    // рисование каждый кадр. шарик, который летает по картинке и отскакивает 
    // для изобр добавить input, чтобы кстомизировать изображение. Например у шарика управлять скоростью 
}