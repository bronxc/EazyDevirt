﻿using AsmResolver.DotNet.Code.Cil;
using AsmResolver.DotNet.Serialized;
using AsmResolver.PE.DotNet.Cil;
using EazyDevirt.Core.Abstractions.Interfaces;
using EazyDevirt.Core.Architecture;

namespace EazyDevirt.PatternMatching.Patterns.OpCodes;

#region Clt

internal record CltInnerPattern : IPattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Ldarg_0,     // 63	00AA	ldarg.0
        CilOpCodes.Castclass,   // 64	00AB	castclass	VMDoubleOperand
        CilOpCodes.Callvirt,    // 65	00B0	callvirt	instance float64 VMDoubleOperand::method_3()
        CilOpCodes.Ldarg_1,     // 66	00B5	ldarg.1
        CilOpCodes.Castclass,   // 67	00B6	castclass	VMDoubleOperand
        CilOpCodes.Callvirt,    // 68	00BB	callvirt	instance float64 VMDoubleOperand::method_3()
        CilOpCodes.Clt,         // 69	00C0	clt
        CilOpCodes.Stloc_0,     // 70	00C2	stloc.0
    };

    public bool MatchEntireBody => false;
    
    public bool InterchangeStlocOpCodes => true;
}

internal record Clt : IOpCodePattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Call,        // 9	0011	call	bool VM::Clt_Inner(class VMOperandType, class VMOperandType)
        CilOpCodes.Brtrue_S,    // 10	0016	brtrue.s	13 (001B) ldc.i4.1 
        CilOpCodes.Ldc_I4_0,    // 11	0018	ldc.i4.0
        CilOpCodes.Br_S,        // 12	0019	br.s	14 (001C) newobj instance void VMIntOperand::.ctor(int32)
        CilOpCodes.Ldc_I4_1,    // 13	001B	ldc.i4.1
    };

    public CilOpCode? CilOpCode => CilOpCodes.Clt;

    public bool MatchEntireBody => false;

    public bool Verify(VMOpCode vmOpCode, int index = 0) => PatternMatcher.MatchesPattern(new CltInnerPattern(),
        (vmOpCode.SerializedDelegateMethod.CilMethodBody!.Instructions[index].Operand as SerializedMethodDefinition)!);
}
#endregion Clt

#region Clt_Un

internal record Clt_UnInnerPattern : IPattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Ldloc_2,     // 71	00C2	ldloc.2
        CilOpCodes.Ldloc_3,     // 72	00C3	ldloc.3
        CilOpCodes.Blt_S,       // 73	00C4	blt.s	80 (00D6) ldc.i4.1 
        CilOpCodes.Ldloc_2,     // 74	00C6	ldloc.2
        CilOpCodes.Call,        // 75	00C7	call	bool [mscorlib]System.Double::IsNaN(float64)
    };

    public bool MatchEntireBody => false;

    public bool InterchangeLdlocOpCodes => true;

    public bool Verify(CilInstructionCollection instructions, int index = 0) =>
        (instructions[index + 4].Operand as SerializedMemberReference)?.FullName ==
        "System.Boolean System.Double::IsNaN(System.Double)";
}

internal record Clt_Un : IOpCodePattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Call,        // 9	0011	call	bool VM::Clt_UnInner(class VMOperandType, class VMOperandType)
        CilOpCodes.Brtrue_S,    // 10	0016	brtrue.s	13 (001B) ldc.i4.1 
        CilOpCodes.Ldc_I4_0,    // 11	0018	ldc.i4.0
        CilOpCodes.Br_S,        // 12	0019	br.s	14 (001C) newobj instance void VMIntOperand::.ctor(int32)
        CilOpCodes.Ldc_I4_1,    // 13	001B	ldc.i4.1
    };

    public CilOpCode? CilOpCode => CilOpCodes.Clt_Un;

    public bool MatchEntireBody => false;

    public bool Verify(VMOpCode vmOpCode, int index = 0) => PatternMatcher.MatchesPattern(new Clt_UnInnerPattern(),
        (vmOpCode.SerializedDelegateMethod.CilMethodBody!.Instructions[index].Operand as SerializedMethodDefinition)!);
}
#endregion Clt

#region Cgt

internal record CgtInnerPattern : IPattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Ldarg_0,     // 97	0102	ldarg.0
        CilOpCodes.Castclass,   // 98	0103	castclass	VMIntOperand
        CilOpCodes.Callvirt,    // 99	0108	callvirt	instance int32 VMIntOperand::method_3()
        CilOpCodes.Ldarg_1,     // 100	010D	ldarg.1
        CilOpCodes.Castclass,   // 101	010E	castclass	VMIntOperand
        CilOpCodes.Callvirt,    // 102	0113	callvirt	instance int32 VMIntOperand::method_3()
        CilOpCodes.Cgt,         // 103	0118	cgt
        CilOpCodes.Stloc_0,     // 104	011A	stloc.0
    };

    public bool MatchEntireBody => false;
    
    public bool InterchangeStlocOpCodes => true;
}

