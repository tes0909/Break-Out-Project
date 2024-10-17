using UnityEngine;

public class SpawnSceneChanger:MonoBehaviour
{
    private readonly string filePath = "Prefabs/Animation/FadeInAnim";

    private void Awake()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>(filePath));
    }    
}