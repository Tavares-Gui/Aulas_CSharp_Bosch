using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

namespace DrawIo;

public class Project
{
    Stack<ProjectState> history = new();
    Stack<ProjectState> redoStack = new();
    public Project()
    {
        history.Push(
            new ProjectState()
        );
    }

    VisualObject copied = null;
    public void Copy()
    {
        var crr = history.Peek();
        copied = crr.Copy();
    }

    public void Paste()
    {
        Add(copied);
    }
    
    public void MouseDown(PointF pt)
    {
        var crr = history.Peek();
        crr.MouseDown(pt);
    }
    
    public void MouseMove(PointF pt)
    {
        var crr = history.Peek();
        crr.MouseMove(pt);
    }
    
    public void MouseUp(PointF pt)
    {
        var crr = history.Peek();
        crr.MouseUp(pt);
    }

    public void Add(VisualObject obj)
    {
        var crr = history.Peek();
        var clone = crr.Clone() as ProjectState;
        clone.Add(obj);
        history.Push(clone);
        redoStack.Clear();
    }

    public void Undo()
    {
        var poped = history.Pop();
        redoStack.Push(poped);
    }

    public void Redo()
    {
        var poped = redoStack.Pop();
        history.Push(poped);
    }

    public async Task Draw()
    {
        var crr = history.Peek();
        await crr.Draw();
    }

    private class ProjectState : ICloneable
    {
        VisualObject selected = null;
        List<VisualObject> objects = new();
        public void Add(VisualObject obj)
            => this.objects.Add(obj);
        public VisualObject Copy()
        {
            return selected?.Clone() as VisualObject;
        }

        public void MouseDown(PointF pt)
        {
            foreach (var obj in this.objects)
            {
                if (obj is ClassBox box &&
                    box.Rectangle.Contains(pt))
                    this.selected = obj;
            }
        }
        
        public void MouseMove(PointF pt)
        {

        }
        
        public void MouseUp(PointF pt)
        {
            
        }


        public object Clone()
        {
            ProjectState copy = new ProjectState();
            foreach (var obj in this.objects)
                copy.Add(obj.Clone() as VisualObject);
            return copy;
        }

        public async Task Draw()
        {
            foreach (var obj in this.objects)
                await obj.Draw(obj == selected);
        }
    }
}