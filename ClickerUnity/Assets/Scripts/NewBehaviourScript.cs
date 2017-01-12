using UnityEngine;
using System.Collections;
using GTClicker;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    [SerializeField]
    Text textArea;

    [SerializeField]
    Text nextDevText;

	[SerializeField]
	Text nextGameValue;

	[SerializeField]
	Text nextGameFeaturesPerSec;


	GameDevCompany company = new GameDevCompany(new MarketPlace(),new GameStudio(()=> new GameDevProject()));

	void Start ()
    {
		nextDevText.text = "Adicionar Dev: $" + company.NextDevCost;
    }

    void PrintStatus() 
    {
		textArea.text = string.Format("${0}  #Free Developers: {1}", company.Money, company.FreeDevs);

		nextGameValue.text = company.GetProject (0).FeaturesGenerated.ToString();
		nextGameFeaturesPerSec.text = company.GetProject (0).FeaturesGeneratedPerSec.ToString();
    }

    public void AdicionarDev() 
    {
		company.HireDev ();
		nextDevText.text = "Adicionar Dev: $" + company.NextDevCost.ToString();
    }

	public void AddDevToGame(int index)
	{
		company.AssociateADev (index);
	}

	public void SellGame(int index)
	{
		company.SellGame (index);
	}

    public void DesenvolverJogo() 
    {
		company.HelpDevGame (0);
   	}

	// Update is called once per frame
	void Update () {

		company.TimeLapse((long)(Time.deltaTime * 1000));
        PrintStatus();
    }
}
