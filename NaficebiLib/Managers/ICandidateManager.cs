using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaficebiLib.Managers
{
    public interface ICandidateManager<T>
    {
         Task SaveListToJson(string path);
         Task<List<T>> DeserializeFromJson(string path,bool sort=false);
         Task<List<T>> DeserializeFromJson(string path, double number1, double number2);
    }
}
