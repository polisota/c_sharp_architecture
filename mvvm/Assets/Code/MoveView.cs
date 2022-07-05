public class MoveView 
{
    public IMoveModelView modelViewInterface;

    private void InitializeMove(IMoveModelView modelViewInterface)
    {
        this.modelViewInterface = modelViewInterface;
    }    
    
}
