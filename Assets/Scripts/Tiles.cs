using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class Tiles : MonoBehaviour {
    public GameObject tile;
    public GameObject[,] tileArray = new GameObject[10, 10];
    public Button grass, water;
    public Material changeToMaterial;
    public Text grassTxt, waterTxt;
    public List<Material> materials;
    public Text selectedTile;
    [HideInInspector] public int materialIndex;
    public Button btnPref;
    public GameObject layout;

    void Awake() {
        changeToMaterial = materials[0];
        var grassColor = grass.colors;
        grassColor.normalColor = materials[0].color;
        grass.colors = grassColor;
        var watercolor = water.colors;
        watercolor.normalColor = materials[1].color;
        water.colors = watercolor;
        for (var y = 0; y < 10; y++) {
            for (var x = 0; x < 10; x++) {
                var xTile = Instantiate(tile, new Vector3(0, 0, 0), Quaternion.identity);
                xTile.transform.position = new Vector3(xTile.transform.position.x + x, xTile.transform.position.y + y,
                    xTile.transform.position.z);
                xTile.GetComponent<Tile>().material = materials[0];
                xTile.GetComponent<MeshRenderer>().material = materials[0];
                tileArray[x, y] = xTile;
            }
        }
    }
    
    

    public void ClickedGrass() {
        changeToMaterial = materials[0];
        var grasscolor = grass.colors;
        grasscolor.normalColor = materials[0].color;
        grass.colors = grasscolor;
        materialIndex = 0;
    }

    public void ClickedWater() {
        changeToMaterial = materials[1];
        var watercolor = water.colors;
        watercolor.normalColor = materials[1].color;
        water.colors = watercolor;
        changeToMaterial = materials[1];
        materialIndex = 1;
    }

    public void SaveTiles() {
        for (var y = 0; y < 10; y++) {
            for (var x = 0; x < 10; x++) {
                SaveSystem.SaveTile(tileArray[x, y].GetComponent<Tile>().material, $"tile{x}{y}",tileArray[x, y].GetComponent<MeshRenderer>().material.color);
            }
        }
    }

    public void LoadTiles() {
        for (var y = 0; y < 10; y++) {
            for (var x = 0; x < 10; x++) {
                TileData data = SaveSystem.LoadTile($"tile{x}{y}");
                if (data.material == null) {
                    data.material = materials[0];
                }

                tileArray[x, y].GetComponent<MeshRenderer>().material = data.material;
                tileArray[x, y].GetComponent<Tile>().material = data.material;
                tileArray[x, y].GetComponent<MeshRenderer>().material.color = data.color;
            }
        }
    }

    public void AddTile() {
        var btn = Instantiate(btnPref, layout.transform);
        var mat = new Material(changeToMaterial);
        mat.name = "New Tile";
        materials.Add(mat);
        mat.color = Color.cyan;
        var btnS = btn.GetComponent<Btn>();
        btnS.mat = mat;
    }

    public void Reset() {
        materials[0].color = Color.green;
        materials[0].name = "Grass";
        materials[1].color = Color.blue;
        materials[1].name = "Water";
        for (var y = 0; y < 10; y++) {
            for (var x = 0; x < 10; x++) {
                tileArray[x, y].GetComponent<MeshRenderer>().material = materials[0];
                tileArray[x, y].GetComponent<Tile>().material = materials[0];
            }
        }
    }

    void Update() {
        if (grassTxt.text != materials[0].name) {
            grassTxt.text  = materials[0].name;
        }
        if (waterTxt.text != materials[1].name) {
            waterTxt.text = materials[1].name;
        }

        if (grass.colors.normalColor != materials[0].color) {
            var colorblock = grass.colors;
            colorblock.normalColor = materials[0].color;
            grass.colors = colorblock;
        }
        if (water.colors.normalColor != materials[1].color) {
            var colorblock = water.colors;
            colorblock.normalColor = materials[1].color;
            water.colors = colorblock;
        }
        if (string.IsNullOrEmpty(selectedTile.text)) {
            selectedTile.text = "No selected Tile";
        } else selectedTile.text = changeToMaterial.name;

        if (changeToMaterial != null)
            if (Input.GetMouseButtonDown(0)) {
                var cam = FindObjectOfType<Camera>();
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit)) {
                    hit.collider.GetComponent<MeshRenderer>().material = changeToMaterial;
                    hit.collider.GetComponent<Tile>().material = changeToMaterial;
                }
            }
    }
}