namespace TheSquareLife_Consoled.Visualization;

internal interface IUserInputGetter<out T>
{
    public T GetUserNumberOf(string type);
}