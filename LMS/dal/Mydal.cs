using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace LMS.dal
{
    public class Mydal
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        //Member functions
        public int signup(string memberID, string name, string password, string ph_no, string gender, string address, string dob, string email)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("signup ", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@mem_id", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@ph_no", SqlDbType.Char, 11);
                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@address", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@dob", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@name"].Value = name;
                cmd.Parameters["@mem_id"].Value = memberID;
                cmd.Parameters["@pass"].Value = password;
                cmd.Parameters["@ph_no"].Value = ph_no;
                cmd.Parameters["@gender"].Value = gender;
                cmd.Parameters["@address"].Value = address;
                cmd.Parameters["@dob"].Value = dob;
                cmd.Parameters["@email"].Value = email;

                cmd.ExecuteNonQuery();

                found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public int loginMember(string memberID, string password)
        {
            int found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("loginMember ", con); //name of procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@mem_id", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@mem_id"].Value = memberID;
                cmd.Parameters["@pass"].Value = password;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;

        }
        public void memberProfileLoad(string userID, ref DataTable DT)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from member join packages on member.mem_pkg_id = packages.pkg_id where mem_id='" + userID + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(DT);
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());

            }
        }
        public void upMember(string memberID, string name, string phonenum, string email, string password, string gender, string dob, string address)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                cmd = new SqlCommand("upMember", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@mid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@ph_no", SqlDbType.Char, 11);
                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@address", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@dob", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50);

                // set parameter values
                cmd.Parameters["@mid"].Value = memberID;
                cmd.Parameters["@name"].Value = name;
                cmd.Parameters["@pass"].Value = password;
                cmd.Parameters["@ph_no"].Value = phonenum;
                cmd.Parameters["@gender"].Value = gender;
                cmd.Parameters["@address"].Value = address;
                cmd.Parameters["@dob"].Value = dob;
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@pass"].Value = password;

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }


        }

        //Admin functions
        public int loginAdmin(string adminID, string password)
        {
            int found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("loginAdmin ", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@aid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@aid"].Value = adminID;
                cmd.Parameters["@pass"].Value = password;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return found;

        }
        public void adminProfileLoad(string adminID, ref DataTable DT)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from admin where admin_id=" + adminID + "", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(DT);


                con.Close();
            }
            catch (SqlException ex)
            {
                //nothing
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        public void upAdmin(string adminID, string name, string phonenum, string email, string password, string gender, string dob, string address)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();


                cmd = new SqlCommand("upAdmin", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@aid", SqlDbType.VarChar, 12);

                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@ph_no", SqlDbType.Char, 11);
                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@address", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@dob", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50);

                // set parameter values
                cmd.Parameters["@aid"].Value = adminID;
                cmd.Parameters["@name"].Value = name;
                cmd.Parameters["@pass"].Value = password;
                cmd.Parameters["@ph_no"].Value = phonenum;
                cmd.Parameters["@gender"].Value = gender;
                cmd.Parameters["@address"].Value = address;
                cmd.Parameters["@dob"].Value = dob;
                cmd.Parameters["@email"].Value = email;

                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //nothing
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }


        }
        
        
        public int upMemberPkg(string userID, int pkgid)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("upMemberPkg", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@pid", SqlDbType.Int);
                cmd.Parameters.Add("@umpfound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@mid"].Value = userID;
                cmd.Parameters["@pid"].Value = pkgid;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@umpfound"].Value); //convert to output parameter to interger format

                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
            //int found = 0;
            //DataSet ds = new DataSet();
            //SqlConnection con = new SqlConnection(connString);
            //con.Open();
            //SqlCommand cmd;
            //try
            //{


            //    if (con.State == ConnectionState.Closed)
            //        con.Open();


            //    cmd = new SqlCommand("updateMemberpkg", con); //name of your procedure
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.Parameters.Add("@mem_id", SqlDbType.VarChar, 12);

            //    cmd.Parameters.Add("@pkg_ID", SqlDbType.Int);

            //    cmd.Parameters.Add("@umpfound", SqlDbType.Int).Direction = ParameterDirection.Output;

            //    // set parameter values
            //    cmd.Parameters["@mem_id"].Value = userID;
            //    cmd.Parameters["@pkg_ID"].Value = pkgid;
            //    cmd.ExecuteNonQuery();
            //    found = Convert.ToInt32(cmd.Parameters["@umpfound"].Value);
            //    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

            //    {
            //        da.Fill(DT);
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    //nothing
            //    Console.WriteLine("SQL error" + ex.Message.ToString());
            //}
            //return found;

        }
        public int addPublisher(string pID, string pname) {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addPublisher", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@pname", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@pfound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@pname"].Value = pname;
                cmd.Parameters["@pid"].Value = pID;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@pfound"].Value); //convert to output parameter to interger format
               
                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public int delPublisher(string pID)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delPublisher", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@pdfound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@pid"].Value = pID;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@pdfound"].Value); //convert to output parameter to interger format
               
                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public int upPublisher(string pID, string pname)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("upPublisher", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@pname", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@pufound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@pname"].Value = pname;
                cmd.Parameters["@pid"].Value = pID;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@pufound"].Value); //convert to output parameter to interger format

                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public int addAuthor(string aID, string aname)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addAuthor", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@aid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@aname", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@afound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@aname"].Value = aname;
                cmd.Parameters["@aid"].Value = aID;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@afound"].Value); //convert to output parameter to interger format

                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public int delAuthor(string aID)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delAuthor", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@aid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@adfound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@aid"].Value = aID;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@adfound"].Value); //convert to output parameter to interger format

                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public int upAuthor(string aID, string aname)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("upAuthor", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@aid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@aname", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@aufound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@aname"].Value = aname;
                cmd.Parameters["@aid"].Value = aID;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@aufound"].Value); //convert to output parameter to interger format

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public int delMember(string mID)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delMember", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@mfound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@mid"].Value = mID;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@mfound"].Value); //convert to output parameter to interger format

                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public void authorNameLoad(ref DataTable DT)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT name from author;", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(DT);
                //con.Close();
            }
            catch (SqlException ex)
            {
                //nothing
                Console.WriteLine("SQL error" + ex.Message.ToString());

            }
        }
        public void publisherNameLoad(ref DataTable DT)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT name from publisher;", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(DT);
                //con.Close();
            }
            catch (SqlException ex)
            {
                //nothing
                Console.WriteLine("SQL error" + ex.Message.ToString());

            }
        }
        public int addBook(string bID, string title, string lang, string genre, int act, int curr, int pubyear, string publisher, string author, string des, string imglink)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addBook", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@title", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@lingo", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@genre", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@num_act", SqlDbType.Int);
                cmd.Parameters.Add("@num_curr", SqlDbType.Int);
                cmd.Parameters.Add("@publ_yr", SqlDbType.Int);
                cmd.Parameters.Add("@publ", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@author", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@des", SqlDbType.NVarChar);
                cmd.Parameters.Add("@img_link", SqlDbType.NVarChar);
                cmd.Parameters.Add("@bafound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@bid"].Value = bID;
                cmd.Parameters["@title"].Value = title;
                cmd.Parameters["@lingo"].Value = lang;
                cmd.Parameters["@genre"].Value = genre;
                cmd.Parameters["@num_act"].Value = act;
                cmd.Parameters["@num_curr"].Value = curr;
                cmd.Parameters["@publ_yr"].Value = pubyear;
                cmd.Parameters["@publ"].Value = publisher;
                cmd.Parameters["@author"].Value = author;
                cmd.Parameters["@des"].Value = des;
                cmd.Parameters["@img_link"].Value = imglink;
                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@bafound"].Value); //convert to output parameter to interger format

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public int delBook(string bID)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("delBook", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@bdfound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@bid"].Value = bID;

                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@bdfound"].Value); //convert to output parameter to interger format

                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public int upBook(string bID, string title, string lang, string genre, int act, int curr, int pubyear, string publisher, string author, string des, string imglink)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("upBook", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@title", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@lingo", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@genre", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@num_act", SqlDbType.Int);
                cmd.Parameters.Add("@num_curr", SqlDbType.Int);
                cmd.Parameters.Add("@publ_yr", SqlDbType.Int);
                cmd.Parameters.Add("@publ", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@author", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@des", SqlDbType.NVarChar);
                cmd.Parameters.Add("@img_link", SqlDbType.NVarChar);
                cmd.Parameters.Add("@bufound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@bid"].Value = bID;
                cmd.Parameters["@title"].Value = title;
                cmd.Parameters["@lingo"].Value = lang;
                cmd.Parameters["@genre"].Value = genre;
                cmd.Parameters["@num_act"].Value = act;
                cmd.Parameters["@num_curr"].Value = curr;
                cmd.Parameters["@publ_yr"].Value = pubyear;
                cmd.Parameters["@publ"].Value = publisher;
                cmd.Parameters["@author"].Value = author;
                cmd.Parameters["@des"].Value = des;
                cmd.Parameters["@img_link"].Value = imglink;
                cmd.ExecuteNonQuery();

                // read output value 
                found = Convert.ToInt32(cmd.Parameters["@bufound"].Value); //convert to output parameter to interger format

                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;

        }
        public void bookLoad(string bID, ref DataTable DT)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT book.book_id, book.title, book.lingo, book.genre, book.num_act, book.num_curr, book.publ_yr, publisher.name AS publ, author.name AS author, book.des, book.img_link from (book join publisher on book.publ_id = publisher.publ_id) join author on book.auth_id = author.author_id where book_id='" + bID + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(DT);


                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        public int issueBook(string mID, string bID, string issue)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("issueBook", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@mid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@issuedate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ifound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@bid"].Value = bID;
                cmd.Parameters["@mid"].Value = mID;
                cmd.Parameters["@issuedate"].Value = issue;

                cmd.ExecuteNonQuery();

                found = Convert.ToInt32(cmd.Parameters["@ifound"].Value); //convert to output parameter to interger format

                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public void issueLoad(string mID, string bID, ref DataTable DT)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from borrowing where book_id='" + bID + "' AND mem_id='" + mID + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(DT);


                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        public int returnBook(string mID, string bID, string ret)
        {
            int found = 0;
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("returnBook", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@bid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@mid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@retdate", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@rbfound", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@bid"].Value = bID;
                cmd.Parameters["@mid"].Value = mID;
                cmd.Parameters["@retdate"].Value = ret;

                cmd.ExecuteNonQuery();

                found = Convert.ToInt32(cmd.Parameters["@rbfound"].Value); //convert to output parameter to interger format

                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return found;
        }
        public void bookReviewLoad(string bID, ref DataTable DT)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("SELECT mem_id AS [Member ID], review AS Review from borrowing where book_id='" + bID + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(DT);


                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error" + ex.Message.ToString());
            }
        }
        public void addReview(string mID, string bID, string rev)
        {
            DataSet ds = new DataSet(); //dataset object
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("addReview", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@bid", SqlDbType.VarChar, 12);
                cmd.Parameters.Add("@rev", SqlDbType.VarChar);

                // set parameter values
                cmd.Parameters["@mid"].Value = mID;
                cmd.Parameters["@bid"].Value = bID;
                cmd.Parameters["@rev"].Value = rev;

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
        }
        
    }
    
}