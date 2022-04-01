namespace Assets.Sources.Model
{
    public interface ICopyable<out T>
    {
        T Copy();
    }
}