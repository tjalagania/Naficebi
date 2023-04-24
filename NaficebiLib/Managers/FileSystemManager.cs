using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace NaficebiLib.Managers
{
    public static class FileSystemManager
    {
        public static void FolderCreate(string path)
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception e)
                {
                    throw new Exception($"ვერ მოხერდხდა ფაილის შექმნა {e.Message}");
                }


            }
        }
        
        public static Task<bool> SaveToJson(string path,IEnumerable<PrincipalModel>Principal, JsonSerializerOptions options)
        {
            return Task.Run(async () =>
            {
                using (FileStream stream = File.Create(path))
                {
                    try
                    {
                        await JsonSerializer.SerializeAsync(stream, Principal, options);
                        return true;
                    }
                    catch(Exception e) 
                    {
                        throw new Exception(e.Message);
                    }
                }
            });


        }
    }
}
