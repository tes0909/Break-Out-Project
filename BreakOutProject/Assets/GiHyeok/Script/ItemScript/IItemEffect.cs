using System.Collections;

public interface IItemEffect
{
    public abstract void Affect();
	public IEnumerator Applying(float delay);
}
