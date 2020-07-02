using System;
using System.Collections.Generic;
using TowerDefense.Game;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense.UI
{
	/// <summary>
	/// UI object to display final score
	/// </summary>
	public class ScorePanel : MonoBehaviour
	{
		/// <summary>
		/// Objects that represent the stars
		/// </summary>
		public Image[] starImages;

		public Sprite achievedStarSprite;
        public Text timeTakenText;
        public List<Text> bestTimeListText;
        public List<float> bestTimeList;
		/// <summary>
		/// Show the correct number of stars for the score
		/// </summary>
		/// <param name="score">The final score</param>
		public void SetStars(int score,string resultText)
		{
            //We will disable the 5 Best Time list and Time Taken if Level Failed
            bestTimeListText[0].transform.parent.gameObject.SetActive(false);
            if (resultText.Contains("FAILED"))
            {
                timeTakenText.gameObject.SetActive(false);
               
            }
			if (score <= 0)
			{
				return;
			}
            //Minus Current time from Start time to get actual time
            float timeTaken =Time.time-GameManager.instance.startTime;
            //Saving to PlayerPref in ordet to show in 5 Best Time 
            string currentLevel = Application.loadedLevelName;
            GameData.SetBestTimeMaxCountAdded(GameData.GetBestTimeMaxCount(currentLevel) + 1, currentLevel);
            GameData.SetBestTime(GameData.GetBestTimeMaxCount(currentLevel), currentLevel, timeTaken);
            int min = Mathf.FloorToInt(timeTaken / 60);
            int sec = Mathf.FloorToInt(timeTaken % 60);
            timeTakenText.text = "Time Taken: " + string.Format("{0:00}:{1:00}", min, sec);
            score = Mathf.Clamp(score, 0, starImages.Length);
			for (int i = 0; i < score; i++)
			{
				starImages[i].sprite = achievedStarSprite;
			}
            bestTimeList.Clear();
            //We will check through the PlayerPref using For loop with count and store in a list 
            for(int i=1;i<=GameData.GetBestTimeMaxCount(currentLevel);i++)
            {
                if(GameData.GetBestTime(i,currentLevel)>0)
                {
                    bestTimeList.Add(GameData.GetBestTime(i,currentLevel));
                }
            }
            bestTimeList.Sort();
            //Displaying the Best Time using For loop with length bestTimeListText count
            //We will only show when its greater then 1
            if (bestTimeList.Count > 1)
            {
                bestTimeListText[0].transform.parent.gameObject.SetActive(true);
            }
            for (int i=0;i< bestTimeListText.Count;i++)
            {
                if (i < bestTimeList.Count)
                {
                     min = Mathf.FloorToInt(bestTimeList[i] / 60);
                     sec = Mathf.FloorToInt(bestTimeList[i] % 60);

                    bestTimeListText[i].text =  string.Format("{0:00}:{1:00}", min, sec); 
                    bestTimeListText[i].gameObject.SetActive(true);
                }
            }
		}
	}
    
}