using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn : MonoBehaviour {
    public Material mat;
    public Button btn;
    public ColorBlock colorBlock;
    public Tiles tiles;
    public Text btnText;

    private void Start() {
        colorBlock = btn.colors;
        btn.onClick.AddListener(Onclick);
        btnText = btn.GetComponentInChildren<Text>();
        tiles = FindObjectOfType<Tiles>();
    }

    void Onclick() {
        tiles.changeToMaterial = mat;
        for (var x = 0; x < tiles.materials.Count; x++) {
            if (tiles.materials[x] == mat) {
                tiles.materialIndex = x;
            }
        }
    }

    private void Update() {
        colorBlock.normalColor = mat.color;
        btn.colors = colorBlock;
        btnText.text = mat.name;
    }
}
