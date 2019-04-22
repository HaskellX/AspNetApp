using DAL_Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITIES;

namespace Epam.Library.SqlDal
{
    public class UserDao : IUserDao
    {
        public bool Add(string login, string role, string hash)
        {
            using (var connection = Common.CreateConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "AddUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var loginDb = Common.CreateParameter("@login", System.Data.DbType.String, login);
                var roleDb = Common.CreateParameter("@role", System.Data.DbType.String, role);
                var hashDb = Common.CreateParameter("@hash", System.Data.DbType.String, hash);

                cmd.Parameters.AddRange(new[] { loginDb, roleDb, hashDb });

                connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool CanLogin(string login, string hash)
        {
            using (var connection = Common.CreateConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "CanLogin";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var result = Common.CreateOutputParameter("@canLogin", System.Data.DbType.Int32);
                var loginDb = Common.CreateParameter("@login", System.Data.DbType.String, login);
                var hashDb = Common.CreateParameter("@hash", System.Data.DbType.String, hash);

                cmd.Parameters.AddRange(new[] { result, loginDb, hashDb });

                connection.Open();
                cmd.ExecuteNonQuery();

                return (int)result.Value == 1;
            }
        }

        public bool ChangeRole(string login, string role)
        {
            using (var connection = Common.CreateConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "ChangeRole";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var loginDb = Common.CreateParameter("@login", System.Data.DbType.String, login);
                var roleDb = Common.CreateParameter("@role", System.Data.DbType.String, role);

                cmd.Parameters.AddRange(new[] { loginDb, roleDb });

                connection.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool Exists(string login)
        {
            using (var connection = Common.CreateConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UserExists";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var exists = Common.CreateOutputParameter("@exists", System.Data.DbType.Int32);
                var loginDb = Common.CreateParameter("@login", System.Data.DbType.String, login);

                cmd.Parameters.AddRange(new[] { exists, loginDb});

                connection.Open();

                cmd.ExecuteNonQuery();

                return (int)exists.Value == 1;

            }
        }

        public IEnumerable<User> GetAll()
        {
            List<User> list = new List<User>();

            using (var connection = Common.CreateConnection())
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = "GetAllUsers";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var user = new User
                    {
                        Login = (string)reader["login"],
                        Role = (string)reader["role"]
                    };

                    list.Add(user);
                }
            }

            return list.ToArray();
        }

        public IEnumerable<string> GetRolesForUser(string login)
        {
            List<string> list = new List<string>();

            using (var connection = Common.CreateConnection())
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = "GetRolesForUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var loginDb = Common.CreateParameter("@login", System.Data.DbType.String, login);
                cmd.Parameters.AddRange(new []{ loginDb });
                connection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add((string)reader["role"]);
                }
            }

            return list.ToArray();
        }

        public User GetUserByLogin(string login)
        {
            using (var connection = Common.CreateConnection())
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = "GetUserByLogin";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var loginDb = Common.CreateParameter("@login", System.Data.DbType.String, login);

                cmd.Parameters.AddRange(new[] { loginDb });
                connection.Open();

                var reader = cmd.ExecuteReader();
                User user = null;

                if (reader.Read())
                {
                    user = new User()
                    {
                        Login = (string) reader["login"],
                        Role = (string) reader["role"]
                    };
                }

                return user;
            }
        }

        public bool IsUserInRole(string login, string role)
        {
            using (var connection = Common.CreateConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "IsUserInRole";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var isInRole = Common.CreateOutputParameter("@isInRole", System.Data.DbType.Int32);
                var loginDb = Common.CreateParameter("@login", System.Data.DbType.String, login);
                var roleDb = Common.CreateParameter("@role", System.Data.DbType.String, role);

                cmd.Parameters.AddRange(new[] {isInRole, loginDb, roleDb });

                connection.Open();

                cmd.ExecuteNonQuery();

                return (int)isInRole.Value == 1;

            }
        }
    }
}
