namespace Emu6502.Enums.Emulator;

public enum AddressingModeEnum
{
    IMPLICIT,
    ACCUMULATOR,
    ZERO_PAGE,
    ZERO_PAGE_Y,
    ZERO_PAGE_X,
    RELATIVE,
    ABSOLUTE,
    ABSOLUTE_X,
    ABSOLUTE_Y,
    INDIRECT,
    INDEXED_INDIRECT,
    INDIRECT_INDEXED
}