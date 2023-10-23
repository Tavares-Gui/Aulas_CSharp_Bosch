using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using DrawIo;

Thread.CurrentThread
    .SetApartmentState(ApartmentState.Unknown);
Thread.CurrentThread
    .SetApartmentState(ApartmentState.STA);

Project project = new Project();

ApplicationConfiguration.Initialize();

var form = new Form();

form.WindowState = FormWindowState.Maximized;

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;
form.Controls.Add(pb);

form.Load += delegate
{
    Bitmap bitmap = new Bitmap(
        pb.Width, pb.Height
    );
    pb.Image = bitmap;
    Graphics g = Graphics.FromImage(bitmap);
    g.Clear(Color.White);
    DesktopVisualBehavior behavior = new(g);

    pb.MouseDown += (o, e) =>
    {
        project.MouseDown(e.Location);
    };

    form.KeyPreview = true;
    form.KeyDown += (o, e) =>
    {
        if (e.KeyCode == Keys.C)
        {
            project.Copy();
        }
        if (e.KeyCode == Keys.V)
        {
            project.Paste();
        }
        if (e.KeyCode == Keys.Z)
        {
            project.Undo();
        }
        if (e.KeyCode == Keys.Y)
        {
            project.Redo();
        }
    };

    project.Add(new ClassBox(
        behavior, new PointF(50, 50)
    ));

    System.Windows.Forms.Timer timer = new
    System.Windows.Forms.Timer();
    timer.Interval = 20;
    timer.Tick += async delegate
    {
        g.Clear(Color.White);
        await project.Draw();
        pb.Refresh();
    };
    timer.Start();
};

Application.Run(form);

public class DesktopVisualBehavior : IVisualBehavior
{
    Graphics g;
    public DesktopVisualBehavior(Graphics g)
    {
        this.g = g;
    }

    public Task DrawDottedLine(PointF p, PointF q, Color color, float width)
    {
        throw new System.NotImplementedException();
    }

    public async Task DrawLine(PointF p, PointF q, Color color, float width)
    {
        g.DrawLine(new Pen(color), p, q);
    }

    public async Task DrawRectangle(RectangleF rect, Color color)
    {
        g.DrawRectangle(
            new Pen(color),
            rect
        );
    }

    public async Task DrawText(RectangleF rect, string text)
    {
        g.DrawString(text, SystemFonts.MessageBoxFont,
            Brushes.Black, rect, 
            StringFormat.GenericTypographic
        );
    }

    public async Task FillRectangle(RectangleF rect, Color color)
    {
        g.FillRectangle(
            new SolidBrush(color),
            rect
        );
    }
}