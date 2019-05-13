using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CirculoInterno : MonoBehaviour {

    public SpriteRenderer circuloExterno;
    public Gameplay gameplay;
    public Text tutorial;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("circulo"))
        {
            tutorial.text = "Press\n Confirm!";
            gameplay.encostou = true;
            circuloExterno.color = new Color(0f, 1f, 0f, 1f);
        }        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("circulo"))
        {
            tutorial.text = "Tap the\nScreen!";
            gameplay.encostou = false;
            circuloExterno.color = new Color(1f, 1f, 1f, 1f);
        }
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
