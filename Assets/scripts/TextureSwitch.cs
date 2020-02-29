using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSwitch : MonoBehaviour
{
    public Texture[] textures;

    public int currentTexture;

    private MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentTexture++;
            currentTexture %= textures.Length;
            _meshRenderer.material.mainTexture = textures[currentTexture];
        }
    }
}