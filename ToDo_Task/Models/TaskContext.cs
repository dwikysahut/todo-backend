using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ToDo_Task.Models
{
    public class TaskContext
    {
        public string ConnectionString { get; set; }

        public TaskContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<TaskModel> GetAllTask()
        {
            List<TaskModel> list = new List<TaskModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM task", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaskModel()
                        {
                            id = reader.GetInt32("id"),
                            title = reader.GetString("title"),
                            description = reader.GetString("description"),
                            percentage_complete = reader.GetDouble("percentage_complete"),
                            expiredAt = reader.GetDateTime("expiredAt")

                        });
                    }
                }
            }
            return list;
        }

        public List<TaskModel> GetTask(string id)
        {
            List<TaskModel> list = new List<TaskModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM task WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaskModel()
                        {
                            id = reader.GetInt32("id"),
                            title = reader.GetString("title"),
                            description = reader.GetString("description"),
                            percentage_complete = reader.GetDouble("percentage_complete"),
                            expiredAt = reader.GetDateTime("expiredAt")
                        });
                    }
                }
            }
            return list;
        }
        public List<TaskModel> DeleteTask(string id)
        {
            List<TaskModel> list = new List<TaskModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Delete FROM task WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaskModel()
                        {
                            id = reader.GetInt32("id"),
                            title = reader.GetString("title"),
                            description = reader.GetString("description"),
                            percentage_complete = reader.GetDouble("percentage_complete"),
                            expiredAt = reader.GetDateTime("expiredAt")
                        });
                    }
                }
            }
            return list;
        }
        public List<TaskModel> PostTask()
        {
            List<TaskModel> list = new List<TaskModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO task (title,description) VALUES('sddsd', 'sdsaddsaas')", conn);
                //cmd.Parameters.AddWithValue("@title", "sdasdsad");
                //cmd.Parameters.AddWithValue("@description", "sdsads");

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TaskModel()
                        {
                            id = reader.GetInt32("id"),
                            title = reader.GetString("title"),
                            description = reader.GetString("description"),
                            percentage_complete = reader.GetDouble("percentage_complete"),
                            expiredAt = reader.GetDateTime("expiredAt")

                        });
                    }
                }
            }
            return list;
        }
    }
}

