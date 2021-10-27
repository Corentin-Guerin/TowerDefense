
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; } = null ;

    public Text _timerText = null ;
    public Text timerText { get { return _timerText; } set {_timerText = value ; }}

    
    private void Awake()
    {
        instance = this ;
    }

    
    private void Update()
    {
        
    }

    public void SetTimer(float time)
    {
        timerText.text = "Timer: " + time.ToString("F1") ;       //F+nombre de chiffre apres la ,
    }
}
