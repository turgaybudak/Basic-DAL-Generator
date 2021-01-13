
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YazilimAraciV2
{
    partial class YazilimAraci
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label ProjeAdi;
        private System.Windows.Forms.Label ConString;
        private System.Windows.Forms.TextBox txtProjeAdi;
        private System.Windows.Forms.TextBox txtConString;
        private System.Windows.Forms.Button btnKlasor;
        private System.Windows.Forms.Button btnHazirla;
        private System.Windows.Forms.ProgressBar Bar;
        private System.Windows.Forms.ListBox lstTablolar;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YazilimAraci));
            this.ProjeAdi = new System.Windows.Forms.Label();
            this.ConString = new System.Windows.Forms.Label();
            this.txtProjeAdi = new System.Windows.Forms.TextBox();
            this.txtConString = new System.Windows.Forms.TextBox();
            this.btnKlasor = new System.Windows.Forms.Button();
            this.btnHazirla = new System.Windows.Forms.Button();
            this.Bar = new System.Windows.Forms.ProgressBar();
            this.lstTablolar = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ProjeAdi
            // 
            this.ProjeAdi.AutoSize = true;
            this.ProjeAdi.Location = new System.Drawing.Point(34, 42);
            this.ProjeAdi.Name = "ProjeAdi";
            this.ProjeAdi.Size = new System.Drawing.Size(49, 13);
            this.ProjeAdi.TabIndex = 0;
            this.ProjeAdi.Text = "Proje Adi";
            // 
            // ConString
            // 
            this.ConString.AutoSize = true;
            this.ConString.Location = new System.Drawing.Point(34, 77);
            this.ConString.Name = "ConString";
            this.ConString.Size = new System.Drawing.Size(91, 13);
            this.ConString.TabIndex = 1;
            this.ConString.Text = "Connection String";
            // 
            // txtProjeAdi
            // 
            this.txtProjeAdi.Location = new System.Drawing.Point(137, 42);
            this.txtProjeAdi.Name = "txtProjeAdi";
            this.txtProjeAdi.Size = new System.Drawing.Size(100, 20);
            this.txtProjeAdi.TabIndex = 2;
            this.txtProjeAdi.TextChanged += new System.EventHandler(this.txtProjeAdi_TextChanged);
            // 
            // txtConString
            // 
            this.txtConString.Location = new System.Drawing.Point(137, 74);
            this.txtConString.Name = "txtConString";
            this.txtConString.Size = new System.Drawing.Size(100, 20);
            this.txtConString.TabIndex = 3;
            this.txtConString.TextChanged += new System.EventHandler(this.txtConString_TextChanged);
            // 
            // btnKlasor
            // 
            this.btnKlasor.Location = new System.Drawing.Point(37, 313);
            this.btnKlasor.Name = "btnKlasor";
            this.btnKlasor.Size = new System.Drawing.Size(75, 23);
            this.btnKlasor.TabIndex = 4;
            this.btnKlasor.Text = "Klasor";
            this.btnKlasor.UseVisualStyleBackColor = true;
            this.btnKlasor.Click += new System.EventHandler(this.btnKlasor_Click);
            // 
            // btnHazirla
            // 
            this.btnHazirla.Location = new System.Drawing.Point(162, 313);
            this.btnHazirla.Name = "btnHazirla";
            this.btnHazirla.Size = new System.Drawing.Size(75, 23);
            this.btnHazirla.TabIndex = 5;
            this.btnHazirla.Text = "Hazırla";
            this.btnHazirla.UseVisualStyleBackColor = true;
            this.btnHazirla.Click += new System.EventHandler(this.btnHazirla_Click);
            // 
            // Bar
            // 
            this.Bar.BackColor = System.Drawing.Color.FloralWhite;
            this.Bar.Location = new System.Drawing.Point(-1, -4);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(284, 10);
            this.Bar.TabIndex = 6;
            // 
            // lstTablolar
            // 
            this.lstTablolar.FormattingEnabled = true;
            this.lstTablolar.Location = new System.Drawing.Point(37, 101);
            this.lstTablolar.Name = "lstTablolar";
            this.lstTablolar.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTablolar.Size = new System.Drawing.Size(199, 199);
            this.lstTablolar.TabIndex = 7;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(283, 362);
            this.Controls.Add(this.lstTablolar);
            this.Controls.Add(this.Bar);
            this.Controls.Add(this.btnHazirla);
            this.Controls.Add(this.btnKlasor);
            this.Controls.Add(this.txtConString);
            this.Controls.Add(this.txtProjeAdi);
            this.Controls.Add(this.ConString);
            this.Controls.Add(this.ProjeAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "YazilimAraciV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yazilim Aracı V2";
            this.Load += new System.EventHandler(this.YazilimAraci_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public static double Yuzde;
        public static string DosyaYolu = @"c:/YazilimAraciV2";
        public static List<DBNesneler_Type> Nesneler;

        private void YazilimAraci_Load(object sender, EventArgs e)
        {
        }

        private void btnHazirla_Click(object sender, EventArgs e)
        {
            string ProjeAdi = txtProjeAdi.Text.Replace(" - ", "").Replace(" ", "").Replace("_", "");


            if (ProjeAdi != string.Empty && txtConString.Text != string.Empty && lstTablolar.SelectedItems.Count > 0)
                Task.Run(() => Hazirla(ProjeAdi, txtConString.Text));
        }

        private void Hazirla(string ProjeAdi, string ConString)
        {

            Nesneler = Nesneler.Where(a => lstTablolar.SelectedItems.Contains(a.Tablo)).ToList();

            KlasorleriHazirla(ProjeAdi);
            BusinessHazirla(ProjeAdi, ConString);
            TypesHazirla(ProjeAdi, ConString);

            if (Directory.Exists(DosyaYolu + "/" + ProjeAdi))
                Process.Start(DosyaYolu);
        }

        private void TypesHazirla(string ProjeAdi, string conString)
        {
            foreach (var item in Nesneler.GroupBy(a => a.Tablo).Select(a => a.Key))
            {
                string Dto = @"
                                    using System;


                                    namespace %ProjeAdi%.Types
                                    {
                                        public partial class " + item + @"_Type
                                        {

                                    " +
                                    string.Join("\n", Nesneler.Where(a => a.Tablo == item).Select(a => "public " + a.KolonTipi + (a.Nullmu ? "?" : "") + " " + a.Kolon + " { get; set; }"))
                                    + @"
                                        }
                                    }

                              ";
                Dto = ParametreleriGir(Dto, "%ProjeAdi%", ProjeAdi);
                ClassKaydet(DosyaYolu + "/" + ProjeAdi + "/Types/" + item + "_Type.cs", Dto);
            }
        }

        private void BusinessHazirla(string ProjeAdi, string conString)
        {
            foreach (var item in Nesneler.GroupBy(a => a.Tablo).Select(a => a.Key))
            {

                string Business = @"

using %ProjeAdi%.Genel;
using %ProjeAdi%.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace %ProjeAdi%.Business
{
    public class " + item + @" : DBConnect<" + item + @"_Type>
    {
        public " + item + @"()
        {
            TableName = 'dbo." + item + @"';
            PrimaryKey = '" + Nesneler.Where(a => a.Tablo == item && a.PKmi).First().Kolon + @"';
        }

        public override int Add(" + item + @"_Type item)
        {
            String[] fields = { " +
                                    string.Join("\n", Nesneler.Where(a => a.Tablo == item).Select(a => "'" + a.Kolon + "'"))
                                    + @" };
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = Sabitler.sql_INSERT(fields, TableName);
            " +
                                    string.Join("\n", Nesneler.Where(a => a.Tablo == item).Select(a => "cmd.Parameters.AddWithValue('" + a.Kolon + "', item." + a.Kolon + ");"))
                                    + @"
            return ExecuteNonQuery(cmd);
        }

   

        public override List<" + item + @"_Type> DataRowConvert(DataTable dt)
        {
            List<" + item + @"_Type> " + item + @"_TypeList = new List<" + item + @"_Type>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                    " + item + @"_TypeList.Add(DataRowConverter(dr));
            }
            return " + item + @"_TypeList;
        }

        public override " + item + @"_Type DataRowConverter(DataRow dr)
        {
            " + item + @"_Type _" + item + @"_Type = new " + item + @"_Type();

           
             " +
        string.Join("\n", Nesneler.Where(a => a.Tablo == item).Select(a => "_" + item + @"_Type." + a.Kolon + @" = " + TipeGoreConvert(a.Kolon, a.KolonTipi) + ";"))
                                    + @"
            return _" + item + @"_Type;
        }



    }
}

";

                Business = ParametreleriGir(Business, "%ProjeAdi%", ProjeAdi);
                ClassKaydet(DosyaYolu + "/" + ProjeAdi + "/Business/" + item + ".cs", Business);
            }
        }

        private string TipeGoreConvert(string Kolon, string KolonTipi)
        {
            string Yeni;

            switch (KolonTipi)
            {
                case "int":
                    {
                        Yeni = "int.Parse(dr['" + Kolon + "'].ToString())";
                        break;
                    }

                case "decimal":
                    {
                        Yeni = "decimal.Parse(dr['" + Kolon + "'].ToString())";
                        break;
                    }

                case "DateTime":
                    {
                        Yeni = "Convert.ToDateTime(dr['" + Kolon + "'].ToString())";
                        break;
                    }

                case "bool":
                    {
                        Yeni = "bool.Parse(dr['" + Kolon + "'].ToString())";
                        break;
                    }
                case "byte[]":
                    {
                        Yeni = "(byte[])dr['" + Kolon + "']";
                        break;
                    }

                default:
                    {
                        Yeni = "dr['" + Kolon + "'].ToString()";
                    }
                    break;
            }



            return Yeni;
        }



        private List<DBNesneler_Type> DBNesneleriGetir(string ConString)
        {
            List<DBNesneler_Type> List = new List<DBNesneler_Type>();

            string Query = @"

                           SELECT
                              T.TABLE_NAME as Tablo 
                              ,K.COLUMN_NAME as Kolon
                              ,(case when K.DATA_TYPE ='datetime' then 'DateTime'when K.DATA_TYPE ='date' then 'DateTime' when K.DATA_TYPE ='nvarchar' then 'string' when K.DATA_TYPE ='nchar' then 'string' when K.DATA_TYPE ='varbinary' then 'byte[]' when K.DATA_TYPE ='bit' then 'bool' else K.DATA_TYPE end) as KolonTipi 
                              ,case when K.COLUMN_NAME=PK.PrimaryKey then 'true' else 'false' end as PKmi
                              ,case when K.IS_NULLABLE='Yes' then 'true' else 'false' end as Nullmu,*

                            FROM
                              INFORMATION_SCHEMA.TABLES as T left join
                              INFORMATION_SCHEMA.COLUMNS as K on
                              T.TABLE_NAME=K.TABLE_NAME left join
                              (
	                            SELECT
	                              T.TABLE_NAME,K.COLUMN_NAME as PrimaryKey
	                            FROM
	                              INFORMATION_SCHEMA.TABLES as T left join
	                              INFORMATION_SCHEMA.KEY_COLUMN_USAGE as K on
	                              T.TABLE_NAME=K.TABLE_NAME and not CONSTRAINT_NAME like'FK_%'
                              )as PK  on
                              PK.TABLE_NAME=T.TABLE_NAME 
							WHERE 
							 NOT T.TABLE_NAME like '%spt_%' and NOT T.TABLE_NAME like '%MSreplication_%' and NOT T.TABLE_NAME like 'sys%' and TABLE_TYPE='BASE TABLE'
                            ";

            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                                List.Add(new DBNesneler_Type { Tablo = dr[0].ToString(), Kolon = dr[1].ToString(), KolonTipi = dr[2].ToString(), PKmi = bool.Parse(dr[3].ToString()), Nullmu = bool.Parse(dr[4].ToString()) });

                        }
                    }
                }

            }
            catch (Exception)
            {

            }


            return List;
        }

        private void KlasorleriHazirla(string ProjeAdi)
        {

            if (!Directory.Exists(DosyaYolu))//Anadosya
                Directory.CreateDirectory(DosyaYolu);
         


            if (!Directory.Exists(DosyaYolu + "/" + ProjeAdi))//ProjeDosyasi
                Directory.CreateDirectory(DosyaYolu + "/" + ProjeAdi);
            else
            {
                DirectoryInfo di = new DirectoryInfo(DosyaYolu + "/" + ProjeAdi);

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    foreach (FileInfo file in dir.GetFiles())
                        file.Delete();

                    dir.Delete(true);
                }
            }


            if (!Directory.Exists(DosyaYolu + "/" + ProjeAdi + "/Business"))//Genel
                Directory.CreateDirectory(DosyaYolu + "/" + ProjeAdi + "/Business");

            if (!Directory.Exists(DosyaYolu + "/" + ProjeAdi + "/Types"))//Properties
                Directory.CreateDirectory(DosyaYolu + "/" + ProjeAdi + "/Types");

        }

        private void btnKlasor_Click(object sender, EventArgs e)
        {
            string ProjeAdi = txtProjeAdi.Text.Replace("-", "").Replace(" ", "").Replace("_", "");

            if (ProjeAdi != string.Empty)
                KlasorleriHazirla(ProjeAdi);

            if (Directory.Exists(DosyaYolu + "/" + ProjeAdi))
                Process.Start(DosyaYolu);
        }

        private void txtConString_TextChanged(object sender, EventArgs e)
        {
            string ProjeAdi = txtProjeAdi.Text.Replace(" - ", "").Replace(" ", "").Replace("_", "");


            if (ProjeAdi != string.Empty && txtConString.Text != string.Empty)
            {
                Nesneler = DBNesneleriGetir(txtConString.Text);

                if (lstTablolar.Items.Count > 0)
                    lstTablolar.DataSource = null;

                lstTablolar.DataSource = Nesneler.GroupBy(a => a.Tablo).Select(a => a.Key).ToList();
            }

        }

        private void txtProjeAdi_TextChanged(object sender, EventArgs e)
        {
            string ProjeAdi = txtProjeAdi.Text.Replace(" - ", "").Replace(" ", "").Replace("_", "");


            if (ProjeAdi != string.Empty && txtConString.Text != string.Empty)
            {
                Nesneler = DBNesneleriGetir(txtConString.Text);

                if (lstTablolar.Items.Count > 0)
                    lstTablolar.DataSource = null;

                lstTablolar.DataSource = Nesneler.GroupBy(a => a.Tablo).Select(a => a.Key).ToList();
            }

        }



        private void ClassKaydet(string DosyaYoluAdi, string text)
        {
            FileStream fParameter = new FileStream(DosyaYoluAdi, FileMode.Create, FileAccess.Write);
            StreamWriter m_WriterParameter = new StreamWriter(fParameter);
            m_WriterParameter.BaseStream.Seek(0, SeekOrigin.End);
            m_WriterParameter.Write(text);
            m_WriterParameter.Flush();
            m_WriterParameter.Close();
        }

        private string ParametreleriGir(string input, string Eski, string Yeni)
        {

            return Regex.Replace(input, Eski, Yeni).Replace("'", "\"");
        }



    }
}

