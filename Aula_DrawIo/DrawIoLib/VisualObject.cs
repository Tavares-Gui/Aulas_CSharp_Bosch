using System;
using System.Threading.Tasks;
 
namespace DrawIo;
 
public abstract class VisualObject : ICloneable
{
    protected IVisualBehavior g;
 
    public VisualObject(IVisualBehavior g)
        => this.g = g;
     
    public abstract Task Draw(bool selected);
  
    public abstract object Clone();
}