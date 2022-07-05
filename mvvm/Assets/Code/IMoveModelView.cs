public interface IMoveModelView 
{
    public IMove moveInterface { get; set; }
    
    public void Move(float dir, float deltaTime);
    
}
