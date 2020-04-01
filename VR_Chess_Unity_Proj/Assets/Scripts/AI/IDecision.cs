using UnityEngine;
using UnityEditor;
using ChessGame.Engine.Misc;

namespace ChessGame.AI
{
    public interface IDecision
    {
         Move Move();

         double Score();
    }
}