using Script;
using UnityEngine;

namespace MiniGames
{
    public class TestMiniGame : MiniGameManager
    {
        protected override void EndGame()
        {
            Debug.Log(isCleared);
            if (isCleared) GameManager.ClearMiniGame();
            else GameManager.FailMiniGame();
        }
    }
}
