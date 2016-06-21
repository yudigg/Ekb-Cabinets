using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkbDataAccess
{
   public class AdminsManager
   {
       private readonly string _connectionString;
       public AdminsManager(string connection)
       {
           _connectionString = connection;
       }
       public void AddAdmin(string username, string password)
       {
           Admin admin = new Admin();
           string salt = PasswordHelper.GenerateRandomSalt();
           string passwordHash = PasswordHelper.HashPassword(password, salt);
           admin.PasswordHash= passwordHash;
           admin.Salt = salt;
           admin.Username = username;
           using (var dc = new DataClassesDataContext(_connectionString))
           {
               dc.Admins.InsertOnSubmit(admin);
               dc.SubmitChanges();
           }
       }

       public Admin GetAdmin(string username, string password)
       {
           using (var dc = new DataClassesDataContext(_connectionString))
           {
               var admin = dc.Admins.FirstOrDefault(a => a.Username == username);
               if (admin == null)
               {
                   return null;
               }
               bool success = PasswordHelper.PasswordMatch(password, admin.PasswordHash, admin.Salt);
               return success ? admin : null;
           }
       }
   }
}
