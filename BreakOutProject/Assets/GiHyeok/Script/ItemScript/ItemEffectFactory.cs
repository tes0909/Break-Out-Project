using UnityEngine;

public class ItemEffectFactory
{
    public static ICommand CreateItem(ItemType type)
    {
		switch (type)
		{
			case ItemType.multiBall:
				return  new MultiBall();

			case ItemType.longPaddle:
				return  new LongPaddle();

			case ItemType.screenControl:
				return  new ScreenControl();

			case ItemType.timeControl:
				return  new TimeControl();
		}
        Debug.LogWarning("Wrong Item Type");
        return null;
    }
}
