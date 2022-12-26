﻿using EazyDevirt.Abstractions;
using EazyDevirt.Devirtualization.Pipeline;

namespace EazyDevirt.Devirtualization;

internal class Devirtualizer
{
    public Devirtualizer(DevirtualizationContext ctx)
    {
        Context = ctx;
        Pipeline = new List<Stage>
        {
            new ResourceParsing(ctx),
            // TODO: add binaryreader and field order matching stage
            // TODO: add opcode mapping stage
            new MethodDiscovery(ctx),
            new MethodDisassembler(ctx),
        };
    }
    
    private DevirtualizationContext Context { get; }
    private List<Stage> Pipeline { get; }

    public void Run()
    {
        foreach (var stage in Pipeline)
        {
            Context.Console.Info($"Executing {stage.Name}...");
            if (!stage.Run())
                Context.Console.Error($"Failed executing {stage.Name}!");
            else
                Context.Console.Success($"Executed {stage.Name}!");
        }
    }
}