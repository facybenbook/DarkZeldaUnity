using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class Item : ScriptableObject {

    public string description;
    public Texture2D uiTexture;
    public Object itemPrefab;

}
