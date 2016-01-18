using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class Item : ScriptableObject {
    public ItemTypes itemType;
    public string description;
    public Sprite uiTexture;
    public Object itemPrefab;

}
