using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroceryApp;
using GroceryApp.Domain;
using System.Data.SqlClient;
using System.Configuration;
using GroceryApp.Requests;

namespace GroceryApp.Services
{
    public class ItemService
    {
        static string connectionString = "";
        static ItemService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }

        public int Create(ItemAddRequest item)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Item_Insert";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@ItemType", item.ItemType);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@PriceType", item.PriceType);
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@Id", System.Data.SqlDbType.Int);
                    cmd.Parameters["@Id"].Direction = System.Data.ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    int id = (int)cmd.Parameters["@Id"].Value;

                    return id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public List<Item> GetAll()
        {
            List<Item> list = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Item_SelectAll";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (list == null)
                        {
                            list = new List<Item>();
                        }
                        list.Add(DataMapper<Item>.Instance.MapToObject(reader));
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return list;
        }

        public Item Get(int id)
        {
            Item item = new Item();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Item_SelectById";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        item = DataMapper<Item>.Instance.MapToObject(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return item;
        }

        public void Update(ItemUpdateRequest item, int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Item_Update";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@ItemType", item.ItemType);
                    cmd.Parameters.AddWithValue("@Price", item.Price);
                    cmd.Parameters.AddWithValue("@PriceType", item.PriceType);
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "Item_Delete";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}