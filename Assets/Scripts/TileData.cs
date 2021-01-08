using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TileData {
    public Material material;
    public Color color;

    public TileData(Material material, Color color) {
        this.material = material;
        this.color = color;
    }
}
