using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class pixelSurrogateController : MonoBehaviour
{

    [ExecuteInEditMode]
    [Header("Texture Settings:")]
    [SerializeField]
    private Texture2D sourceTexture; // source texture to copy
    [HideInInspector] private Rect sourceRect; // rect refernce that sets dimensions to read source
    [HideInInspector] private float setWidth; // width of texture
    [HideInInspector] private float setHeight; // height of teture
    private Texture2D destinationTexture; // destination texture to write
    private Color[] destPix; // destination texture pixel array
    [Header("Mesh Options: Fastest is Quad")]
    [SerializeField]
    private bool enableColliders = false; // create with colliders?
    [SerializeField] private bool useCubesInsteadOfQuads = false; // create with cubes instead of quads?
    [SerializeField] private PrimitiveType meshType = PrimitiveType.Quad; // to store the selection of mesh type


    void Start()
    {


    }

    public void  updateWH(){

        sourceRect.width = sourceTexture.width;
        sourceRect.height = sourceTexture.height;
        setWidth = sourceRect.width;
        setHeight = sourceRect.height;

    }

    public void hatchemall()
    {
        
        // all x and y of the texture to iterate
        int x = Mathf.FloorToInt(sourceRect.x);
        int y = Mathf.FloorToInt(sourceRect.y);
        int width = Mathf.FloorToInt(sourceRect.width);
        int height = Mathf.FloorToInt(sourceRect.height);

        Color[] pix = sourceTexture.GetPixels(x, y, width, height); // get the source texture pixels into the array

        destinationTexture = new Texture2D(width, height); // set the dimensions of teh output texture, must be equal to source

        int n = 0; // x iteration
        int nn = 0; // y iteration

        if(!useCubesInsteadOfQuads){ // decide before processing whether quad or cube is enabled within the inspector

            meshType = PrimitiveType.Quad; // set varibale to quad

        }else{  // else set varibale to cube

            meshType = PrimitiveType.Cube;

        }

        foreach (Color cs in pix) // for each color in the color array from source texture
        {

            if (nn <= setHeight) // if y isn't above the height of the texture
            {
                if (n == setWidth) { n = 0; nn++; } // if x = total width, set it to 0, increase y

                // create pixel meshes:

                var go = GameObject.CreatePrimitive(meshType); // create as quad
                Color mesh = go.GetComponent<Renderer>().material.color = cs; // set it's color
                go.AddComponent<pixelSurrogate_hatch>(); // add script to each mesh for AI behaviour
                go.transform.position = new Vector3(n, nn, transform.position.z); // put the quad in the same x/y as the texture
                destinationTexture.SetPixel(n, nn, cs); // set the textures pixel to mirror the texture
                go.GetComponent<Collider>().enabled = enableColliders; // set colliders on/of based on bool in inspector

                n++; // iterate x


            }

        }


        destinationTexture.Apply(); // apply the changes to the texture



    }



}




