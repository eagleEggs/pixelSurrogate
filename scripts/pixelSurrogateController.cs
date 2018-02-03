using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class pixelSurrogateController : MonoBehaviour
{

    [ExecuteInEditMode]

    [SerializeField]
    private Texture2D sourceTex; // source texture to copy
    [SerializeField] private Rect sourceRect; // rect reference that sets dimensions to read source
    [SerializeField] private int setWidth; // width of texture
    [SerializeField] private int setHeight; // height of teture
    private Texture2D destTex2; // destination texture to write
    private Color[] destPix; // destination texture pixel array


    void Start()
    {



    }



    public void hatchemall()
    {


        List<Color> colorsFinal = new List<Color>(); // color list

        // all x and y of the texture to iterate
        int x = Mathf.FloorToInt(sourceRect.x);
        int y = Mathf.FloorToInt(sourceRect.y);
        int width = Mathf.FloorToInt(sourceRect.width);
        int height = Mathf.FloorToInt(sourceRect.height);

        Color[] pix = sourceTex.GetPixels(x, y, width, height); // get the source texture pixels into the array

        destTex2 = new Texture2D(width, height); // set the dimensions of teh output texture, must be equal to source

        int n = 0; // x iteration
        int nn = 0; // y iteration

        foreach (Color cs in pix) // for each color in the color array from source texture
        {

            if (nn <= setHeight) // if y isn't above the height of the texture
            {
                if (n == setWidth) { n = 0; nn++; } // if x = total width, set it to 0, increase y

                colorsFinal.Add(cs); // add the color from the source to to list

                // create quads:
                var go = GameObject.CreatePrimitive(PrimitiveType.Quad); // create
                Color mesh = go.GetComponent<Renderer>().material.color = cs; // set it's color
                go.AddComponent<pixelSurrogate_hatch>(); // add script to each mesh for AI behaviour
                go.transform.position = new Vector3(n, nn, transform.position.z); // put the quad in the same x/y as the texture
                destTex2.SetPixel(n, nn, cs); // set the textures pixel to mirror the texture
                Destroy(go.GetComponent<Collider>());

                n++; // iterate x


            }

        }


        destTex2.Apply(); // apply the changes to the texture



    }



}




