using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizedEndeavors.Data
{
    public class MembersRepository
    {
        private readonly string _conStr; 

        public MembersRepository(string conStr)
        {
            _conStr = conStr;
        }

        public void SignUp(Member member,string password)
        {
            string salt = PasswordHelper.GenerateSalt();
            string passwordHash = PasswordHelper.HashPassword(password, salt);
            member.PasswordSalt = salt;
            member.PasswordHash = passwordHash;
           using (var ctn = new SqlConnection(_conStr))
           using (var cmd = ctn.CreateCommand())
            {
                cmd.CommandText = "Insert Into members(name,email,passwordHash,passwordSalt)" +
                    " values (@name,@email,@passwordHash,@passwordSalt)";
                cmd.Parameters.AddWithValue("@name", member.Name);
                cmd.Parameters.AddWithValue("@email", member.Email);
                cmd.Parameters.AddWithValue("@passwordHash",member.PasswordHash);
                cmd.Parameters.AddWithValue("@passwordSalt",member.PasswordSalt);
                ctn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public Member LogIn(string email,string password)
        {
            Member member = GetByEmail(email);
            if (member == null)
            {
                return null;
            }
            bool isCorrectPassword = PasswordHelper.PasswordMatch(password, member.PasswordSalt, member.PasswordHash);
            if (!isCorrectPassword)
            {
                return null;
            }

            return member;
        }
        public Member GetByEmail(string email)
        {
            using (var ctn = new SqlConnection(_conStr))
            using (var cmd = ctn.CreateCommand())
            {
                cmd.CommandText = "select * from members where email = @email";
                cmd.Parameters.AddWithValue("email", email);
                ctn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    Member member = new Member
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Email = (string)reader["Email"],
                        PasswordHash = (string)reader["PasswordHash"],
                        PasswordSalt = (string)reader["PasswordSalt"]
                    };
                    return member;
                }
                return null;
            }
         }
    }
}
