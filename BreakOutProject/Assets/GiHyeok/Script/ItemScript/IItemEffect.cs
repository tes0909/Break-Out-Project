using System.Collections;
using UnityEngine;

public interface IItemEffect
{
    Color color { get; set; }
    public abstract void Affect();
	public IEnumerator Applying(float delay);
}
