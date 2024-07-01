using Emu6502.Enums.Emulator;
using Emu6502.Models.Emulator;

namespace Emu6502.Interfaces.Emulator;

public interface IInstruction
{
    void Execute(ref EmulatorMemory emulatorMemory, ref EmulatorFlags emulatorFlags);

    AddressingModeEnum AddressingMode { get; init; }
    byte InstructionHexadecimal { get; init; }
    int InstructionLength { get; init; }
    int InstructionCycles { get; init; }
}