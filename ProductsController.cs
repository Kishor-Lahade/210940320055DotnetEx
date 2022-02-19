using _210940320055.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _210940320055.Content
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {

            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=sept2021;Integrated Security=True";
            sc.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = sc;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "select * from Products";
            List<Product> list = new List<Product>();

            try
            {
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    Product p = new Product();
                    p.ProductId = (int)dr["ProductId"];
                    p.ProductName = (string)dr["ProductName"];
                    p.Rate = (decimal)dr["Rate"];
                    p.Description = (string)dr["Description"];
                    p.CategoryName = (string)dr["CategoryName"];
                    
                   
                    list.Add(p);
                }
                sc.Close();
            }
            catch (Exception e)
            {

            }
            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id=1)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=sept2021;Integrated Security=True";
            sc.Open();


            SqlCommand cm = new SqlCommand();
            cm.Connection = sc;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "select * from Products where ProductId=@Id";
            cm.Parameters.AddWithValue("@id", id);
            Product obj = null;

            try
            {
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    obj = new Product { ProductId = (int)id, ProductName = dr.GetString(1), Rate = dr.GetDecimal(2), Description = dr.GetString(3), CategoryName=dr.GetString(4) };
                }
                dr.Close();
                sc.Close();
            }
            catch (Exception e)
            {

            }
            return View(obj);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product obj)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=sept2021;Integrated Security=True";
            sc.Open();


            try
            {
                SqlCommand cm = new SqlCommand();
                cm.Connection = sc;
                 cm.CommandType = System.Data.CommandType.StoredProcedure;

                 cm.CommandText = "updateProduct";
             
               
                cm.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cm.Parameters.AddWithValue("@Rate", obj.Rate);
                cm.Parameters.AddWithValue("@Description", obj.Description);
                cm.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
                cm.ExecuteNonQuery();
                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                return View(obj);
            }
            finally
            {
                sc.Close();
            }
        }
        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
