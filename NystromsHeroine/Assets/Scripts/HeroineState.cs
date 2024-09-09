public class HeroineState
{
    public virtual HeroineState HandleInput(Heroine heroine) { return null; }
    public virtual void Update(Heroine heroine) { }
    public virtual void Enter(Heroine heroine) { }
    public virtual void Exit(Heroine heroine) { }
}