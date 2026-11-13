using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GameOver", story: "Game is [over]", category: "Action", id: "2d9c8cb62cca8407728b610998f0c223")]
public partial class GameOverAction : Action
{
    [SerializeReference] public BlackboardVariable<Game_Over_Scripts> Over;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

