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
    public class GroceryItemService
    {
        static string connectionString = "";
        static GroceryItemService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }

        public int Create(GroceryItemAddRequest item)
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
                    InsertItemType(id, item.ItemType);

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

        public void InsertItemType(int itemId, int typeId)
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
                    cmd.CommandText = "Item_ItemType_Insert";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    cmd.Parameters.AddWithValue("@TypeId", typeId);
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

        public List<GroceryItem> GetAll()
        {
            List<GroceryItem> list = null;
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
                            list = new List<GroceryItem>();
                        }
                        list.Add(DataMapper<GroceryItem>.Instance.MapToObject(reader));
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

        public GroceryItem Get(int id)
        {
            GroceryItem item = new GroceryItem();
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
                        item = DataMapper<GroceryItem>.Instance.MapToObject(reader);
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

        public void Update(GroceryItemUpdateRequest item, int id)
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