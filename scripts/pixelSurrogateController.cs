using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class pixelSurrogateController : MonoBehaviour
{

    [ExecuteInEditMode]

    [SerializeField]
    private Texture2D sourceTex;
    public Texture2D destTex2;
    private Color[] destPix;
    public Rect sourceRect;
    private float csColorTotal;
    [SerializeField] private int setWidth;
    [SerializeField] private float setHeight;


    void Start()
    {


    }


    public void hatchemall()
    {


        List<Color> colrs = new List<Color>();
        List<Color> colorArray = new List<Color>();
        List<float> colorSort = new List<float>();
        Dictionary<float, Color> myColors = new Dictionary<float, Color>();
        Dictionary<float, Color> myColors2 = new Dictionary<float, Color>();
        List<Color> colorsFinal = new List<Color>();

        int x = Mathf.FloorToInt(sourceRect.x);
        int y = Mathf.FloorToInt(sourceRect.y);
        int width = Mathf.FloorToInt(sourceRect.width);
        int height = Mathf.FloorToInt(sourceRect.height);

        Color[] pix = sourceTex.GetPixels(x, y, width, height);

        destTex2 = new Texture2D(width, height);

        int n = 0;
        int nn = 0;

        string cnum = n.ToString();
        foreach (Color cs in pix)
        {

            if (nn <= setHeight)
            {
                if (n == setWidth) { n = 0; nn++; }

                float csr = cs.r;
                float csg = cs.g;
                float csb = cs.b;
                float csa = cs.a;
                csColorTotal = csr + csg + csb + csa / 4f;

                colorsFinal.Add(cs);
                var go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                Color mesh = go.GetComponent<Renderer>().material.color = cs;
                go.AddComponent<pixelSurrogate_hatch>();
                go.transform.position = new Vector3(n, nn, 0);
                destTex2.SetPixel(n, nn, cs);

                Debug.Log("adding");
                Debug.Log(n);
                n++;


            }

        }


        destTex2.Apply();



    }


    void Update()
    {



    }



}
