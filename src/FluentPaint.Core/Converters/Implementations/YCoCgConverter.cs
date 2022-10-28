using SkiaSharp;

namespace FluentPaint.Core.Converters.Implementations;

public class YCoCgConverter : IConverter
{
    public SKBitmap FromRgb(SKBitmap bitmap)
    {
        var convertedBitmap = new SKBitmap(bitmap.Width, bitmap.Height);

        for (var y = 0; y < bitmap.Height; y++)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                var pixel = bitmap.GetPixel(x, y);

                double red = pixel.Red;
                double green = pixel.Green;
                double blue = pixel.Blue;

                var luma = 0.25 * red + 0.5 * green + 0.25 * blue;
                var chrominanceOrange = 0.5 * red - 0.5 * blue;
                var chrominanceGreen = -0.25 * red + 0.5 * green - 0.25 * blue;

                convertedBitmap.SetPixel(x, y,
                    new SKColor((byte) luma, (byte) (128 + chrominanceOrange), (byte) (128 + chrominanceGreen)));
            }
        }

        return convertedBitmap;
    }

    public SKBitmap ToRgb(SKBitmap bitmap)
    {
        var convertedBitmap = new SKBitmap(bitmap.Width, bitmap.Height);

        for (var y = 0; y < bitmap.Height; y++)
        {
            for (var x = 0; x < bitmap.Width; x++)
            {
                var pixel = bitmap.GetPixel(x, y);

                double luma = pixel.Red;
                double chrominanceOrange = pixel.Green - 128;
                double chrominanceGreen = pixel.Blue - 128;

                var red = luma + chrominanceOrange - chrominanceGreen;
                var green = luma + chrominanceGreen;
                var blue = luma - chrominanceOrange - chrominanceGreen;

                if (red < 0)
                {
                    red = 0;
                }

                if (green < 0)
                {
                    green = 0;
                }

                if (blue < 0)
                {
                    blue = 0;
                }

                convertedBitmap.SetPixel(x, y, new SKColor((byte) red, (byte) green, (byte) blue));
            }
        }

        return convertedBitmap;
    }
}