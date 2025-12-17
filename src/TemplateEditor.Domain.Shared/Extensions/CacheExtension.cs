using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace TemplateEditor.Extensions;

public static class CacheExtension
{
    public static string GenerateCacheKeyToCount(
        CultureInfo cultureInfo,
        Guid? tenantId,
        Guid? currentUserId,
        string? listName
    )
    {
        return
            $"TemplateEditor:{cultureInfo}:{tenantId}:{currentUserId}:{listName}_count";
    }

    public static string GenerateCacheKey(
        CultureInfo cultureInfo,
        Guid? tenantId,
        Guid? currentUserId,
        Guid? externalId
    )
    {
        return
            $"TemplateEditor:{cultureInfo}:{tenantId}:{currentUserId}:{externalId}";
    }
    
    public static async Task<List<T>?> GetCacheAsync<T>(
        this IDistributedCache distributedCache,
        string key,
        CancellationToken cancellationToken = default)
        where T : class
    {
        var byteData = await distributedCache.GetAsync(key, cancellationToken);
        if (byteData == null || byteData.Length == 0)
        {
            return null;
        }

        var decompressed = DecompressData(byteData);
        return JsonSerializer.Deserialize<List<T>>(decompressed);
    }

    public static async Task SetCacheAsync(
        this IDistributedCache distributedCache,
        string key,
        byte[]? valueBytes,
        CancellationToken cancellationToken = default)
    {
        if (!valueBytes.IsNullOrEmpty())
        {
            await distributedCache.SetAsync(key, valueBytes!, cancellationToken);
        }
    }
    
    public static byte[] CompressData<T>(T model)
    {
        var settings = new JsonSerializerOptions()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            MaxDepth = 10
        };

        var data = JsonSerializer.SerializeToUtf8Bytes(model, settings);
        using var output = new MemoryStream();
        using (var gzip = new GZipStream(output, CompressionLevel.Optimal))
            gzip.Write(data, 0, data.Length);
        return output.ToArray();
    }

    public static string DecompressData(byte[] data)
    {
        using var input = new MemoryStream(data);
        using var gzip = new GZipStream(input, CompressionMode.Decompress);
        using var output = new MemoryStream();
        gzip.CopyTo(output);
        return Encoding.UTF8.GetString(output.ToArray());
    }
}