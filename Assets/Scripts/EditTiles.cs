using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EditTiles : MonoBehaviour {
    public InputField nameInput;
    public List<Button> colorBtn;
    public Tiles tiles;

    private void Start() {
        var colorblock = colorBtn[0].colors;
        colorblock.normalColor = Color.white;
        colorBtn[0].colors = colorblock;
        colorblock.normalColor = Color.black;
        colorBtn[1].colors = colorblock;
        colorblock.normalColor = Color.red;
        colorBtn[2].colors = colorblock;
        colorblock.normalColor = Color.green;
        colorBtn[3].colors = colorblock;
        colorblock.normalColor = Color.blue;
        colorBtn[4].colors = colorblock;
        colorblock.normalColor = Color.magenta;
        colorBtn[5].colors = colorblock;
        colorblock.normalColor = Color.yellow;
        colorBtn[6].colors = colorblock;
        colorBtn[0].onClick.AddListener(delegate { ChangeColor(0);});
        colorBtn[1].onClick.AddListener(delegate { ChangeColor(1);});
        colorBtn[2].onClick.AddListener(delegate { ChangeColor(2);});
        colorBtn[3].onClick.AddListener(delegate { ChangeColor(3);});
        colorBtn[4].onClick.AddListener(delegate { ChangeColor(4);});
        colorBtn[5].onClick.AddListener(delegate { ChangeColor(5);});
        colorBtn[6].onClick.AddListener(delegate { ChangeColor(6);});
        for (var y = 0; y < 10; y++) {
            for (var x = 0; x < 10; x++) {
               tiles.tileArray[x, y].GetComponent<MeshRenderer>().material = tiles.materials[0];
               tiles.tileArray[x, y].GetComponent<Tile>().material =  tiles.materials[0];
            }
        }
        
    }

    public void ChangeName() {
        tiles.materials[tiles.materialIndex].name = nameInput.text;
    }

     void ChangeColor(int index) {
         tiles.materials[tiles.materialIndex].color = colorBtn[index].colors.normalColor;
         
     }

    private void Update() {
    }
}