using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour {

    public GameObject circuloExterno;
    public GameObject circuloInterno;
    public Text timer;
    public GameObject timerObject;
    public GameObject confirmButton;
    public GameObject gameOverText;
    public GameObject zerouJogo;
    public GameObject tryAgain;
    public float timerfloat;
    public bool encostou;
    public int fase;
    public bool iniciouFase;
    public Text countdown;
    public Button touchscreenButton;
    public Button confirmButtonEnabled;
    public float ContRegressiva;
    public bool telaInicial;
    public GameObject tyf;
    public GameObject playButton;
    public bool zerado;
    public GameObject shareOnFacebook;
    public GameObject shareOnTwitter;
    public GameObject tutorial;
    // Use this for initialization
    void Start () {
        tutorial.SetActive(false);
        shareOnFacebook.SetActive(false);
        shareOnTwitter.SetActive(false);
        telaInicial = true;
        gameOverText.SetActive(false);
        zerouJogo.SetActive(false);
        tryAgain.SetActive(false);
        fase = 1;
        encostou = false;
        zerado = false;
        timerfloat = 10;
        timer.text = timerfloat.ToString();
        iniciouFase = false;
        ContRegressiva = 0;        
    }

    public void touchscreen()
    {
        circuloExterno.transform.localScale -= new Vector3(0.13F, 0.13F, 0);
        if(circuloExterno.transform.localScale.x <= 0)
        {
            circuloExterno.transform.localScale = new Vector3(0F, 0F, 0);
        }
    }

    public void confirm()
    {
        if (encostou == true)
        {
            countdown.enabled = true;
            timerfloat = 10;
            iniciouFase = false;
            ContRegressiva = 0;
            confirmButton.SetActive(false);
            touchscreenButton.enabled = false;
            tutorial.SetActive(false);
            circuloExterno.transform.localScale = new Vector3(0.9f, 0.9f, 0);

            passouFase();
        }
        if (encostou == false)
        {
            gameOver();
        }
    }

    public void passouFase()
    {        
        if(fase == 1)
        {
            fase += 1;
            circuloInterno.transform.localScale = new Vector3(0.7f, 0.7f, 0);
        }else if (fase == 2)
        {
            fase += 1;
            circuloInterno.transform.localScale = new Vector3(0.6f, 0.6f, 0);
        } else if (fase == 3)
        {
            fase += 1;
            circuloInterno.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        } else if (fase == 4)
        {
            fase += 1;
            circuloInterno.transform.localScale = new Vector3(0.4f, 0.4f, 0);
        } else if (fase == 5)
        {
            fase += 1;
            circuloInterno.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        }
        else if (fase == 6)
        {
            fase += 1;
            circuloInterno.transform.localScale = new Vector3(0.2f, 0.2f, 0);
        }
        else if (fase == 7)
        {
            zerado = true;
            timerfloat = 999;
            circuloExterno.SetActive(false);
            circuloInterno.SetActive(false);
            confirmButton.SetActive(false);
            zerouJogo.SetActive(true);
            tryAgain.SetActive(true);
            shareOnFacebook.SetActive(true);
            shareOnTwitter.SetActive(true);
        }
    }

    void cresceCirculo()
    {
        circuloExterno.transform.localScale += new Vector3(0.02F, 0.02F, 0);

        if(circuloExterno.transform.localScale.x >= 0.9)
        {
            circuloExterno.transform.localScale = new Vector3(0.9f, 0.9f, 0);
        }
    }

    public void gameOver()
    {
        iniciouFase = false;
        timerfloat = 0;
        tutorial.SetActive(false);
        circuloExterno.SetActive(false);
        circuloInterno.SetActive(false);
        confirmButton.SetActive(false);
        gameOverText.SetActive(true);
        tryAgain.SetActive(true);
        shareOnFacebook.SetActive(true);
        shareOnTwitter.SetActive(true);
    }

    public void tryAgainButton()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void contagemRegressiva()
    {
        ContRegressiva += Time.deltaTime;

        if (ContRegressiva >= 0 && ContRegressiva < 1)
        {
            countdown.text = "3";
        }
        else if (ContRegressiva > 1 && ContRegressiva < 2)
        {
            countdown.text = "2";
        }
        else if (ContRegressiva > 2 && ContRegressiva < 3)
        {
            countdown.text = "1";
        }
        else if (ContRegressiva > 3 && ContRegressiva < 4)
        {
            countdown.text = "Go!";
        }
        else if (ContRegressiva > 5)
        {            
            iniciouFase = true;
            touchscreenButton.enabled = true;
            confirmButtonEnabled.enabled = true;
            countdown.enabled = false;
            tutorial.SetActive(true);
            if (zerado == false) { confirmButton.SetActive(true); }
            
        }
    }

    public void iniciaJogo()
    {
        telaInicial = false;
        tyf.SetActive(false);
        playButton.SetActive(false);
        timerObject.SetActive(true);        
    }

    public void mostraTelaInicial()
    {
        timerObject.SetActive(false);
        confirmButton.SetActive(false);
        tyf.SetActive(true);
        playButton.SetActive(true);
        touchscreenButton.enabled = false;
        confirmButtonEnabled.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(telaInicial == true)
        {
            mostraTelaInicial();
        }

        if(iniciouFase == false && telaInicial == false)
        {            
            contagemRegressiva();
        }        

        if (iniciouFase == true && telaInicial == false)
        {
            cresceCirculo();

            timerfloat -= Time.deltaTime;
            timer.text = timerfloat.ToString("F2");

            if (timerfloat <= 0)
            {                
                gameOver();
            }
        }
        
    }
}
