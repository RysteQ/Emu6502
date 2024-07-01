using Emu6502.Enums.Emulator;
using Emu6502.Interfaces.Emulator;

namespace Emu6502.Models.Emulator.Instructions;

public class CldInstruction : IInstruction
{
    public void Execute(ref EmulatorMemory emulatorMemory, ref EmulatorFlags emulatorFlags)
    {
        throw new NotImplementedException();
    }

    public AddressingModeEnum AddressingMode { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    public byte InstructionHexadecimal { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    public int InstructionLength { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    public int InstructionCycles { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
}