internal record Cgt : IOpCodePattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Call,        // 9	0011	call	bool VM::CgtInner(class VMOperandType, class VMOperandType)
        CilOpCodes.Brtrue_S,    // 10	0016	brtrue.s	13 (001B) ldc.i4.1 
        CilOpCodes.Ldc_I4_0,    // 11	0018	ldc.i4.0
        CilOpCodes.Br_S,        // 12	0019	br.s	14 (001C) newobj instance void VMIntOperand::.ctor(int32)
        CilOpCodes.Ldc_I4_1,    // 13	001B	ldc.i4.1
    };

    public CilOpCode? CilOpCode => CilOpCodes.Cgt;

    public bool MatchEntireBody => false;

    public bool Verify(VMOpCode vmOpCode, int index = 0) => PatternMatcher.MatchesPattern(new CgtInnerPattern(),
        (vmOpCode.SerializedDelegateMethod.CilMethodBody!.Instructions[index].Operand as SerializedMethodDefinition)!);
}

#endregion Cgt

#region Cgt_Un

// this is a weird one, it's > for double, int, and long but != for other types
internal record Cgt_UnInnerPattern : IPattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Ldarg_0,     // 156	01ED	ldarg.0
        CilOpCodes.Castclass,   // 157	01EE	castclass	VMLongOperand
        CilOpCodes.Callvirt,    // 158	01F3	callvirt	instance int64 VMLongOperand::method_3()
        CilOpCodes.Ldarg_1,     // 159	01F8	ldarg.1
        CilOpCodes.Castclass,   // 160	01F9	castclass	VMLongOperand
        CilOpCodes.Callvirt,    // 161	01FE	callvirt	instance int64 VMLongOperand::method_3()
        CilOpCodes.Cgt_Un,      // 162	0203	cgt.un
        CilOpCodes.Stloc_0,     // 163	0205	stloc.0
    };

    public bool MatchEntireBody => false;
    
    public bool InterchangeStlocOpCodes => true;
}

internal record Cgt_Un : IOpCodePattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Call,        // 9	0011	call	bool VM::Cgt_UnInner(class VMOperandType, class VMOperandType)
        CilOpCodes.Brtrue_S,    // 10	0016	brtrue.s	13 (001B) ldc.i4.1 
        CilOpCodes.Ldc_I4_0,    // 11	0018	ldc.i4.0
        CilOpCodes.Br_S,        // 12	0019	br.s	14 (001C) newobj instance void VMIntOperand::.ctor(int32)
        CilOpCodes.Ldc_I4_1,    // 13	001B	ldc.i4.1
    };

    public CilOpCode? CilOpCode => CilOpCodes.Cgt_Un;

    public bool MatchEntireBody => false;

    public bool Verify(VMOpCode vmOpCode, int index = 0) => PatternMatcher.MatchesPattern(new Cgt_UnInnerPattern(),
        (vmOpCode.SerializedDelegateMethod.CilMethodBody!.Instructions[index].Operand as SerializedMethodDefinition)!);
}

#endregion Cgt

#region Ceq

internal record CeqInnerPattern : IPattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Ldarg_0,     // 283	03CC	ldarg.0
        CilOpCodes.Callvirt,    // 284	03CD	callvirt	instance object VMOperandType::GetOperandValue()
        CilOpCodes.Ldarg_1,     // 285	03D2	ldarg.1
        CilOpCodes.Callvirt,    // 286	03D3	callvirt	instance object VMOperandType::GetOperandValue()
        CilOpCodes.Ceq,         // 287	03D8	ceq
        CilOpCodes.Stloc_0,     // 288	03DA	stloc.0
    };

    public bool MatchEntireBody => false;
    
    public bool InterchangeStlocOpCodes => true;

    public bool Verify(CilInstructionCollection instructions, int index = 0) =>
        instructions.Any(x => x.OpCode == CilOpCodes.Call && x.Operand is SerializedMemberReference
        {
            FullName: "System.Boolean System.Double::IsNaN(System.Double)"
        });
}

internal record Ceq : IOpCodePattern
{
    public IList<CilOpCode> Pattern => new List<CilOpCode>
    {
        CilOpCodes.Call,        // 11	0017	call	bool VM::CeqInner(class VMOperandType, class VMOperandType)
        CilOpCodes.Brtrue_S,    // 12	001C	brtrue.s	15 (0021) ldc.i4.1 
        CilOpCodes.Ldc_I4_0,    // 13	001E	ldc.i4.0
        CilOpCodes.Br_S,        // 14	001F	br.s	16 (0022) callvirt instance void VMIntOperand::method_4(int32)
        CilOpCodes.Ldc_I4_1,    // 15	0021	ldc.i4.1
    };

    public CilOpCode? CilOpCode => CilOpCodes.Ceq;

    public bool MatchEntireBody => false;

    public bool Verify(VMOpCode vmOpCode, int index = 0) => PatternMatcher.MatchesPattern(new CeqInnerPattern(),
        (vmOpCode.SerializedDelegateMethod.CilMethodBody!.Instructions[index].Operand as SerializedMethodDefinition)!);
}
#endregion Ceq