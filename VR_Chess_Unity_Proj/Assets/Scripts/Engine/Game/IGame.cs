using UnityEngine;
using UnityEditor;
namespace ChessGame.Engine.Game
{
    public interface IGame
    {
        void Init();
        void PlayerSwap();
        void TogglePlayerCheck(Player player);
    }
}