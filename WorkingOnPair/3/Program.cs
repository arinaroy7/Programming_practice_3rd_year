// See https://raa.is/ImStudio/

using System.Runtime.Serialization;
using ImGuiNET;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Vortice.DXCore;

struct Note
{
    public string Name; // название ноты 
    public float Freq; // частота ноты
    public Note(string name, float freq)
    {
        Name = name;
        Freq = freq;
    }
}

partial class Program
{
    //картинка
    const int WD = 1200;
    const int HG = 200;
    Image<Rgba32> img = new Image<Rgba32>(WD, HG);
    nint imgid = 0;

    //данные
    (Note note, bool on)[] Octave = new (Note, bool)[]
    {
        (new Note("До",    261.63f), true), // ноты со значениями 
        (new Note("До#",   277.18f), false),
        (new Note("Ре",    293.66f), false),
        (new Note("Ре#",   311.13f), false),
        (new Note("Ми",    329.63f), false),
        (new Note("Фа",    349.23f), false),
        (new Note("Фа#",   366.99f), false),
        (new Note("Соль",  392f),    false),
        (new Note("Соль#", 415.3f),  false),
        (new Note("Ля",    440),     false),
        (new Note("Ля#",   466.16f), false),
        (new Note("Си",    493.88f), false),
    };
    float graphLeft = 0;
    float graphRight = 8;
    float graphTop = 4;
    float graphBottom = -4;


    protected override void Render()
    {
        ImGui.Begin("Graph");

        if (ImGui.Button("Выход")) Close();

        ImGui.PushItemWidth(600);
        ImGui.DragFloatRange2("Ширина", ref graphLeft, ref graphRight);
        ImGui.PushItemWidth(600);
        ImGui.DragFloatRange2("Высота", ref graphBottom, ref graphTop);

        ImGui.Spacing();

        Draw();
        RemoveImage("img");
        AddOrGetImagePointer("img", img, false, out imgid);
        ImGui.Image(imgid, new (WD,HG));

        ImGui.Spacing();

        for(int i=0;i<Octave.Length;i++)
        {
            ImGui.Checkbox($"{Octave[i].note.Name}", ref Octave[i].on);
            ImGui.SameLine(); // функция, которая выводит текст сразу после чекбокса 
            ImGui.Text($"{Octave[i].note.Freq}");
        }
    }
    void Draw()
    {
        Brush fone = Brushes.Solid(Color.White);
        Pen pen= new SolidPen(Color.Red);

        img.Mutate(x =>
        {
            x.Fill(fone);
            for (int i=0; i<WD-1; i++)
            {
                var sx1 = i;
                var sx2 = i+1;

                var x1 = Convert(sx1, 0,WD, graphLeft,graphRight);
                var x2 = Convert(sx2, 0,WD, graphLeft,graphRight);
                var y1 = GetY(x1);
                var y2 = GetY(x2);

                var sy1 = Convert(y1, graphBottom,graphTop, HG,0);
                var sy2 = Convert(y2, graphBottom,graphTop, HG,0);

                x.DrawLine(pen, new PointF(sx1,sy1), new PointF(sx2,sy2));
            }
        });
    }

    float GetY(float x)
    {
        float result = 0;
        for(int i=0;i<Octave.Length;i++)
            if (Octave[i].on)
                result += (float)Math.Cos(x / Math.PI * Octave[i].note.Freq);
        return result;
    }

    float Convert (float value, float a, float b, float A, float B)
    {
        return B - (B-A)*(b-value)/(b-a);
    }
}

