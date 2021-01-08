using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public Material material;

    private void Start() {
       material = GetComponent<MeshRenderer>().material;
    }
}