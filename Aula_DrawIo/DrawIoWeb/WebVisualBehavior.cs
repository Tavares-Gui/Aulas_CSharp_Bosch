using System.Drawing;
 
using DrawIo;
using Blazor.Extensions.Canvas;
using Blazor.Extensions.Canvas.Canvas2D;
 
public class WebVisualBehavior : IVisualBehavior
{
    private Canvas2DContext context = null;
 
    public WebVisualBehavior(Canvas2DContext context)
        => this.context = context;
 
    public Task DrawDottedLine(PointF p, PointF q, Color color, float width)
    {
        throw new NotImplementedException();
    }
 
    public async Task DrawLine(PointF p, PointF q, Color color, float width)
    {
        await context.SetFillStyleAsync(colorToString(color));
        await context.BeginPathAsync();
        await context.MoveToAsync(p.X, p.Y);
        await context.LineToAsync(q.X, q.Y);
        await context.StrokeAsync();
    }
 
    public async Task DrawRectangle(RectangleF rect, Color color)
    {
        await context.BeginPathAsync();
        await context.SetFillStyleAsync(colorToString(color));
        await context.RectAsync(rect.X, rect.Y, rect.Width, rect.Height);
        await context.StrokeAsync();
    }
 
    public async Task DrawText(RectangleF rect, string text)
    {
        await context.SetFontAsync("20px Calibri");
        await context.SetStrokeStyleAsync(colorToString(Color.Black));
        await context.StrokeTextAsync(text, rect.X, rect.Y + rect.Height / 2);
    }
     
    public async Task FillRectangle(RectangleF rect, Color color)
    {
        await context.SetFillStyleAsync(colorToString(color));
        await context.FillRectAsync(rect.X, rect.Y, rect.Width, rect.Height);
    }
 
    private string colorToString(Color color)
        => $"rgb({color.R}, {color.G}, {color.B})";
}