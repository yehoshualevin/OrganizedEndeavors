using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizedEndeavors.Data
{
    public class EndeavorsRepository1
    {
        private readonly string _conStr;
        public EndeavorsRepository1(string conStr)
        {
            _conStr = conStr;
        }

        public void AddEndeavor(string endeavor)
        {
            using (var ctn = new SqlConnection(_conStr))
            using (var cmd = ctn.CreateCommand())
            {
                cmd.CommandText = "Insert Into endeavors(endeavor,isCompleted)" +
                    " values (@endeavor,@isCompleted)";
                cmd.Parameters.AddWithValue("@endeavor", endeavor);
                cmd.Parameters.AddWithValue("@isCompleted", false);
                ctn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Endeavor> GetIncompleteEndeavors()
        {
            using (var ctn = new SqlConnection(_conStr))
            using (var cmd = ctn.CreateCommand())
            {
                cmd.CommandText = @"select e.*, m.name 
                                    from Endeavors e
                                    left join members m
                                    on e.HandledBy = m.Id
                                    where IsCompleted = 0";
                ctn.Open();
                var reader = cmd.ExecuteReader();
                List<Endeavor> endeavors = new List<Endeavor>();
                while (reader.Read())
                {
                    Endeavor endeavor = new Endeavor
                    {
                        Id = (int)reader["Id"],
                        Endeavor1 = (string)reader["Endeavor"]
                    };
                    int hb = 0;
                    object handledBy = reader["HandledBy"];
                    if (handledBy != DBNull.Value)
                    {
                        hb = (int)handledBy;
                    }

                    object name = reader["name"];
                    if (name != DBNull.Value)
                    {
                        endeavor.Member = new Member
                        {
                            Name = (string)name
                        };
                    }
                    endeavor.HandledBy = hb;
                    endeavors.Add(endeavor);
              }
            return endeavors;
            }
        }
        public void SetDoing(int endeavorId, int memberId)
        {
            using (var context = new OrganizedEndeavorsDataContext())
            {
                context.ExecuteCommand("UPDATE Endeavors SET HandledBy = {0} where Id = {1}", memberId, endeavorId);
            }
        }
        public void SetCompleted(int endeavorId)
        {
            using (var ctn = new SqlConnection(_conStr))
            using (var cmd = ctn.CreateCommand())
            {
                cmd.CommandText = "UPDATE Endeavors SET IsCompleted = 1 WHERE Id = @endeavorId";
                cmd.Parameters.AddWithValue("@endeavorId", endeavorId);
                ctn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }

}
