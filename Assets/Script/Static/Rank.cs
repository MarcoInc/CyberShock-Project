using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rank {

	public static void insertPoint(int point, string name){
		const int DIM  =  5;
		int i = 0;
		while(point < SaveGame.GetRankPoints(i) && i < DIM){
			i++;
		}
		if(i == DIM){
			if(point > SaveGame.GetRankPoints(i))
			{
				SaveGame.SaveRankPoints(i, point);
				SaveGame.SaveRankNames(i,name);
			}
		}
		else{
			for(int j = DIM - 1; j > i; j--){
				SaveGame.SaveRankPoints(j, SaveGame.GetRankPoints(j - 1));
				SaveGame.SaveRankNames(j, SaveGame.GetRankNames(j - 1));
			}
			SaveGame.SaveRankPoints(i, point);
			SaveGame.SaveRankNames(i, name);
		}
	}
}
