using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace AdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ado 1

            ////Bağlantı
            //SqlConnection baglanti = new SqlConnection();

            ////Bağlantı Yolu
            //baglanti.ConnectionString = @"Data Source= .\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security = True";

            ////Komut
            //SqlCommand komut = new SqlCommand();
            //komut.Connection = baglanti;

            ////Komut metni
            //komut.CommandText = "SELECT COUNT(*) FROM Products";

            ////Bağlantı aç
            //baglanti.Open();

            ////Sorgu Çalıştır
            //int sayi = Convert.ToInt32(komut.ExecuteScalar());
            ////Sorgudan gelen tek bir veri ise executescalar kullanılır.

            //Console.WriteLine("Ürün Sayısı: "+sayi);

            ////bağlantı Kapat
            //baglanti.Close();

            #endregion

            #region Ado 2

            //SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = NORTHWND; Integrated Security = true");
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT COUNT(*) FROM Categories";

            //con.Open();
            //int sayi = Convert.ToInt32(cmd.ExecuteScalar());
            //Console.WriteLine(sayi);
            //con.Close();

            #endregion

            #region Tüm Kategoriler

            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog = NORTHWND;Integrated Security=True");
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT CategoryID,CategoryName,Description FROM Categories";
            //con.Open();

            //SqlDataReader reader = cmd.ExecuteReader();//Tablo gelecek ise kullanılır

            //while(reader.Read())
            //{
            //    int id = reader.GetInt32(0);
            //    string isim = reader.GetString(1);
            //    string aciklama = reader.GetString(2);
            //    Console.WriteLine($"{id} - {isim} - {aciklama}");
            //}
            //con.Close();

            #endregion

            #region Uygulama

            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog = NORTHWND;Integrated Security=True");
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT P.ProductID, P.ProductName, C.CategoryName, S.CompanyName, P.Unitprice, P.UnitsInStock FROM Products AS P JOIN Categories AS C ON C.CategoryID = P.CategoryID JOIN Suppliers AS S ON S.SupplierID = P.SupplierID  ";
            //con.Open();

            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    int id = reader.GetInt32(0);
            //    string isim = reader.GetString(1);

            //    string kategori = " ";
            //    if (!reader.IsDBNull(2))
            //    {
            //        kategori = reader.GetString(2);
            //    }

            //    string sirket = " ";
            //    if (!reader.IsDBNull(3))
            //    {
            //        sirket = reader.GetString(3);
            //    }

            //    decimal fiyat = reader.GetDecimal(4);
            //    short stok = reader.GetInt16(5);
            //    Console.WriteLine($"{id} - {isim} - {kategori} - {sirket} - {fiyat} - {stok}");
            //}
            //con.Close();

            #endregion

            #region Urunler(ProductID, ProductName, CategoryName, Unitprice)

            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog = NORTHWND;Integrated Security=True");
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = "SELECT P.ProductID, P.ProductName, C.CategoryName, P.Unitprice FROM Products AS P JOIN Categories AS C ON C.CategoryID = P.CategoryID ";
            //con.Open();

            //SqlDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    int id = reader.GetInt32(0);
            //    string isim = reader.GetString(1);
            //    string kategori = reader.GetString(2);
            //    decimal fiyat = reader.GetDecimal(3);
            //    Console.WriteLine($"{id} - {isim} - {kategori} - {fiyat}");
            //}
            //con.Close();

            #endregion

            #region Veri Ekleme

            //Console.WriteLine("Kategori Adı giriniz:");
            //string katAdi = Console.ReadLine();

            //Console.WriteLine("Kategori Açıklama giriniz:");
            //string aciklama = Console.ReadLine();

            //SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = NORTHWND;Integrated Security = True");
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandText = $"INSERT INTO Categories(CategoryName, Description) VALUES('{katAdi}','{aciklama}')";
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

            #endregion

            #region Alınan kategori numarasındaki ürünleri listeleyin

            Console.WriteLine("Kategori numarası giriniz:");
            int katNo = Convert.ToInt32(Console.ReadLine());

            SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = NORTHWND;Integrated Security = True");
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = $"SELECT ProductName FROM Products WHERE CategoryID = {katNo}";
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string isim = reader.GetString(0);
                Console.WriteLine($"{isim}");
            }

            con.Close();

            #endregion
        }
    }
}
