using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;
using KModkit;

public class IntegerTrees : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable[] WeedEaters;
    public TextMesh[] Weeds;
    public KMSelectable chungus;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    int yes = 0;
    int fuck = 0;
    int silvena = 0;
    int gofuckyourself = 0;
    int integer = 0;
    private List<int> weed1 = new List<int>{};
    private List<int> weed2 = new List<int>{};
	string lamo = "";
    int originalYes = 0;
    int originalFuck = 0;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable WeedEater in WeedEaters) {
           WeedEater.OnInteract += delegate () { WeedEaterPress(WeedEater); return false; };
          }
          chungus.OnInteract += delegate () { PressChungus(); return false; };
    }

    void Start () {
    StartAllOverDumbass:
	  lamo = "";
      weed1.Clear();
      weed2.Clear();
      originalYes = UnityEngine.Random.Range(5,201);
      originalFuck = UnityEngine.Random.Range(5,201);
      yes = originalYes;
      fuck = originalFuck;
      gofuckyourself = 0;
      weed1.Add(yes);
      weed2.Add(fuck);
      Weeds[0].text = yes.ToString();
      Weeds[1].text = fuck.ToString();
      Weeds[2].text = "0";
      PenisMeasurer();
      PenisMeasurerTwo();
      for (int i = 0; i < weed1.Count(); i++) {
        for (int j = 0; j < weed2.Count(); j++) {
          if (weed1[i] == weed2[j] && weed1[i] > gofuckyourself) {
            gofuckyourself = weed1[i];
          }
        }
      }
      integer = weed1.Count() + weed2.Count();
      if (integer > 20) {
          goto StartAllOverDumbass;
      }
      Debug.LogFormat("[Integer Trees #{0}] The top number is {1} and the bottom one is {2}.", moduleId, originalYes, originalFuck);
      Debug.LogFormat("[Integer Trees #{0}] The highest shared value is {1}", moduleId, gofuckyourself);
      gofuckyourself *= integer;
      gofuckyourself %= 100000;
      Debug.LogFormat("[Integer Trees #{0}] The amount of steps are {1}", moduleId, integer);
      Debug.LogFormat("[Integer Trees #{0}] Multiplying the highest shared value and the amount of rows in the tree gives {1}.", moduleId, gofuckyourself);
      Debug.LogFormat("[Integer Trees #{0}] {1}", moduleId, lamo);
	}
  void WeedEaterPress(KMSelectable WeedEater){
    WeedEater.AddInteractionPunch();
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, WeedEater.transform);
    for (int i = 0; i < 8; i++) {
      if (WeedEater == WeedEaters[i]) {
        if (i == 0) {
          silvena += 1000;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 1) {
          if (silvena < 1000) {
            return;
          }
          silvena -= 1000;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 2) {
          silvena += 100;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 3) {
          if (silvena < 100) {
            return;
          }
          silvena -= 100;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 4) {
          silvena += 10;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 5) {
          if (silvena < 10) {
            return;
          }
          silvena -= 10;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 6) {
          silvena += 1;
          Weeds[2].text = silvena.ToString();
        }
        else if (i == 7) {
          if (silvena < 1) {
            return;
          }
          silvena -= 1;
          Weeds[2].text = silvena.ToString();
        }
    }
  }
}
  void PenisMeasurer(){
    Something:
    if (yes % 2 == 0) {
      yes /= 2;
      weed1.Add(yes);
      lamo = lamo + "The top number is even, dividing by 2 gives you " + yes + "\n";
    }
    else {
      yes *= 3;
      yes += 1;
      weed1.Add(yes);
      lamo = lamo + "The top number is odd, multiplying by 3 and adding 1 gives " + yes + "\n";
    }
    if (yes == 1) {
      return;
    }
    else {
      goto Something;
    }
  }
  void PenisMeasurerTwo(){
    Somethingelse:
    if (fuck % 2 == 0) {
      fuck /= 2;
      weed2.Add(fuck);
      lamo = lamo + "The bottom number is even, dividing by 2 gives you " + fuck + "\n";
    }
    else {
      fuck *= 3;
      fuck += 1;
      weed2.Add(fuck);
      lamo = lamo + "The bottom number is odd, multiplying by 3 and adding 1 gives " + fuck + "\n";
    }
    if (fuck == 1) {
      return;
   }
  else {
    goto Somethingelse;
  }
 }
void PressChungus()
{
	chungus.AddInteractionPunch();
    GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, chungus.transform);
	if (silvena == gofuckyourself)
	{
		Debug.LogFormat("[Integer Trees #{0}] You submitted {1}. Module disarmed.", moduleId, silvena);
		GetComponent<KMBombModule>().HandlePass();
	}
	
    else
    {
		Debug.LogFormat("[Integer Trees #{0}] You submitted {1}. You should have submitted {2}.", moduleId, silvena, gofuckyourself);
		silvena = 0;
		Weeds[2].text = silvena.ToString();
		GetComponent<KMBombModule>().HandleStrike();
    }
}
 
	//twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} submit [0-9999] to submit your answer";
    #pragma warning restore 414
	
	IEnumerator ProcessTwitchCommand(string command)
	{
		string[] parameters = command.Split(' ');
		if (Regex.IsMatch(parameters[0], @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
			yield return null;
			if (parameters.Length != 2)
			{
				yield return "sendtochaterror Invalid parameter length. The command was not processed.";
				yield break;
			}
			
			int Out;
			if (!Int32.TryParse(parameters[1], out Out))
			{
				yield return "sendtochaterror Invalid number. The command was not processed.";
				yield break;
			}
			
			if (Out < 0 || Out > 9999)
			{
				yield return "sendtochaterror The number is not between 0-9999. The command was not processed.";
				yield break;
			}
			
			for (int x = 0; x < parameters[1].Length; x++)
			{
				if (Weeds[2].text == parameters[1])
				{
					break;
				}
				
				else if (parameters[1][parameters[1].Length - 1 - x].ToString() == "0")
				{
					continue;
				}
				
				else
				{
					WeedEaters[((3 - x) * 2)].OnInteract();
					while (Weeds[2].text[0].ToString() != parameters[1][parameters[1].Length - 1 - x].ToString())
					{
						WeedEaters[((3 - x) * 2)].OnInteract();
						yield return new WaitForSecondsRealtime(0.05f);
					}
				}
			}
			chungus.OnInteract();
		}
	}
}