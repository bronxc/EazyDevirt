﻿using System.Security.Cryptography;
using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Metadata.Tables;
using EazyDevirt.Architecture;
using EazyDevirt.Core.IO;
using EazyDevirt.Devirtualization.Options;
using EazyDevirt.Logging;
using EazyDevirt.PatternMatching;

namespace EazyDevirt.Devirtualization;

internal record DevirtualizationContext
{
    public DevirtualizationContext(DevirtualizationOptions opts)
    {
        Options = opts;
        Module = ModuleDefinition.FromFile(Options!.Assembly.FullName);
        PatternMatcher = new PatternMatcher();
        Console = new ConsoleLogger();
    }
    
    public DevirtualizationOptions Options { get; }
    public ModuleDefinition Module { get; }
    public PatternMatcher PatternMatcher { get; }
    public ConsoleLogger Console { get; }
    
    public MetadataToken VMResourceGetterMdToken { get; set; }
    public VMStream VMStream { get; set; }
    public int PositionCryptoKey { get; set; }
    public int MethodCryptoKey { get; set; }
    
    public List<VMMethod> VMMethods { get; set; }
}