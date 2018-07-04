using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizedEndeavors.Data
{
    public class EndeavorsRepository
    {
        public void AddEndeavor(Endeavor endeavor)
        {
            using (var context = new OrganizedEndeavorsDataContext())
            {
                context.Endeavors.InsertOnSubmit(endeavor);
                context.SubmitChanges();
            }
        }
        public IEnumerable<Endeavor> GetIncompleteEndeavors()
        {
            using (var context = new OrganizedEndeavorsDataContext())
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Endeavor>(e => e.Member);
                context.LoadOptions = loadOptions;
                return context.Endeavors.Where(e => !e.IsCompleted).ToList();
            }
        }
        public void SetDoing(int endeavorId,int memberId)
        {
            using(var context = new OrganizedEndeavorsDataContext())
            {
                context.ExecuteCommand("UPDATE Endeavors SET HandledBy = {0} where Id = {1}", memberId, endeavorId);
            }
        }
        public void SetCompleted(int endeavorId)
        {
            using (var context = new OrganizedEndeavorsDataContext())
            {                
                    context.ExecuteCommand("UPDATE Endeavors SET IsCompleted = 1 WHERE Id = {0}", endeavorId);                
            }
        }


    }
}
