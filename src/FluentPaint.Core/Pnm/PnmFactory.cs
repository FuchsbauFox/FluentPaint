using FluentPaint.Core.Reader;
using FluentPaint.Core.Reader.Implementations;
using FluentPaint.Core.Writer;
using FluentPaint.Core.Writer.Implementations;

namespace FluentPaint.Core.Pnm;

public static class PnmFactory
{
    public static PnmType GetPnmType(string line)
    {
        return line.Equals("P5") ? PnmType.P5 : PnmType.P6;
    }

    public static IPnmWriter GetPnmWriter(PnmType type)
    {
        IPnmWriter writer = type switch
        {
            PnmType.P5 => new PgmWriter(),
            PnmType.P6 => new PpmWriter(),
            _ => throw new ArgumentException("Error: This file type is not supported, .ppm .pgm is expected")
        };

        return writer;
    }


    public static IPnmReader GetPnmReader(PnmType type)
    {
        IPnmReader reader = type switch
        {
            PnmType.P5 => new PgmReader(),
            PnmType.P6 => new PpmReader(),
            _ => throw new ArgumentException("Error: This file type is not supported, .ppm .pgm is expected")
        };

        return reader;
    }
}