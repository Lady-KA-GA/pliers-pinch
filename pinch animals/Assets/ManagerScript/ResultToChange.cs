using UnityEngine;
using System.Collections;

public class ResultToChange : MonoBehaviour 
{

	public void PoseDeactive() 
	{
		Time.timeScale = 0;
		gameover.overCheck = false;
	}
}
