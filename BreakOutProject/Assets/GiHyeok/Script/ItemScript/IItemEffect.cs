using System.Collections;
using UnityEngine;

public interface IItemEffect
{
    public abstract void Affect();
	public IEnumerator Applying(float delay);
}
