using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SaveSystem {
   public static void  SaveTile(Material material,string name,Color color) {
       TileData tile = new TileData(material,color);
       string json = JsonUtility.ToJson(tile);
       Debug.Log(json);
       PlayerPrefs.SetString(name,json);
   }

   public static TileData LoadTile(string name) {
       string p = PlayerPrefs.GetString(name);
       if (!string.IsNullOrEmpty(p)) {
           TileData tile = JsonUtility.FromJson<TileData>(p);
           if (tile != null) {
               return tile;
           }
       }

       return null;
   }
   
   
}