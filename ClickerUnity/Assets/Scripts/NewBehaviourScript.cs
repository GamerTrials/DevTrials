using UnityEngine;
using System.Collections;
using GTClicker;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    [SerializeField]
    Text textArea;

    [SerializeField]
    Text nextDevText;

    GameStudio gameStudio = new GameStudio(()=> new GameDevProject());
	// Use this for initialization
	void Start ()
    {
        nextDevText.text = "Adicionar Dev: $" + gameStudio.NextDevCost;
    }

    void PrintStatus() 
    {
        textArea.text = string.Format("${0} $/s: {1} #Developers: {2}", gameStudio.Money, 
            gameStudio.MoneyPerSecond, 
            gameStudio.MoneyPerSecond);
    }
    public void AdicionarDev() 
    {
        Debug.Log("bunda");
        gameStudio = gameStudio.AddDev (0);
        nextDevText.text = "Adicionar Dev: $" + gameStudio.NextDevCost;
    }

    public void DesenvolverJogo() 
    {
        Debug.Log("diacho");
        gameStudio = gameStudio.Click(0);
    }
	
	// Update is called once per frame
	void Update () {

        gameStudio = gameStudio.TimeLapse((long)(Time.deltaTime * 1000));
        PrintStatus();
    }
}
