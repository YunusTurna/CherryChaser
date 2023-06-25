using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    
   
   public TextMeshPro[] leaderBoard;

   
   public void Update()
   {
    
    if(Capusle.leaderBoardCounter == 1)
    {
        leaderBoard[Capusle.leaderBoardCounter-1].text = Capusle.placement;

    }
    if(Capusle.leaderBoardCounter == 2)
    {
        leaderBoard[Capusle.leaderBoardCounter-1].text = Capusle.placement;

    }
    if(Capusle.leaderBoardCounter == 3)
    {
        leaderBoard[Capusle.leaderBoardCounter-1].text = Capusle.placement;

    }
    if(Capusle.leaderBoardCounter == 4)
    {
        leaderBoard[Capusle.leaderBoardCounter-1].text = Capusle.placement;

    }
    if(Capusle.leaderBoardCounter == 5)
    {
        leaderBoard[Capusle.leaderBoardCounter-1].text = Capusle.placement;

    }
    
    }
    
}
    


