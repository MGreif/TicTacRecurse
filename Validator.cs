
using System;
using UnityEngine;
public interface IValidator
{
    bool Validate(int gameId, int id, int value);
}
public abstract class Validator : IValidator
{
    public abstract bool Validate(int gameId, int id, int value);
}

public class GameFinishedValidator : IValidator
{
    private bool gameFinished = false;
    public GameFinishedValidator(bool gameFinished)
    {
        this.gameFinished = gameFinished;
    }
    public bool Validate(int gameId, int id, int value)
    {
        return !this.gameFinished;
    }
}
public class ActiveGameValidator : IValidator
{
    private int activeGame = 0;
    public ActiveGameValidator(int activeGame) {
            this.activeGame = activeGame;
    }
    public bool Validate(int gameId, int id, int value)
    {
        if (activeGame == -1) return true;
        return gameId == activeGame;
    }
}

public class ComplexGameStateValidator : Validator
{
    Func<int, int, int, bool> validationFunc;
    public ComplexGameStateValidator(Func<int, int, int, bool> validationFunc)
    {
        this.validationFunc = validationFunc;
    }
    public override bool Validate(int gameid, int id, int value)
    {

        return validationFunc(gameid, id, value);
    }
}