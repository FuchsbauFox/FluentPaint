﻿using FluentPaint.Core.Enums;
using SkiaSharp;

namespace FluentPaint.Core.Channels.Implementations;

public class ChannelGetter : IChannelGetter
{
    public SKBitmap GetChannels(SKBitmap bitmap, ColorChannels channels)
    {
        var modifiedBitmap = new SKBitmap(bitmap.Width, bitmap.Height);

        const byte defaultValue = 0;

        switch (channels)
        {
            case ColorChannels.First:
                for (var y = 0; y < bitmap.Height; y++)
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var currentPixel = bitmap.GetPixel(x, y);

                        modifiedBitmap
                            .SetPixel(x, y, new SKColor(currentPixel.Red, defaultValue, defaultValue));
                    }
                }

                break;
            case ColorChannels.Second:
                for (var y = 0; y < bitmap.Height; y++)
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var currentPixel = bitmap.GetPixel(x, y);

                        modifiedBitmap
                            .SetPixel(x, y, new SKColor(defaultValue, currentPixel.Green, defaultValue));
                    }
                }

                break;
            case ColorChannels.Third:
                for (var y = 0; y < bitmap.Height; y++)
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var currentPixel = bitmap.GetPixel(x, y);

                        modifiedBitmap
                            .SetPixel(x, y, new SKColor(defaultValue, defaultValue, currentPixel.Blue));
                    }
                }

                break;
            case ColorChannels.FirstAndSecond:
                for (var y = 0; y < bitmap.Height; y++)
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var currentPixel = bitmap.GetPixel(x, y);

                        modifiedBitmap
                            .SetPixel(x, y, new SKColor(currentPixel.Red, currentPixel.Green, defaultValue));
                    }
                }

                break;
            case ColorChannels.FirstAndThird:
                for (var y = 0; y < bitmap.Height; y++)
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var currentPixel = bitmap.GetPixel(x, y);

                        modifiedBitmap
                            .SetPixel(x, y, new SKColor(currentPixel.Red, defaultValue, currentPixel.Blue));
                    }
                }

                break;
            case ColorChannels.SecondAndThird:
                for (var y = 0; y < bitmap.Height; y++)
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var currentPixel = bitmap.GetPixel(x, y);

                        modifiedBitmap
                            .SetPixel(x, y, new SKColor(defaultValue, currentPixel.Green, currentPixel.Blue));
                    }
                }

                break;
            case ColorChannels.All:
                for (var y = 0; y < bitmap.Height; y++)
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var currentPixel = bitmap.GetPixel(x, y);

                        modifiedBitmap
                            .SetPixel(x, y, new SKColor(currentPixel.Red, currentPixel.Green, currentPixel.Blue));
                    }
                }

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(channels), channels, null);
        }

        return modifiedBitmap;
    }
}