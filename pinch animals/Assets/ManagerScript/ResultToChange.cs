using UnityEngine;
using System.Collections;

public class ResultToChange : MonoBehaviour 
{

	public void PoseDeactive() 
	{
		Time.timeScale = 1;
		gameover.overCheck = false;
	}
}
