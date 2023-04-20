using NaficebiLib.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NaficebiLib.Managers
{
    public class CandidateManager : ICandidateManager<PrincipalModel>
    {
        public List<PrincipalModel> Principal { get; set; }
        private readonly JsonSerializerOptions options;
        public CandidateManager(List<PrincipalModel> Principal)
        {
           
            this.Principal= Principal;
            options = new JsonSerializerOptions()
            {
                IgnoreReadOnlyFields = true,

            };
        }

        public CandidateManager()
        {
        }
        /*
          პრინციპალების ცხრილის ჯსონ ფაილში შენახვა
          მეთოდი არგუმენტი: შესანახი ფაილის სრული სახელი (მისამართი)
         
         */
        public async Task SaveListToJson(string path)
        {
             
                using (FileStream stream = File.Create(path))
                {
                    
                    await JsonSerializer.SerializeAsync(stream, Principal, options);
                    stream.Close();
                }
            

        }
        public async Task SaveListToJson(string path,List<PrincipalModel> principals)
        {

            using (FileStream stream = File.Create(path))
            {

                await JsonSerializer.SerializeAsync(stream, principals, options);
                stream.Close();
            }


        }
        public async Task<List<PrincipalModel>> DeserializeFromJson(string path,bool sort=false)
        {
            using (Stream stream = File.Open(path,FileMode.Open))
            {

                var list = await JsonSerializer.DeserializeAsync<List<PrincipalModel>>(stream, options);
                stream.Close();
                List<PrincipalModel> candidates = new List<PrincipalModel>();
                list.ForEach(pric => candidates.Add(new PrincipalModel()
                {
                    PV_NUNMBER = pric.PV_NUNMBER,
                    FIRST = pric.FIRST,
                    LAST = pric.LAST,
                    BIRTH_DATE= pric.BIRTH_DATE,
                    BP_FULL_ADDRESS= pric.BP_FULL_ADDRESS,
                }));
                if(sort)
                    candidates.Sort();
                
                return candidates;
            };
            
        }
        public async Task<List<PrincipalModel>> DeserializeFromJson(string path,double number1,double number2)
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {

                var list = await JsonSerializer.DeserializeAsync<List<PrincipalModel>>(stream, options);
                List<PrincipalModel> candidates = new List<PrincipalModel>();
                list.ForEach(pric => candidates.Add(new PrincipalModel()
                {
                    PV_NUNMBER = pric.PV_NUNMBER,
                    FIRST = pric.FIRST,
                    LAST = pric.LAST,
                    BIRTH_DATE = pric.BIRTH_DATE,
                    BP_FULL_ADDRESS = pric.BP_FULL_ADDRESS,
                    Number1= number1,
                    Number2= number2,
                }));
                candidates.Sort();
                var candidates2 = candidates.GetRange(0, 300);
                candidates.RemoveRange(0, 300);
                Principal = candidates;
                
                return candidates2;
            };

        }
        ~CandidateManager() {
            GC.Collect();
        }
    }
}
