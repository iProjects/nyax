
/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 10/13/2018
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using Npgsql;
using nthareneapi;
using SMOScripting;
using System.ComponentModel;

namespace nyax
{
    /// <summary>
    /// Description of databaseutilsform.
    /// </summary>
    public partial class databaseutilsform : Form
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(databaseutilsform));

        public string TAG;
        public List<notificationdto> _lstnotificationdto = new List<notificationdto>();

        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        public event EventHandler<notificationmessageEventArgs> _databaseutilsnotificationeventname;
        public event EventHandler<progressBarNotificationEventArgs> _progressBarNotificationEventname;

        public bool _is_form_loaded = false;
        BackgroundWorker bgWorker = background_worker_singleton.getInstance().getBackgroundWorkerInstance();

        public databaseutilsform(EventHandler<notificationmessageEventArgs> notificationmessageEventname, EventHandler<progressBarNotificationEventArgs> progressBarNotificationEventname)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

            TAG = this.GetType().Name;

            //Subscribing events:  
            _notificationmessageEventname = notificationmessageEventname;
            _databaseutilsnotificationeventname += databaseutilsnotificationhandler;
            _progressBarNotificationEventname = progressBarNotificationEventname;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded databaseutilsform", TAG));
        }

        //Event handler declaration:
        public void databaseutilsnotificationhandler(object sender, notificationmessageEventArgs args)
        {
            notificationdto _notificationdto = new notificationdto();

            DateTime currentDate = DateTime.Now;
            String dateTimenow = currentDate.ToString("dd-MM-yyyy HH:mm:ss");

            string message = args.message;
            String _logtext = Environment.NewLine + "[ " + dateTimenow + " ]   " + message;

            _notificationdto._notification_message = _logtext;
            _notificationdto._created_datetime = dateTimenow;
            _notificationdto.TAG = TAG;

            _lstnotificationdto.Add(_notificationdto);

            var _lstmsgdto = from msgdto in _lstnotificationdto
                             orderby msgdto._created_datetime descending
                             select msgdto._notification_message;

            String[] _logflippedlines = _lstmsgdto.ToArray();

            txtlog.Lines = _logflippedlines;

            this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(message, TAG));

        }

        void logtodbutils(string message)
        {
            try
            {
                this._databaseutilsnotificationeventname.Invoke(this, new notificationmessageEventArgs(message, TAG));
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void DatabaseutilsformLoad(object sender, EventArgs e)
        {
            this.CancelButton = btnexit;
            txtcreatemssqldatabase.Focus();
            initializecontrols();
            loadappconfigurations();
            populateservers();
            txtxampserverpath.Text = System.Configuration.ConfigurationManager.AppSettings["xamp_server_path"];
        }

        void initializecontrols()
        {

            txtmssqlservername.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_datasource", @".\SQLEXPRESS");
            txtmssqldatabasename.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_database", "ntharenedb");
            txtmssqlusername.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_userid", "sa");
            txtmssqlpassword.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_password", "123456789");
            txtmssqlport.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_port", "1433");

            txtmysqlhostname.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_datasource", "127.0.0.1");
            txtmysqldatabasename.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_database", "ntharenedb");
            txtmysqlusername.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_userid", "sa");
            txtmysqlpassword.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_password", "123456789");
            txtmysqlport.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_port", "3306");

            txtsqlitedbpath.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_datasource", @"\databases\");
            txtsqlitedatabasename.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_database", "ntharenedb");
            txtsqliteversion.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_version", "3");
            txtsqlitepooling.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_pooling", "true");
            txtsqlitefailifmissing.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_fail_if_missing", "false");
            txtsqlitedbextension.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_db_extension", "sqlite");

            txtpostgresqlhostname.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_datasource", "127.0.0.1");
            txtpostgresqldatabasename.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_database", "postgres");
            txtpostgresqlusername.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_userid", "postgres");
            txtpostgresqlpassword.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_password", "123456789");
            txtpostgresqlport.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_port", "5432");
        }

        void loadappconfigurations()
        {
            try
            {

                txtsysmssqldatasource.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_datasource", @".\SQLEXPRESS");
                txtsysmssqldatabase.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_database", "ntharenedb");
                txtsysmssqlusername.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_userid", "sa");
                txtsysmssqlpassword.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_password", "123456789");
                txtsysmssqlport.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mssql_port", "1433");

                txtsysmysqldatastore.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_datasource", "127.0.0.1");
                txtsysmysqldatabase.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_database", "ntharenedb");
                txtsysmysqlusername.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_userid", "sa");
                txtsysmysqlpassword.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_password", "123456789");
                txtsysmysqlport.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("mysql_port", "3306");

                txtsyssqlitedbpath.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_datasource", @"\databases\");
                txtsyssqlitedatabase.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_database", "ntharenedb");
                txtsyssqliteversion.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_version", "3");
                txtsyssqlitepooling.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_pooling", "true");
                txtsyssqlitefailifmissing.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_fail_if_missing", "false");
                txtsyssqlitedbextension.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("sqlite_db_extension", "sqlite");

                txtsyspostgresqldatastore.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_datasource", "127.0.0.1");
                txtsyspostgresqldatabase.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_database", "postgres");
                txtsyspostgresqlusername.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_userid", "postgres");
                txtsyspostgresqlpassword.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_password", "123456789");
                txtsyspostgresqlport.Text = utilzsingleton.getInstance(_notificationmessageEventname).getappsettinggivenkey("postgresql_port", "5432");

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void DatabaseutilsformFormClosing(object sender, FormClosingEventArgs e)
        {

        }

        void BtnexitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        void BtnsavemssqlchangesClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                string _base_dir = Environment.CurrentDirectory;
                string _base_dir_with_filename = Application.ExecutablePath;
                string[] _path_levels_arr = _base_dir_with_filename.Split(Path.DirectorySeparatorChar);
                int _file_name_index_in_path = _path_levels_arr.Length - 1;
                string _exe_file_name = _path_levels_arr[_file_name_index_in_path];

                Configuration _Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(_base_dir_with_filename);

                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtsysmssqldatasource.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "server name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("server name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqldatasource, "server name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmssqldatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqldatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmssqlusername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "user name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("user name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqlusername, "user name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmssqlpassword.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "password cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("password cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqlpassword, "password cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmssqlport.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "port cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("port cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqlport, "port cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    mssqlconnectionstringdto _connectionstringdto = new mssqlconnectionstringdto();
                    _connectionstringdto.datasource = txtsysmssqldatasource.Text;
                    _connectionstringdto.database = txtsysmssqldatabase.Text;
                    _connectionstringdto.userid = txtsysmssqlusername.Text;
                    _connectionstringdto.password = txtsysmssqlpassword.Text;
                    _connectionstringdto.port = txtsysmssqlport.Text;

                    _Configuration.AppSettings.Settings.Remove("mssql_datasource");
                    _Configuration.AppSettings.Settings.Remove("mssql_database");
                    _Configuration.AppSettings.Settings.Remove("mssql_userid");
                    _Configuration.AppSettings.Settings.Remove("mssql_password");
                    _Configuration.AppSettings.Settings.Remove("mssql_port");

                    _Configuration.AppSettings.Settings.Add("mssql_datasource", _connectionstringdto.datasource);
                    _Configuration.AppSettings.Settings.Add("mssql_database", _connectionstringdto.database);
                    _Configuration.AppSettings.Settings.Add("mssql_userid", _connectionstringdto.userid);
                    _Configuration.AppSettings.Settings.Add("mssql_password", _connectionstringdto.password);
                    _Configuration.AppSettings.Settings.Add("mssql_port", _connectionstringdto.port);

                    _Configuration.Save();

                    System.Configuration.ConfigurationManager.RefreshSection("AppSettings");

                    logtodbutils(DBContract.mssql + " configurations persisted successfully.");

                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtncreatemssqldatabaseClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtcreatemssqldatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtcreatemssqldatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmssqldatasource.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "server name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("server name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqldatasource, "server name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmssqldatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqldatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmssqlusername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "user name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("user name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqlusername, "user name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmssqlpassword.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "password cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("password cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqlpassword, "password cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmssqlport.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "port cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("port cannot be null.", TAG));
                    errorProvider.SetError(txtsysmssqlport, "port cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    mssqlconnectionstringdto _connectionstringdto = new mssqlconnectionstringdto();
                    _connectionstringdto.datasource = txtsysmssqldatasource.Text;
                    _connectionstringdto.database = txtsysmssqldatabase.Text;
                    _connectionstringdto.userid = txtsysmssqlusername.Text;
                    _connectionstringdto.password = txtsysmssqlpassword.Text;
                    _connectionstringdto.port = txtsysmssqlport.Text;
                    _connectionstringdto.new_database_name = txtcreatemssqldatabase.Text;

                    responsedto _responsedto = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createdatabasegivenname(_connectionstringdto);

                    if (_responsedto.isresponseresultsuccessful)
                    {

                        logtodbutils(_responsedto.responsesuccessmessage);

                        responsedto _innerresponsedto = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createtables(_connectionstringdto);

                        if (_innerresponsedto.isresponseresultsuccessful)
                        {
                            logtodbutils(_innerresponsedto.responsesuccessmessage);
                        }
                        else
                        {
                            logtodbutils(_innerresponsedto.responseerrormessage);
                        }

                    }
                    else
                    {
                        logtodbutils(_responsedto.responseerrormessage);
                    }

                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtncheckmssqlconnectionClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtmssqlservername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "server name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("server name cannot be null.", TAG));
                    errorProvider.SetError(txtmssqlservername, "server name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtmssqldatabasename.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtmssqldatabasename, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtmssqlusername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "user name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("user name cannot be null.", TAG));
                    errorProvider.SetError(txtmssqlusername, "user name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtmssqlpassword.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "password cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("password cannot be null.", TAG));
                    errorProvider.SetError(txtmssqlpassword, "password cannot be null.");
                }
                if (String.IsNullOrEmpty(txtmssqlport.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "port cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("port cannot be null.", TAG));
                    errorProvider.SetError(txtmssqlport, "port cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    mssqlconnectionstringdto _connectionstringdto = new mssqlconnectionstringdto();
                    _connectionstringdto.datasource = txtmssqlservername.Text;
                    _connectionstringdto.database = txtmssqldatabasename.Text;
                    _connectionstringdto.userid = txtmssqlusername.Text;
                    _connectionstringdto.password = txtmssqlpassword.Text;
                    _connectionstringdto.port = txtmssqlport.Text;

                    responsedto _responsedto = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkconnectionasadmin(_connectionstringdto);

                    if (_responsedto.isresponseresultsuccessful)
                    {
                        logtodbutils(_responsedto.responsesuccessmessage);
                    }
                    else
                    {
                        logtodbutils(_responsedto.responseerrormessage);
                    }
                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtncreatemysqldatabaseClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtcreatemysqldatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtcreatemysqldatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmysqldatastore.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "host cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("host cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqldatastore, "host cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmysqldatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqldatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmysqlusername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "user name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("user name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqlusername, "user name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmysqlpassword.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "password cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("password cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqlpassword, "password cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmysqlport.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "port cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("port cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqlport, "port cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();
                    _connectionstringdto.datasource = txtsysmysqldatastore.Text;
                    _connectionstringdto.database = txtsysmysqldatabase.Text;
                    _connectionstringdto.userid = txtsysmysqlusername.Text;
                    _connectionstringdto.password = txtsysmysqlpassword.Text;
                    _connectionstringdto.port = txtsysmysqlport.Text;
                    _connectionstringdto.new_database_name = txtcreatemysqldatabase.Text;

                    responsedto _responsedto = mysqlapisingleton.getInstance(_notificationmessageEventname).createdatabasegivenname(_connectionstringdto);

                    if (_responsedto.isresponseresultsuccessful)
                    {

                        logtodbutils(_responsedto.responsesuccessmessage);

                        responsedto _innerresponsedto = mysqlapisingleton.getInstance(_notificationmessageEventname).createtables(_connectionstringdto);

                        if (_innerresponsedto.isresponseresultsuccessful)
                        {
                            logtodbutils(_innerresponsedto.responsesuccessmessage);
                        }
                        else
                        {
                            logtodbutils(_innerresponsedto.responseerrormessage);
                        }

                    }
                    else
                    {
                        logtodbutils(_responsedto.responseerrormessage);
                    }

                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtncheckmysqlconnectionClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtmysqlhostname.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "host cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("host cannot be null.", TAG));
                    errorProvider.SetError(txtmysqlhostname, "host cannot be null.");
                }
                if (String.IsNullOrEmpty(txtmysqldatabasename.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtmysqldatabasename, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtmysqlusername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "user name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("user name cannot be null.", TAG));
                    errorProvider.SetError(txtmysqlusername, "user name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtmysqlpassword.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "password cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("password cannot be null.", TAG));
                    errorProvider.SetError(txtmysqlpassword, "password cannot be null.");
                }
                if (String.IsNullOrEmpty(txtmysqlport.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "port cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("port cannot be null.", TAG));
                    errorProvider.SetError(txtmysqlport, "port cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();
                    _connectionstringdto.datasource = txtmysqlhostname.Text;
                    _connectionstringdto.database = txtmysqldatabasename.Text;
                    _connectionstringdto.userid = txtmysqlusername.Text;
                    _connectionstringdto.password = txtmysqlpassword.Text;
                    _connectionstringdto.port = txtmysqlport.Text;

                    responsedto _responsedto = mysqlapisingleton.getInstance(_notificationmessageEventname).checkconnectionasadmin(_connectionstringdto);

                    if (_responsedto.isresponseresultsuccessful)
                    {
                        logtodbutils(_responsedto.responsesuccessmessage);
                    }
                    else
                    {
                        logtodbutils(_responsedto.responseerrormessage);
                    }
                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnsavemysqlchangesClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                string _base_dir = Environment.CurrentDirectory;
                string _base_dir_with_filename = Application.ExecutablePath;
                string[] _path_levels_arr = _base_dir_with_filename.Split(Path.DirectorySeparatorChar);
                int _file_name_index_in_path = _path_levels_arr.Length - 1;
                string _exe_file_name = _path_levels_arr[_file_name_index_in_path];

                Configuration _Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(_base_dir_with_filename);

                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtsysmysqldatastore.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "host cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("host cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqldatastore, "host cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmysqldatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqldatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmysqlusername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "user name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("user name cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqlusername, "user name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmysqlpassword.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "password cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("password cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqlpassword, "password cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsysmysqlport.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "port cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("port cannot be null.", TAG));
                    errorProvider.SetError(txtsysmysqlport, "port cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();
                    _connectionstringdto.datasource = txtsysmysqldatastore.Text;
                    _connectionstringdto.database = txtsysmysqldatabase.Text;
                    _connectionstringdto.userid = txtsysmysqlusername.Text;
                    _connectionstringdto.password = txtsysmysqlpassword.Text;
                    _connectionstringdto.port = txtsysmysqlport.Text;

                    _Configuration.AppSettings.Settings.Remove("mysql_datasource");
                    _Configuration.AppSettings.Settings.Remove("mysql_database");
                    _Configuration.AppSettings.Settings.Remove("mysql_userid");
                    _Configuration.AppSettings.Settings.Remove("mysql_password");
                    _Configuration.AppSettings.Settings.Remove("mysql_port");

                    _Configuration.AppSettings.Settings.Add("mysql_datasource", _connectionstringdto.datasource);
                    _Configuration.AppSettings.Settings.Add("mysql_database", _connectionstringdto.database);
                    _Configuration.AppSettings.Settings.Add("mysql_userid", _connectionstringdto.userid);
                    _Configuration.AppSettings.Settings.Add("mysql_password", _connectionstringdto.password);
                    _Configuration.AppSettings.Settings.Add("mysql_port", _connectionstringdto.port);

                    _Configuration.Save();

                    logtodbutils(DBContract.mysql + " configurations persisted successfully.");

                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtncreatesqlitedatabaseClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtcreatesqlitedatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtcreatesqlitedatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqlitedbpath.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "path cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("path cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitedbpath, "path cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqlitedatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitedatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqliteversion.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "version cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("version cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqliteversion, "version cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqlitepooling.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "pooling cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("pooling cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitepooling, "pooling cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqlitefailifmissing.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "fail if missing cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("fail if missing cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitefailifmissing, "fail if missing cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqlitedbextension.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "extension cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("extension cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitedbextension, "extension cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    sqliteconnectionstringdto _connectionstringdto = new sqliteconnectionstringdto();
                    _connectionstringdto.datasource = txtsyssqlitedbpath.Text;
                    _connectionstringdto.sqlite_database_path = txtsyssqlitedbpath.Text;
                    _connectionstringdto.database = txtsyssqlitedatabase.Text;
                    _connectionstringdto.sqlite_version = txtsyssqliteversion.Text;
                    _connectionstringdto.sqlite_pooling = txtsyssqlitepooling.Text;
                    _connectionstringdto.sqlite_fail_if_missing = txtsyssqlitefailifmissing.Text;
                    _connectionstringdto.sqlite_db_extension = txtsyssqlitedbextension.Text;
                    _connectionstringdto.new_database_name = txtcreatesqlitedatabase.Text;

                    responsedto _responsedto = sqliteapisingleton.getInstance(_notificationmessageEventname).createdatabasegivenname(_connectionstringdto);

                    if (_responsedto.isresponseresultsuccessful)
                    {

                        logtodbutils(_responsedto.responsesuccessmessage);

                        responsedto _innerresponsedto = sqliteapisingleton.getInstance(_notificationmessageEventname).createtables(_connectionstringdto);

                        if (_innerresponsedto.isresponseresultsuccessful)
                        {
                            logtodbutils(_innerresponsedto.responsesuccessmessage);
                        }
                        else
                        {
                            logtodbutils(_innerresponsedto.responseerrormessage);
                        }

                    }
                    else
                    {
                        logtodbutils(_responsedto.responseerrormessage);
                    }

                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnchecksqliteconnectionClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtsqlitedbpath.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "path cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("path cannot be null.", TAG));
                    errorProvider.SetError(txtsqlitedbpath, "path cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsqlitedatabasename.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtsqlitedatabasename, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsqliteversion.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "version cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("version cannot be null.", TAG));
                    errorProvider.SetError(txtsqliteversion, "version cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsqlitepooling.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "pooling cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("pooling cannot be null.", TAG));
                    errorProvider.SetError(txtsqlitepooling, "pooling cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsqlitefailifmissing.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "fail if missing cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("fail if missing cannot be null.", TAG));
                    errorProvider.SetError(txtsqlitefailifmissing, "fail if missing cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsqlitedbextension.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "extension cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("extension cannot be null.", TAG));
                    errorProvider.SetError(txtsqlitedbextension, "extension cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    sqliteconnectionstringdto _connectionstringdto = new sqliteconnectionstringdto();
                    _connectionstringdto.datasource = txtsqlitedbpath.Text;
                    _connectionstringdto.sqlite_database_path = txtsqlitedbpath.Text;
                    _connectionstringdto.database = txtsqlitedatabasename.Text;
                    _connectionstringdto.sqlite_version = txtsqliteversion.Text;
                    _connectionstringdto.sqlite_pooling = txtsqlitepooling.Text;
                    _connectionstringdto.sqlite_fail_if_missing = txtsqlitefailifmissing.Text;
                    _connectionstringdto.sqlite_db_extension = txtsqlitedbextension.Text;

                    responsedto _responsedto = sqliteapisingleton.getInstance(_notificationmessageEventname).checkconnectionasadmin(_connectionstringdto, _databaseutilsnotificationeventname);

                    if (_responsedto.isresponseresultsuccessful)
                    {
                        logtodbutils(_responsedto.responsesuccessmessage);
                    }
                    else
                    {
                        logtodbutils(_responsedto.responseerrormessage);
                    }
                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnsavesqlitechangesClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                string _base_dir = Environment.CurrentDirectory;
                string _base_dir_with_filename = Application.ExecutablePath;
                string[] _path_levels_arr = _base_dir_with_filename.Split(Path.DirectorySeparatorChar);
                int _file_name_index_in_path = _path_levels_arr.Length - 1;
                string _exe_file_name = _path_levels_arr[_file_name_index_in_path];

                Configuration _Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(_base_dir_with_filename);

                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtsyssqlitedbpath.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "path cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("path cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitedbpath, "path cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqlitedatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitedatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqliteversion.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "version cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("version cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqliteversion, "version cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqlitepooling.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "pooling cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("pooling cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitepooling, "pooling cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqlitefailifmissing.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "fail if missing cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("fail if missing cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitefailifmissing, "fail if missing cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyssqlitedbextension.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "extension cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("extension cannot be null.", TAG));
                    errorProvider.SetError(txtsyssqlitedbextension, "extension cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    sqliteconnectionstringdto _connectionstringdto = new sqliteconnectionstringdto();
                    _connectionstringdto.datasource = txtsyssqlitedbpath.Text;
                    _connectionstringdto.sqlite_database_path = txtsyssqlitedbpath.Text;
                    _connectionstringdto.database = txtsyssqlitedatabase.Text;
                    _connectionstringdto.sqlite_version = txtsyssqliteversion.Text;
                    _connectionstringdto.sqlite_pooling = txtsyssqlitepooling.Text;
                    _connectionstringdto.sqlite_fail_if_missing = txtsyssqlitefailifmissing.Text;
                    _connectionstringdto.sqlite_db_extension = txtsyssqlitedbextension.Text;

                    _Configuration.AppSettings.Settings.Remove("sqlite_datasource");
                    _Configuration.AppSettings.Settings.Remove("sqlite_database_path");
                    _Configuration.AppSettings.Settings.Remove("sqlite_database");
                    _Configuration.AppSettings.Settings.Remove("sqlite_version");
                    _Configuration.AppSettings.Settings.Remove("sqlite_db_extension");
                    _Configuration.AppSettings.Settings.Remove("sqlite_pooling");
                    _Configuration.AppSettings.Settings.Remove("sqlite_fail_if_missing");

                    _Configuration.AppSettings.Settings.Add("sqlite_datasource", _connectionstringdto.datasource);
                    _Configuration.AppSettings.Settings.Add("sqlite_database_path", _connectionstringdto.sqlite_database_path);
                    _Configuration.AppSettings.Settings.Add("sqlite_database", _connectionstringdto.database);
                    _Configuration.AppSettings.Settings.Add("sqlite_version", _connectionstringdto.sqlite_version);
                    _Configuration.AppSettings.Settings.Add("sqlite_db_extension", _connectionstringdto.sqlite_db_extension);
                    _Configuration.AppSettings.Settings.Add("sqlite_pooling", _connectionstringdto.sqlite_pooling);
                    _Configuration.AppSettings.Settings.Add("sqlite_fail_if_missing", _connectionstringdto.sqlite_fail_if_missing);

                    _Configuration.Save();

                    logtodbutils(DBContract.sqlite + " configurations persisted successfully.");

                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtncreatepostgresqldatabaseClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtcreatepostgresqldatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtcreatepostgresqldatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyspostgresqldatastore.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "host cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("host cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqldatastore, "server name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyspostgresqldatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqldatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyspostgresqlusername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "user name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("user name cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqlusername, "user name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyspostgresqlpassword.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "password cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("password cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqlpassword, "password cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyspostgresqlport.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "port cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("port cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqlport, "port cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    postgresqlconnectionstringdto _connectionstringdto = new postgresqlconnectionstringdto();
                    _connectionstringdto.datasource = txtsyspostgresqldatastore.Text;
                    _connectionstringdto.database = txtsyspostgresqldatabase.Text;
                    _connectionstringdto.userid = txtsyspostgresqlusername.Text;
                    _connectionstringdto.password = txtsyspostgresqlpassword.Text;
                    _connectionstringdto.port = txtsyspostgresqlport.Text;
                    _connectionstringdto.new_database_name = txtcreatepostgresqldatabase.Text;

                    responsedto _responsedto = postgresqlapisingleton.getInstance(_notificationmessageEventname).createdatabasegivenname(_connectionstringdto);

                    if (_responsedto.isresponseresultsuccessful)
                    {

                        logtodbutils(_responsedto.responsesuccessmessage);

                        responsedto _innerresponsedto = postgresqlapisingleton.getInstance(_notificationmessageEventname).createtables(_connectionstringdto);

                        if (_innerresponsedto.isresponseresultsuccessful)
                        {
                            logtodbutils(_innerresponsedto.responsesuccessmessage);
                        }
                        else
                        {
                            logtodbutils(_innerresponsedto.responseerrormessage);
                        }

                    }
                    else
                    {
                        logtodbutils(_responsedto.responseerrormessage);
                    }

                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtncheckpostgresqlconnectionClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtpostgresqlhostname.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "host cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("host cannot be null.", TAG));
                    errorProvider.SetError(txtpostgresqlhostname, "host cannot be null.");
                }
                if (String.IsNullOrEmpty(txtpostgresqldatabasename.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtpostgresqldatabasename, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtpostgresqlusername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "user name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("user name cannot be null.", TAG));
                    errorProvider.SetError(txtpostgresqlusername, "user name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtpostgresqlpassword.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "password cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("password cannot be null.", TAG));
                    errorProvider.SetError(txtpostgresqlpassword, "password cannot be null.");
                }
                if (String.IsNullOrEmpty(txtpostgresqlport.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "port cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("port cannot be null.", TAG));
                    errorProvider.SetError(txtpostgresqlport, "port cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    postgresqlconnectionstringdto _connectionstringdto = new postgresqlconnectionstringdto();
                    _connectionstringdto.datasource = txtpostgresqlhostname.Text;
                    _connectionstringdto.database = txtpostgresqldatabasename.Text;
                    _connectionstringdto.userid = txtpostgresqlusername.Text;
                    _connectionstringdto.password = txtpostgresqlpassword.Text;
                    _connectionstringdto.port = txtpostgresqlport.Text;

                    responsedto _responsedto = postgresqlapisingleton.getInstance(_notificationmessageEventname).checkconnectionasadmin(_connectionstringdto);

                    if (_responsedto.isresponseresultsuccessful)
                    {
                        logtodbutils(_responsedto.responsesuccessmessage);
                    }
                    else
                    {
                        logtodbutils(_responsedto.responseerrormessage);
                    }
                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnsavepostgresqlchangesClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                string _base_dir = Environment.CurrentDirectory;
                string _base_dir_with_filename = Application.ExecutablePath;
                string[] _path_levels_arr = _base_dir_with_filename.Split(Path.DirectorySeparatorChar);
                int _file_name_index_in_path = _path_levels_arr.Length - 1;
                string _exe_file_name = _path_levels_arr[_file_name_index_in_path];

                Configuration _Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(_base_dir_with_filename);

                bool _isuserdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(txtsyspostgresqldatastore.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += "host cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("host cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqldatastore, "host cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyspostgresqldatabase.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("database name cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqldatabase, "database name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyspostgresqlusername.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "user name cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("user name cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqlusername, "user name cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyspostgresqlpassword.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "password cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("password cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqlpassword, "password cannot be null.");
                }
                if (String.IsNullOrEmpty(txtsyspostgresqlport.Text))
                {
                    _isuserdetailsvalid = false;
                    _errormsg += Environment.NewLine + "port cannot be null.";
                    _notificationmessageEventname.Invoke(sender, new notificationmessageEventArgs("port cannot be null.", TAG));
                    errorProvider.SetError(txtsyspostgresqlport, "port cannot be null.");
                }

                if (_isuserdetailsvalid)
                {

                    postgresqlconnectionstringdto _connectionstringdto = new postgresqlconnectionstringdto();
                    _connectionstringdto.datasource = txtsyspostgresqldatastore.Text;
                    _connectionstringdto.database = txtsyspostgresqldatabase.Text;
                    _connectionstringdto.userid = txtsyspostgresqlusername.Text;
                    _connectionstringdto.password = txtsyspostgresqlpassword.Text;
                    _connectionstringdto.port = txtsyspostgresqlport.Text;

                    _Configuration.AppSettings.Settings.Remove("postgresql_datasource");
                    _Configuration.AppSettings.Settings.Remove("postgresql_database");
                    _Configuration.AppSettings.Settings.Remove("postgresql_userid");
                    _Configuration.AppSettings.Settings.Remove("postgresql_password");
                    _Configuration.AppSettings.Settings.Remove("postgresql_port");

                    _Configuration.AppSettings.Settings.Add("postgresql_datasource", _connectionstringdto.datasource);
                    _Configuration.AppSettings.Settings.Add("postgresql_database", _connectionstringdto.database);
                    _Configuration.AppSettings.Settings.Add("postgresql_userid", _connectionstringdto.userid);
                    _Configuration.AppSettings.Settings.Add("postgresql_password", _connectionstringdto.password);
                    _Configuration.AppSettings.Settings.Add("postgresql_port", _connectionstringdto.port);

                    _Configuration.Save();

                    logtodbutils(DBContract.postgresql + " configurations persisted successfully.");

                }
                else
                {
                    logtodbutils(_errormsg);
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnloadmssqldatabasesClick(object sender, EventArgs e)
        {
            try
            {

                cbomssqldatabases.Items.Clear();

                smoapi _smoapi = new smoapi();
                List<string> server_databases = new List<string>();
                server_databases = _smoapi.getdatabases();

                if (server_databases == null) return;

                foreach (string _database_names_dto in server_databases)
                {
                    cbomssqldatabases.Items.Add(_database_names_dto);
                    logtodbutils("[ " + _database_names_dto + " ]");
                }

                if (server_databases.Count > 0) cbomssqldatabases.SelectedIndex = 0;

                logtodbutils("[ " + cbomssqldatabases.Items.Count + " ] databases found in mssql");

                lblmssqldbcount.Text = cbomssqldatabases.Items.Count.ToString();

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnupdatemssqldatabaseClick(object sender, EventArgs e)
        {
            try
            {
                //get selected database
                string selected_database = cbomssqldatabases.Text;

                errorProvider.Clear();
                bool _isclientdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(cbomssqldatabases.Text))
                {
                    _isclientdetailsvalid = false;
                    _errormsg += "database name cannot be null - mssql.";
                    errorProvider.SetError(cbomssqldatabases, "database name cannot be null - mssql.");
                }

                if (!_isclientdetailsvalid)
                {
                    logtodbutils(_errormsg);
                    return;
                }

                //use selected db in object
                mssqlconnectionstringdto _connectionstringdto = new mssqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mssql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mssql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mssql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mssql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mssql_port"];

                _connectionstringdto.new_database_name = selected_database;

                responsedto _responsedto = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createtables(_connectionstringdto);

                logtodbutils(_responsedto.responsesuccessmessage);
                logtodbutils(_responsedto.responseerrormessage);

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnloadsqlitedatabasesClick(object sender, EventArgs e)
        {
            try
            {

                cbosqlitedatabases.Items.Clear();

                string _base_dir = Environment.CurrentDirectory;
                Console.WriteLine("_base_dir " + _base_dir);

                string db_path = _base_dir + Path.DirectorySeparatorChar + "databases" + Path.DirectorySeparatorChar;
                Console.WriteLine("db_path " + db_path);

                var dbfileNames = Directory.GetFiles(db_path, "*.sqlite3").Select(name => new FileInfo(name).FullName).ToArray();

                foreach (var db_name in dbfileNames)
                {

                    string[] _path_levels_arr = db_name.Split(Path.DirectorySeparatorChar);
                    int _file_name_index_in_path = _path_levels_arr.Length - 1;
                    Console.WriteLine("_file_name_index_in_path " + _file_name_index_in_path);
                    string _file_name_with_extension = _path_levels_arr[_file_name_index_in_path];
                    Console.WriteLine("_file_name_with_extension " + _file_name_with_extension);

                    string[] file_arr = _file_name_with_extension.Split('.');

                    string _file_name_without_extension = file_arr[0];
                    Console.WriteLine("_file_name_without_extension " + _file_name_without_extension);

                    cbosqlitedatabases.Items.Add(_file_name_without_extension);
                    logtodbutils("[ " + _file_name_without_extension + " ]");
                }

                if (cbosqlitedatabases.Items.Count > 0) cbosqlitedatabases.SelectedIndex = 0;

                logtodbutils("[ " + cbosqlitedatabases.Items.Count + " ] databases found in sqlite");

                lblsqlitedbcount.Text = cbosqlitedatabases.Items.Count.ToString();

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnupdatesqlitedatabaseClick(object sender, EventArgs e)
        {
            try
            {
                //get selected database
                string selected_database = cbosqlitedatabases.Text;

                errorProvider.Clear();
                bool _isclientdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(cbosqlitedatabases.Text))
                {
                    _isclientdetailsvalid = false;
                    _errormsg += "database name cannot be null - sqlite.";
                    errorProvider.SetError(cbosqlitedatabases, "database name cannot be null - sqlite.");
                }

                if (!_isclientdetailsvalid)
                {
                    logtodbutils(_errormsg);
                    return;
                }

                //use slected db in object
                sqliteconnectionstringdto _connectionstringdto = new sqliteconnectionstringdto();

                _connectionstringdto.sqlite_database_path = System.Configuration.ConfigurationManager.AppSettings["sqlite_database_path"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["sqlite_database"];
                _connectionstringdto.sqlite_db_extension = System.Configuration.ConfigurationManager.AppSettings["sqlite_db_extension"];
                _connectionstringdto.sqlite_version = System.Configuration.ConfigurationManager.AppSettings["sqlite_version"];
                _connectionstringdto.sqlite_pooling = System.Configuration.ConfigurationManager.AppSettings["sqlite_pooling"];
                _connectionstringdto.sqlite_fail_if_missing = System.Configuration.ConfigurationManager.AppSettings["sqlite_fail_if_missing"];

                _connectionstringdto.new_database_name = selected_database;

                responsedto _responsedto = sqliteapisingleton.getInstance(_notificationmessageEventname).createtables(_connectionstringdto);

                logtodbutils(_responsedto.responsesuccessmessage);
                logtodbutils(_responsedto.responseerrormessage);

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnloadmysqldatabasesClick(object sender, EventArgs e)
        {
            try
            {

                cbomysqldatabases.Items.Clear();

                string CONNECTION_STRING = getmysqlconnectionstring();
                //string query = "SELECT * FROM information_schema.TABLES";
                string query = "SHOW databases";

                DataTable dt = getmysqldatabasesfromschema(query, CONNECTION_STRING);

                var _recordscount = dt.Rows.Count;

                for (int i = 0; i < _recordscount; i++)
                {

                    cbomysqldatabases.Items.Add(Convert.ToString(dt.Rows[i]["Database"]));
                    logtodbutils("[ " + dt.Rows[i]["Database"] + " ]");
                }

                if (cbomysqldatabases.Items.Count > 0) cbomysqldatabases.SelectedIndex = 0;

                logtodbutils("[ " + cbomysqldatabases.Items.Count + " ] databases found in mysql");

                lblmysqldbcount.Text = cbomysqldatabases.Items.Count.ToString();

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        private string getmysqlconnectionstring()
        {
            try
            {
                mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mysql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mysql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mysql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mysql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mysql_port"];

                string CONNECTION_STRING = buildmysqlconnectionstringfromobject(_connectionstringdto);

                return CONNECTION_STRING;

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
                return null;
            }
        }

        string buildmysqlconnectionstringfromobject(mysqlconnectionstringdto _connectionstringdto)
        {
            string CONNECTION_STRING = @"host=" + _connectionstringdto.datasource + ";" +
                "database=" + _connectionstringdto.database + ";" +
                "port=" + _connectionstringdto.port + ";" +
                "user=" + _connectionstringdto.userid + ";" +
                "password=" + _connectionstringdto.password;
            return CONNECTION_STRING;
        }

        public DataTable getmysqldatabasesfromschema(string query, string CONNECTION_STRING)
        {
            if (string.IsNullOrEmpty(query.Trim())) return null;

            using (var con = new MySqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (var cmd = new MySqlCommand(query, con))
                {
                    var da = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    return dt;
                }
            }
        }

        void BtnupdatemysqldatabaseClick(object sender, EventArgs e)
        {
            try
            {
                //get selected database
                string selected_database = cbomysqldatabases.Text;

                errorProvider.Clear();
                bool _isclientdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(cbomysqldatabases.Text))
                {
                    _isclientdetailsvalid = false;
                    _errormsg += "database name cannot be null - mysql.";
                    errorProvider.SetError(cbomysqldatabases, "database name cannot be null - mysql.");
                }

                if (!_isclientdetailsvalid)
                {
                    logtodbutils(_errormsg);
                    return;
                }

                //use slected db in object
                mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mysql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mysql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mysql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mysql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mysql_port"];

                _connectionstringdto.new_database_name = selected_database;

                responsedto _responsedto = mysqlapisingleton.getInstance(_notificationmessageEventname).createtables(_connectionstringdto);

                logtodbutils(_responsedto.responsesuccessmessage);
                logtodbutils(_responsedto.responseerrormessage);

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnloadpostgresqldatabasesClick(object sender, EventArgs e)
        {
            try
            {
                cbopostgresqldatabases.Items.Clear();

                string CONNECTION_STRING = getpostgresqlconnectionstring();

                string query = "SELECT * FROM pg_catalog.pg_database";

                DataTable dt = getpostgresqldatabasesfromschema(query, CONNECTION_STRING);

                var _recordscount = dt.Rows.Count;

                for (int i = 0; i < _recordscount; i++)
                {
                    //table_name, table_catalog, table_schema
                    cbopostgresqldatabases.Items.Add(Convert.ToString(dt.Rows[i]["datname"]));
                    logtodbutils("[ " + Convert.ToString(dt.Rows[i]["datname"]) + " ]");
                }

                if (cbopostgresqldatabases.Items.Count > 0) cbopostgresqldatabases.SelectedIndex = 0;

                logtodbutils("[ " + cbopostgresqldatabases.Items.Count + " ] databases found in postgresql");

                lblpostgresqldbcount.Text = cbopostgresqldatabases.Items.Count.ToString();

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        private string getpostgresqlconnectionstring()
        {
            try
            {
                postgresqlconnectionstringdto _connectionstringdto = new postgresqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];

                string CONNECTION_STRING = buildpostgresqlconnectionstringfromobject(_connectionstringdto);

                return CONNECTION_STRING;

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, TAG));
                return null;
            }
        }

        string buildpostgresqlconnectionstringfromobject(postgresqlconnectionstringdto _connectionstringdto)
        {
            string CONNECTION_STRING = @"Server=" + _connectionstringdto.datasource + ";" +
                "Database=" + _connectionstringdto.database + ";" +
                "Port=" + _connectionstringdto.port + ";" +
                "User Id=" + _connectionstringdto.userid + ";" +
                "Password=" + _connectionstringdto.password;
            return CONNECTION_STRING;
        }

        public DataTable getpostgresqldatabasesfromschema(string query, string CONNECTION_STRING)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;
            using (var con = new NpgsqlConnection(CONNECTION_STRING))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(query, con))
                {
                    var da = new NpgsqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    da.Dispose();
                    return dt;
                }
            }
        }

        void BtnupdatepostgresqldatabaseClick(object sender, EventArgs e)
        {
            try
            {
                //get selected database
                string selected_database = cbopostgresqldatabases.Text;

                errorProvider.Clear();
                bool _isclientdetailsvalid = true;
                string _errormsg = "";

                if (String.IsNullOrEmpty(cbopostgresqldatabases.Text))
                {
                    _isclientdetailsvalid = false;
                    _errormsg += "database name cannot be null - postgresql.";
                    errorProvider.SetError(cbopostgresqldatabases, "database name cannot be null - postgresql.");
                }

                if (!_isclientdetailsvalid)
                {
                    logtodbutils(_errormsg);
                    return;
                }

                //use slected db in object
                postgresqlconnectionstringdto _connectionstringdto = new postgresqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];

                _connectionstringdto.new_database_name = selected_database;

                responsedto _responsedto = postgresqlapisingleton.getInstance(_notificationmessageEventname).createtables(_connectionstringdto);

                logtodbutils(_responsedto.responsesuccessmessage);
                logtodbutils(_responsedto.responseerrormessage);

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnstartmysqlserverClick(object sender, EventArgs e)
        {
            try
            {

                string _xamp_control_panel_path = @txtxampserverpath.Text.Trim();

                var _process_info = Process.Start(_xamp_control_panel_path);

                logtodbutils(String.Format("successfully started process [ {0} ] with id [ {1} ] at [ {2} ] took [ {3} ] seconds.", _process_info.StartInfo.FileName, _process_info.Id, _process_info.StartTime, _process_info.TotalProcessorTime));

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        public void GetFormattedIpAddresses()
        {
            try
            {
                string formattedipaddresses = "";
                int adrresscounter = 0;
                IPAddress[] ipAddresses = Dns.GetHostAddresses(FQDN.GetFQDN()).Reverse().ToArray();
                foreach (var ip in ipAddresses)
                {
                    adrresscounter++;
                    formattedipaddresses += ip.ToString() + Environment.NewLine;
                }

                txtserveripaddress.Text = formattedipaddresses;
                logtodbutils(Environment.NewLine + formattedipaddresses);
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnexecutequeryClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isclientdetailsvalid = true;
                string _errormsg = "";

                logtodbutils("validating query...");

                if (String.IsNullOrEmpty(txtquery.Text.Trim()))
                {
                    _isclientdetailsvalid = false;
                    _errormsg += "query cannot be null.";
                    errorProvider.SetError(txtquery, "query cannot be null.");
                    txtquery.Focus();
                }

                if (String.IsNullOrEmpty(cboserverquery.Text))
                {
                    _isclientdetailsvalid = false;
                    _errormsg += Environment.NewLine + "select server.";
                    errorProvider.SetError(cboserverquery, "select server.");
                    cboserverquery.Focus();
                }

                if (String.IsNullOrEmpty(cbodatabasequery.Text.Trim()))
                {
                    _isclientdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database cannot be null.";
                    errorProvider.SetError(cbodatabasequery, "database cannot be null.");
                    cbodatabasequery.Focus();
                }

                if (!_isclientdetailsvalid)
                {
                    logtodbutils(_errormsg);
                    //msgboxform.Show(_errormsg, TAG, msgtype.error);
                    return;
                }

                string _current_query = txtquery.Text.Trim();

                switch (_current_query)
                {
                    case "tables":
                        logtodbutils("list of datastore entities...");
                        showtableslist();
                        break;
                    default:
                        logtodbutils("execute query task running...");
                        executecommandsgivenquery(_current_query);
                        break;
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void showtableslist()
        {
            string[] _tables_arr = new[] { "tblcrops", "tblcategories", "tblcropsdiseases", "tblcropsvarieites", "tblmanufactures", "tblpestsinsecticides", "tblsettings" };
            logtodbutils("no of entities [ " + _tables_arr.Length + " ].");

            for (int i = 0; i < _tables_arr.Length; i++)
            {
                logtodbutils((i + 1) + ". " + _tables_arr[i]);
            }

        }

        void executecommandsgivenquery(string _current_query)
        {
            try
            {
                string _connection_string = "";
                string _server_query = cboserverquery.Text.Trim();
                string _database_query = cbodatabasequery.Text.Trim();

                switch (_server_query)
                {
                    case "mssql":
                        try
                        {

                            //use selected db in object
                            mssqlconnectionstringdto _connectionstring_from_dto = getmssqlconnectionstringdto();
                            _connectionstring_from_dto.database = _database_query;
                            _connectionstring_from_dto.new_database_name = _database_query;

                            _connection_string = buildmssqlconnectionstringfromobject(_connectionstring_from_dto);

                            if (_current_query.StartsWith("select"))
                            {

                                DataTable dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).execute_select_query(_current_query, _connection_string);

                                logtablecontentsgivendatatable(dt);

                            }
                            else
                            {
                                int numberofrowsaffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).execute_data_manipulation_query(_current_query, _connection_string);
                                logtodbutils("numberofrowsaffected [ " + numberofrowsaffected + " ]");
                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "mysql":
                        try
                        {
                            //use selected db in object
                            mysqlconnectionstringdto _connectionstring_from_dto = getmysqlconnectionstringdto();
                            _connectionstring_from_dto.database = _database_query;
                            _connectionstring_from_dto.new_database_name = _database_query;

                            _connection_string = buildmysqlconnectionstringfromobject(_connectionstring_from_dto);

                            if (_current_query.StartsWith("select"))
                            {

                                DataTable dt = mysqlapisingleton.getInstance(_notificationmessageEventname).execute_select_query(_current_query, _connection_string);

                                logtablecontentsgivendatatable(dt);

                            }
                            else
                            {
                                int numberofrowsaffected = mysqlapisingleton.getInstance(_notificationmessageEventname).execute_data_manipulation_query(_current_query, _connection_string);
                                logtodbutils("numberofrowsaffected [ " + numberofrowsaffected + " ]");
                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "postgresql":
                        try
                        {
                            //use selected db in object
                            postgresqlconnectionstringdto _connectionstring_from_dto = getpostgresqlconnectionstringdto();
                            _connectionstring_from_dto.database = _database_query;
                            _connectionstring_from_dto.new_database_name = _database_query;

                            _connection_string = buildpostgresqlconnectionstringfromobject(_connectionstring_from_dto);

                            if (_current_query.StartsWith("select"))
                            {

                                DataTable dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).execute_select_query(_current_query, _connection_string);

                                logtablecontentsgivendatatable(dt);

                            }
                            else
                            {
                                int numberofrowsaffected = postgresqlapisingleton.getInstance(_notificationmessageEventname).execute_data_manipulation_query(_current_query, _connection_string);
                                logtodbutils("numberofrowsaffected [ " + numberofrowsaffected + " ]");
                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "sqlite":
                        try
                        {
                            //use selected db in object
                            sqliteconnectionstringdto _connectionstring_from_dto = getsqliteconnectionstringdto();
                            _connectionstring_from_dto.database = _database_query;
                            _connectionstring_from_dto.new_database_name = _database_query;

                            _connection_string = buildsqliteconnectionstringfromobject(_connectionstring_from_dto);

                            if (_current_query.StartsWith("select"))
                            {

                                DataTable dt = sqliteapisingleton.getInstance(_notificationmessageEventname).execute_select_query(_current_query, _connection_string);

                                logtablecontentsgivendatatable(dt);

                            }
                            else
                            {
                                int numberofrowsaffected = sqliteapisingleton.getInstance(_notificationmessageEventname).execute_data_manipulation_query(_current_query, _connection_string);
                                logtodbutils("numberofrowsaffected [ " + numberofrowsaffected + " ]");
                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void logtablecontentsgivendatatable(DataTable dt)
        {
            try
            {

                if (dt == null) return;

                var _recordscount = dt.Rows.Count;

                logtodbutils("[ " + _recordscount + " ] records found.");

                for (int i = 0; i < _recordscount; i++)
                {

                    if (dt.Columns.Contains("crop_name"))
                    {
                        cropdto _cropdto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdtogivendatatable(dt, i);
                        logtodbutils(_cropdto.ToString());
                    }
                    else if (dt.Columns.Contains("manufacturer_name"))
                    {
                        manufacturerdto _manufacturerdto = utilzsingleton.getInstance(_notificationmessageEventname).buildmanufacturerdtogivendatatable(dt, i);
                        logtodbutils(_manufacturerdto.ToString());
                    }
                    else if (dt.Columns.Contains("category_name"))
                    {
                        categorydto _categorydto = utilzsingleton.getInstance(_notificationmessageEventname).buildcategorydtogivendatatable(dt, i);
                        logtodbutils(_categorydto.ToString());
                    }
                    else if (dt.Columns.Contains("setting_name"))
                    {
                        settingdto _settingdto = utilzsingleton.getInstance(_notificationmessageEventname).buildsettingdtogivendatatable(dt, i);
                        logtodbutils(_settingdto.ToString());
                    }
                    else if (dt.Columns.Contains("crop_variety_name"))
                    {
                        cropvarietydto _cropvarietydto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropvarietydtogivendatatable(dt, i);
                        logtodbutils(_cropvarietydto.ToString());
                    }
                    else if (dt.Columns.Contains("crop_disease_name"))
                    {
                        cropdiseasedto _cropdiseasedto = utilzsingleton.getInstance(_notificationmessageEventname).buildcropdiseasedtogivendatatable(dt, i);
                        logtodbutils(_cropdiseasedto.ToString());
                    }
                    else if (dt.Columns.Contains("pestinsecticide_name"))
                    {
                        pestinsecticidedto _pestinsecticidedto = utilzsingleton.getInstance(_notificationmessageEventname).buildpestinsecticidedtogivendatatable(dt, i);
                        logtodbutils(_pestinsecticidedto.ToString());
                    }


                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtngetipaddressClick(object sender, EventArgs e)
        {
            try
            {
                GetFormattedIpAddresses();
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnsyncClick(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
                bool _isclientdetailsvalid = true;
                string _errormsg = "";

                logtodbutils("synch datastore task running...");

                if (String.IsNullOrEmpty(cbodatabasefrom.Text.Trim()))
                {
                    _isclientdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database from cannot be null.";
                    errorProvider.SetError(cbodatabasefrom, "database from cannot be null.");
                    cbodatabasefrom.Focus();
                }

                if (String.IsNullOrEmpty(cbodatabaseto.Text.Trim()))
                {
                    _isclientdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database to cannot be null.";
                    errorProvider.SetError(cbodatabaseto, "database to cannot be null.");
                    cbodatabaseto.Focus();
                }

                if (cboserverto.Text.Trim() == cboserverfrom.Text.Trim() && cbodatabaseto.Text.Trim() == cbodatabasefrom.Text.Trim())
                {
                    _isclientdetailsvalid = false;
                    _errormsg += Environment.NewLine + "database to cannot be equal to database from for the same server.";
                    errorProvider.SetError(cbodatabaseto, "database to cannot be equal to database from for the same server.");
                    cbodatabaseto.Focus();
                }

                if (!_isclientdetailsvalid)
                {
                    logtodbutils(_errormsg);
                    //msgboxform.Show(_errormsg, TAG, msgtype.error);
                    return;
                }

                dbsyncdto _dbsyncdto = new dbsyncdto();
                _dbsyncdto.serverfrom = cboserverfrom.Text.Trim();
                _dbsyncdto.databasefrom = cbodatabasefrom.Text.Trim();
                _dbsyncdto.serverto = cboserverto.Text.Trim();
                _dbsyncdto.databaseto = cbodatabaseto.Text.Trim();

                syncdatabasescore(_dbsyncdto);

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void syncdatabasescore(dbsyncdto _dbsyncdto)
        {
            try
            {
                string _server_from = _dbsyncdto.serverfrom;
                string _server_to = _dbsyncdto.serverto;
                string _server_connectionstring_from = "";
                string _server_connectionstring_to = "";

                switch (_server_from)
                {
                    case "mssql":
                        try
                        {

                            //use selected db in object
                            mssqlconnectionstringdto _connectionstring_from_dto = getmssqlconnectionstringdto();
                            _connectionstring_from_dto.database = _dbsyncdto.databasefrom;
                            _connectionstring_from_dto.new_database_name = _dbsyncdto.databasefrom;

                            _server_connectionstring_from = buildmssqlconnectionstringfromobject(_connectionstring_from_dto);

                            switch (_server_to)
                            {
                                case "mssql":
                                    try
                                    {

                                        //use selected db in object
                                        mssqlconnectionstringdto _connectionstring_to_dto = getmssqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildmssqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "mysql":
                                    try
                                    {
                                        //use selected db in object
                                        mysqlconnectionstringdto _connectionstring_to_dto = getmysqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildmysqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "postgresql":
                                    try
                                    {
                                        //use selected db in object
                                        postgresqlconnectionstringdto _connectionstring_to_dto = getpostgresqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildpostgresqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "sqlite":
                                    try
                                    {
                                        //use selected db in object
                                        sqliteconnectionstringdto _connectionstring_to_dto = getsqliteconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildsqliteconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "mysql":
                        try
                        {

                            //use selected db in object
                            mysqlconnectionstringdto _connectionstring_from_dto = getmysqlconnectionstringdto();
                            _connectionstring_from_dto.database = _dbsyncdto.databasefrom;
                            _connectionstring_from_dto.new_database_name = _dbsyncdto.databasefrom;

                            _server_connectionstring_from = buildmysqlconnectionstringfromobject(_connectionstring_from_dto);

                            switch (_server_to)
                            {
                                case "mssql":
                                    try
                                    {

                                        //use selected db in object
                                        mssqlconnectionstringdto _connectionstring_to_dto = getmssqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildmssqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "mysql":
                                    try
                                    {
                                        //use selected db in object
                                        mysqlconnectionstringdto _connectionstring_to_dto = getmysqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildmysqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "postgresql":
                                    try
                                    {
                                        //use selected db in object
                                        postgresqlconnectionstringdto _connectionstring_to_dto = getpostgresqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildpostgresqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "sqlite":
                                    try
                                    {
                                        //use selected db in object
                                        sqliteconnectionstringdto _connectionstring_to_dto = getsqliteconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildsqliteconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "postgresql":
                        try
                        {

                            //use selected db in object
                            postgresqlconnectionstringdto _connectionstring_from_dto = getpostgresqlconnectionstringdto();
                            _connectionstring_from_dto.database = _dbsyncdto.databasefrom;
                            _connectionstring_from_dto.new_database_name = _dbsyncdto.databasefrom;

                            _server_connectionstring_from = buildpostgresqlconnectionstringfromobject(_connectionstring_from_dto);

                            switch (_server_to)
                            {
                                case "mssql":
                                    try
                                    {

                                        //use selected db in object
                                        mssqlconnectionstringdto _connectionstring_to_dto = getmssqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildmssqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "mysql":
                                    try
                                    {
                                        //use selected db in object
                                        mysqlconnectionstringdto _connectionstring_to_dto = getmysqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildmysqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "postgresql":
                                    try
                                    {
                                        //use selected db in object
                                        postgresqlconnectionstringdto _connectionstring_to_dto = getpostgresqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildpostgresqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "sqlite":
                                    try
                                    {
                                        //use selected db in object
                                        sqliteconnectionstringdto _connectionstring_to_dto = getsqliteconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildsqliteconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "sqlite":
                        try
                        {

                            //use selected db in object
                            sqliteconnectionstringdto _connectionstring_from_dto = getsqliteconnectionstringdto();
                            _connectionstring_from_dto.database = _dbsyncdto.databasefrom;
                            _connectionstring_from_dto.new_database_name = _dbsyncdto.databasefrom;

                            _server_connectionstring_from = buildsqliteconnectionstringfromobject(_connectionstring_from_dto);

                            switch (_server_to)
                            {
                                case "mssql":
                                    try
                                    {

                                        //use selected db in object
                                        mssqlconnectionstringdto _connectionstring_to_dto = getmssqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildmssqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "mysql":
                                    try
                                    {
                                        //use selected db in object
                                        mysqlconnectionstringdto _connectionstring_to_dto = getmysqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildmysqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "postgresql":
                                    try
                                    {
                                        //use selected db in object
                                        postgresqlconnectionstringdto _connectionstring_to_dto = getpostgresqlconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildpostgresqlconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                                case "sqlite":
                                    try
                                    {
                                        //use selected db in object
                                        sqliteconnectionstringdto _connectionstring_to_dto = getsqliteconnectionstringdto();
                                        _connectionstring_to_dto.database = _dbsyncdto.databaseto;
                                        _connectionstring_to_dto.new_database_name = _dbsyncdto.databaseto;

                                        _server_connectionstring_to = buildsqliteconnectionstringfromobject(_connectionstring_to_dto);

                                        dotheactualsync(_server_connectionstring_to, _server_to);

                                    }
                                    catch (Exception ex)
                                    {
                                        logtodbutils(ex.Message);
                                    }
                                    break;
                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void dotheactualsync(string _server_connectionstring_to, string _server_to)
        {

            string[] _tables = DBContract.table_names_arr;
            int _entity_count = _tables.Length;
            Console.WriteLine("_entity_count [ " + _entity_count + " ]");
            int _task_count = 0;
            string query = "";
            DataTable dt;

            foreach (var _table in _tables)
            {

                switch (_table)
                {
                    case "tblcrops":
                        query = DBContract.CROPS_SELECT_ALL_QUERY;

                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);

                        if (dt != null && dt.Rows.Count != 0)
                        {

                            syncdatastoregivenconnectionstrings(dt, _server_connectionstring_to, _server_to, DBContract.cropsentitytable.CROPS_TABLE_NAME);

                        }
                        _task_count++;
                        break;
                    case "tblcropsvarieties":
                        query = DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY;

                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);

                        if (dt != null && dt.Rows.Count != 0)
                        {

                            syncdatastoregivenconnectionstrings(dt, _server_connectionstring_to, _server_to, DBContract.cropsvarietiesentitytable.CROPS_VARIETIES_TABLE_NAME);

                        }
                        _task_count++;
                        break;
                    case "tblcropsdiseases":
                        query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY;

                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);

                        if (dt != null && dt.Rows.Count != 0)
                        {

                            syncdatastoregivenconnectionstrings(dt, _server_connectionstring_to, _server_to, DBContract.cropsdiseasesentitytable.CROPS_DISEASES_TABLE_NAME);

                        }
                        _task_count++;
                        break;
                    case "tblmanufacturers":
                        query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY;

                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);

                        if (dt != null && dt.Rows.Count != 0)
                        {

                            syncdatastoregivenconnectionstrings(dt, _server_connectionstring_to, _server_to, DBContract.manufacturersentitytable.MANUFACTURERS_TABLE_NAME);

                        }
                        _task_count++;
                        break;
                    case "tblpestsinsecticides":
                        query = DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY;

                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);

                        if (dt != null && dt.Rows.Count != 0)
                        {

                            syncdatastoregivenconnectionstrings(dt, _server_connectionstring_to, _server_to, DBContract.pestsinsecticidesentitytable.PESTSINSECTICIDES_TABLE_NAME);

                        }
                        _task_count++;
                        break;
                    case "tblsettings":
                        query = DBContract.SETTINGS_SELECT_ALL_QUERY;

                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);

                        if (dt != null && dt.Rows.Count != 0)
                        {

                            syncdatastoregivenconnectionstrings(dt, _server_connectionstring_to, _server_to, DBContract.settingsentitytable.SETTINGS_TABLE_NAME);

                        }
                        _task_count++;
                        break;
                    case "tblcategories":
                        query = DBContract.CATEGORIES_SELECT_ALL_QUERY;

                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query);

                        if (dt != null && dt.Rows.Count != 0)
                        {

                            syncdatastoregivenconnectionstrings(dt, _server_connectionstring_to, _server_to, DBContract.categoriesentitytable.CATEGORIES_TABLE_NAME);

                        }
                        _task_count++;
                        break;

                }

            }

            Console.WriteLine("_task_count [ " + _task_count + " ]");

        }

        void syncdatastoregivenconnectionstrings(DataTable dt, string connection_string_to, string _server_to, string _current_table)
        {
            try
            {

                switch (_server_to)
                {
                    case "mssql":
                        try
                        {

                            pushdatatoreceivingdatastore(dt, _current_table, connection_string_to);

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "mysql":
                        try
                        {

                            pushdatatoreceivingdatastore(dt, _current_table, connection_string_to);

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "postgresql":
                        try
                        {

                            pushdatatoreceivingdatastore(dt, _current_table, connection_string_to);

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "sqlite":
                        try
                        {

                            pushdatatoreceivingdatastore(dt, _current_table, connection_string_to);

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void pushdatatoreceivingdatastore(DataTable dt, string _current_table, string connection_string_to)
        {

            try
            {
                string[] _tables = DBContract.table_names_arr;
                int _entity_count = _tables.Length;
                Console.WriteLine("_entity_count [ " + _entity_count + " ]");
                int _task_count = 0;

                int _recordscount = 0;
                int _insert_count = 0;
                int _exists_count = 0;

                string[] connection_string = connection_string_to.Split(';');

                switch (_current_table)
                {
                    case "tblcrops":

                        _recordscount = dt.Rows.Count;
                        _insert_count = 0;
                        _exists_count = 0;

                        for (int i = 0; i < _recordscount; i++)
                        {

                            cropdto _cropdto = new cropdto();
                            _cropdto.crop_id = Convert.ToString(dt.Rows[i]["crop_id"]);
                            _cropdto.crop_name = Convert.ToString(dt.Rows[i]["crop_name"]);
                            _cropdto.crop_status = Convert.ToString(dt.Rows[i]["crop_status"]);
                            _cropdto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);

                            bool _record_exists = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifcropexists(_cropdto.crop_name, connection_string_to);

                            if (_record_exists)
                            {
                                logtodbutils("crop with name [ " + _cropdto.crop_name + " ] exists.");
                                _exists_count++;
                                continue;
                            }
                            else
                            {

                                bool numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropindatabase(_cropdto, connection_string_to);

                                if (numberOfRowsAffected)
                                {
                                    logtodbutils("successfully inserted crop in mssql db { " +
                                    Environment.NewLine + "crop name: " + _cropdto.crop_name + "," +
                                    Environment.NewLine + "status: " + _cropdto.crop_status + " }.");
                                }

                                _progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));

                                _insert_count++;
                            }
                        }

                        logtodbutils("[ " + _recordscount + " ] crops found.");

                        logtodbutils("[ " + _exists_count + " ] crops exists.");

                        logtodbutils("[ " + _insert_count + " ] crops inserted.");

                        _task_count++;
                        break;
                    case "tblcropsvarieties":

                        _recordscount = dt.Rows.Count;
                        _insert_count = 0;
                        _exists_count = 0;

                        for (int i = 0; i < _recordscount; i++)
                        {

                            cropvarietydto _cropvarietydto = new cropvarietydto();
                            _cropvarietydto.crop_variety_id = Convert.ToString(dt.Rows[i]["crop_variety_id"]);
                            _cropvarietydto.crop_variety_name = Convert.ToString(dt.Rows[i]["crop_variety_name"]);
                            _cropvarietydto.crop_variety_status = Convert.ToString(dt.Rows[i]["crop_variety_status"]);
                            _cropvarietydto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);

                            bool _record_exists = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifcropvarietyexists(_cropvarietydto.crop_variety_name, connection_string_to);

                            if (_record_exists)
                            {
                                logtodbutils("crop variety with name [ " + _cropvarietydto.crop_variety_name + " ] exists.");
                                _exists_count++;
                                continue;
                            }
                            else
                            {

                                bool numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropvarietyindatabase(_cropvarietydto, connection_string_to);

                                if (numberOfRowsAffected)
                                {
                                    logtodbutils("successfully inserted crop variety in mssql db { " +
                                    Environment.NewLine + "crop variety name: " + _cropvarietydto.crop_variety_name + "," +
                                    Environment.NewLine + "status: " + _cropvarietydto.crop_variety_status + " }.");
                                }

                                _progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));

                                _insert_count++;
                            }
                        }

                        logtodbutils("[ " + _recordscount + " ] crops varieties found.");

                        logtodbutils("[ " + _exists_count + " ] crops varieties exists.");

                        logtodbutils("[ " + _insert_count + " ] crops varieties inserted.");

                        _task_count++;
                        break;
                    case "tblcropsdiseases":

                        _recordscount = dt.Rows.Count;
                        _insert_count = 0;
                        _exists_count = 0;

                        for (int i = 0; i < _recordscount; i++)
                        {

                            cropdiseasedto _cropdiseasedto = new cropdiseasedto();
                            _cropdiseasedto.crop_disease_id = Convert.ToString(dt.Rows[i]["crop_disease_id"]);
                            _cropdiseasedto.crop_disease_name = Convert.ToString(dt.Rows[i]["crop_disease_name"]);
                            _cropdiseasedto.crop_disease_category = Convert.ToString(dt.Rows[i]["crop_disease_category"]);
                            _cropdiseasedto.crop_disease_status = Convert.ToString(dt.Rows[i]["crop_disease_status"]);
                            _cropdiseasedto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);

                            bool _record_exists = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifdiseasepestexists(_cropdiseasedto.crop_disease_name, connection_string_to);

                            if (_record_exists)
                            {
                                logtodbutils("disease/pest with name [ " + _cropdiseasedto.crop_disease_name + " ] exists.");
                                _exists_count++;
                                continue;
                            }
                            else
                            {

                                bool numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcropdiseaseindatabase(_cropdiseasedto, connection_string_to);

                                if (numberOfRowsAffected)
                                {
                                    logtodbutils("successfully inserted disease/pest in mssql db { " +
                                    Environment.NewLine + "disease/pest name: " + _cropdiseasedto.crop_disease_name + "," +
                                    Environment.NewLine + "status: " + _cropdiseasedto.crop_disease_status + " }.");
                                }

                                _progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));

                                _insert_count++;
                            }
                        }

                        logtodbutils("[ " + _recordscount + " ] diseases/pests found.");

                        logtodbutils("[ " + _exists_count + " ] diseases/pests exists.");

                        logtodbutils("[ " + _insert_count + " ] diseases/pests inserted.");

                        _task_count++;
                        break;
                    case "tblmanufacturers":

                        _recordscount = dt.Rows.Count;
                        _insert_count = 0;
                        _exists_count = 0;

                        for (int i = 0; i < _recordscount; i++)
                        {

                            manufacturerdto _manufacturerdto = new manufacturerdto();
                            _manufacturerdto.manufacturer_id = Convert.ToString(dt.Rows[i]["manufacturer_id"]);
                            _manufacturerdto.manufacturer_name = Convert.ToString(dt.Rows[i]["manufacturer_name"]);
                            _manufacturerdto.manufacturer_status = Convert.ToString(dt.Rows[i]["manufacturer_status"]);
                            _manufacturerdto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);

                            bool _record_exists = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifmanufacturerexists(_manufacturerdto.manufacturer_name, connection_string_to);

                            if (_record_exists)
                            {
                                logtodbutils("manufacturer with name [ " + _manufacturerdto.manufacturer_name + " ] exists.");
                                _exists_count++;
                                continue;
                            }
                            else
                            {

                                bool numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createmanufacturerindatabase(_manufacturerdto, connection_string_to);

                                if (numberOfRowsAffected)
                                {
                                    logtodbutils("successfully inserted manufacturer in mssql db { " +
                                    Environment.NewLine + "manufacturer name: " + _manufacturerdto.manufacturer_name + "," +
                                    Environment.NewLine + "status: " + _manufacturerdto.manufacturer_status + " }.");
                                }

                                _progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));

                                _insert_count++;
                            }
                        }

                        logtodbutils("[ " + _recordscount + " ] manufacturers found.");

                        logtodbutils("[ " + _exists_count + " ] manufacturers exists.");

                        logtodbutils("[ " + _insert_count + " ] manufacturers inserted.");

                        _task_count++;
                        break;
                    case "tblpestsinsecticides":

                        _recordscount = dt.Rows.Count;
                        _insert_count = 0;
                        _exists_count = 0;

                        for (int i = 0; i < _recordscount; i++)
                        {

                            pestinsecticidedto _pestinsecticidedto = new pestinsecticidedto();
                            _pestinsecticidedto.pestinsecticide_id = Convert.ToString(dt.Rows[i]["pestinsecticide_id"]);
                            _pestinsecticidedto.pestinsecticide_name = Convert.ToString(dt.Rows[i]["pestinsecticide_name"]);
                            _pestinsecticidedto.pestinsecticide_category = Convert.ToString(dt.Rows[i]["pestinsecticide_category"]);
                            _pestinsecticidedto.pestinsecticide_crop_disease_id = Convert.ToString(dt.Rows[i]["pestinsecticide_crop_disease_id"]);
                            _pestinsecticidedto.pestinsecticide_manufacturer_id = Convert.ToString(dt.Rows[i]["pestinsecticide_manufacturer_id"]);
                            _pestinsecticidedto.pestinsecticide_status = Convert.ToString(dt.Rows[i]["pestinsecticide_status"]);
                            _pestinsecticidedto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);

                            bool _record_exists = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifcropexists(_pestinsecticidedto.pestinsecticide_name, connection_string_to);

                            if (_record_exists)
                            {
                                logtodbutils("pesticide/insecticide with name [ " + _pestinsecticidedto.pestinsecticide_name + " ] exists.");
                                _exists_count++;
                                continue;
                            }
                            else
                            {

                                bool numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createpestinsecticideindatabase(_pestinsecticidedto, connection_string_to);

                                if (numberOfRowsAffected)
                                {
                                    logtodbutils("successfully inserted pesticide/insecticide in mssql db { " +
                                    Environment.NewLine + "pesticide/insecticide name: " + _pestinsecticidedto.pestinsecticide_name + "," +
                                    Environment.NewLine + "status: " + _pestinsecticidedto.pestinsecticide_status + " }.");
                                }

                                _progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));

                                _insert_count++;
                            }
                        }

                        logtodbutils("[ " + _recordscount + " ] pesticides/insecticides found.");

                        logtodbutils("[ " + _exists_count + " ] pesticides/insecticides exists.");

                        logtodbutils("[ " + _insert_count + " ] pesticides/insecticides inserted.");

                        _task_count++;
                        break;
                    case "tblsettings":

                        _recordscount = dt.Rows.Count;
                        _insert_count = 0;
                        _exists_count = 0;

                        for (int i = 0; i < _recordscount; i++)
                        {

                            settingdto _settingdto = new settingdto();
                            _settingdto.setting_id = Convert.ToString(dt.Rows[i]["setting_id"]);
                            _settingdto.setting_name = Convert.ToString(dt.Rows[i]["setting_name"]);
                            _settingdto.setting_value = Convert.ToString(dt.Rows[i]["setting_value"]);
                            _settingdto.setting_status = Convert.ToString(dt.Rows[i]["setting_status"]);
                            _settingdto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);

                            bool _record_exists = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifsettingexists(_settingdto.setting_name, connection_string_to);

                            if (_record_exists)
                            {
                                logtodbutils("setting with name [ " + _settingdto.setting_name + " ] exists.");
                                _exists_count++;
                                continue;
                            }
                            else
                            {

                                bool numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createsettingindatabase(_settingdto, connection_string_to);

                                if (numberOfRowsAffected)
                                {
                                    logtodbutils("successfully inserted setting in mssql db { " +
                                    Environment.NewLine + "setting name: " + _settingdto.setting_name + "," +
                                    Environment.NewLine + "status: " + _settingdto.setting_status + " }.");
                                }

                                _progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));

                                _insert_count++;
                            }
                        }

                        logtodbutils("[ " + _recordscount + " ] settings found.");

                        logtodbutils("[ " + _exists_count + " ] settings exists.");

                        logtodbutils("[ " + _insert_count + " ] settings inserted.");

                        _task_count++;
                        break;
                    case "tblcategories":

                        _recordscount = dt.Rows.Count;
                        _insert_count = 0;
                        _exists_count = 0;

                        for (int i = 0; i < _recordscount; i++)
                        {

                            categorydto _categorydto = new categorydto();
                            _categorydto.category_id = Convert.ToString(dt.Rows[i]["category_id"]);
                            _categorydto.category_name = Convert.ToString(dt.Rows[i]["category_name"]);
                            _categorydto.category_status = Convert.ToString(dt.Rows[i]["category_status"]);
                            _categorydto.created_date = Convert.ToString(dt.Rows[i]["created_date"]);

                            bool _record_exists = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).checkifcategoryexists(_categorydto.category_name, connection_string_to);

                            if (_record_exists)
                            {
                                logtodbutils("category with name [ " + _categorydto.category_name + " ] exists.");
                                _exists_count++;
                                continue;
                            }
                            else
                            {

                                bool numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).createcategoryindatabase(_categorydto, connection_string_to);

                                if (numberOfRowsAffected)
                                {
                                    logtodbutils("successfully inserted category in mssql db { " +
                                    Environment.NewLine + "category name: " + _categorydto.category_name + "," +
                                    Environment.NewLine + "status: " + _categorydto.category_status + " }.");
                                }

                                _progressBarNotificationEventname.Invoke(this, new progressBarNotificationEventArgs(i, _recordscount));

                                _insert_count++;
                            }
                        }

                        logtodbutils("[ " + _recordscount + " ] categories found.");

                        logtodbutils("[ " + _exists_count + " ] categories exists.");

                        logtodbutils("[ " + _insert_count + " ] categories inserted.");

                        _task_count++;
                        break;

                }

                Console.WriteLine("_task_count [ " + _task_count + " ]");

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void CboserverquerySelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string _entity = cboserverquery.Text;

                lbldatabasequery.Text = "database";
                cbodatabasequery.Items.Clear();
                cbodatabasequery.Text = "";

                switch (_entity)
                {
                    case "mssql":
                        try
                        {

                            cbodatabasequery.Items.Clear();

                            smoapi _smoapi = new smoapi();
                            List<string> server_databases = new List<string>();
                            server_databases = _smoapi.getdatabases();

                            if (server_databases == null) return;

                            foreach (string _database_names_dto in server_databases)
                            {

                                cbodatabasequery.Items.Add(_database_names_dto);

                                logtodbutils("[ " + _database_names_dto + " ] ");

                            }

                            if (server_databases.Count > 0) cbodatabasequery.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabasequery.Items.Count + " ] databases found in mssql");

                            lbldatabasequery.Text = "database [ " + cbodatabasequery.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "mysql":
                        try
                        {
                            cbodatabasequery.Items.Clear();

                            string CONNECTION_STRING = getmysqlconnectionstring();

                            string query = "SHOW databases";

                            DataTable dt = getmysqldatabasesfromschema(query, CONNECTION_STRING);

                            var _recordscount = dt.Rows.Count;

                            for (int i = 0; i < _recordscount; i++)
                            {

                                cbodatabasequery.Items.Add(Convert.ToString(dt.Rows[i]["Database"]));
                                logtodbutils("[ " + Convert.ToString(dt.Rows[i]["Database"]) + " ] ");
                            }

                            if (cbodatabasequery.Items.Count > 0) cbodatabasequery.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabasequery.Items.Count + " ] databases found in mysql");

                            lbldatabasequery.Text = "database [ " + cbodatabasequery.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "postgresql":
                        try
                        {
                            cbodatabasequery.Items.Clear();

                            string CONNECTION_STRING = getpostgresqlconnectionstring();

                            string query = "SELECT * FROM pg_catalog.pg_database";

                            DataTable dt = getpostgresqldatabasesfromschema(query, CONNECTION_STRING);

                            var _recordscount = dt.Rows.Count;

                            for (int i = 0; i < _recordscount; i++)
                            {

                                cbodatabasequery.Items.Add(Convert.ToString(dt.Rows[i]["datname"]));
                                logtodbutils("[ " + Convert.ToString(dt.Rows[i]["datname"]) + " ] ");
                            }

                            if (cbodatabasequery.Items.Count > 0) cbodatabasequery.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabasequery.Items.Count + " ] databases found in postgresql");

                            lbldatabasequery.Text = "database [ " + cbodatabasequery.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "sqlite":
                        try
                        {
                            cbodatabasequery.Items.Clear();

                            string _base_dir = Environment.CurrentDirectory;
                            Console.WriteLine("_base_dir " + _base_dir);

                            string db_path = _base_dir + Path.DirectorySeparatorChar + "databases" + Path.DirectorySeparatorChar;
                            Console.WriteLine("db_path " + db_path);

                            var dbfileNames = Directory.GetFiles(db_path, "*.sqlite3").Select(name => new FileInfo(name).FullName).ToArray();

                            foreach (var db_name in dbfileNames)
                            {

                                string[] _path_levels_arr = db_name.Split(Path.DirectorySeparatorChar);
                                int _file_name_index_in_path = _path_levels_arr.Length - 1;
                                Console.WriteLine("_file_name_index_in_path " + _file_name_index_in_path);
                                string _file_name_with_extension = _path_levels_arr[_file_name_index_in_path];
                                Console.WriteLine("_file_name_with_extension " + _file_name_with_extension);

                                string[] file_arr = _file_name_with_extension.Split('.');

                                string _file_name_without_extension = file_arr[0];
                                Console.WriteLine("_file_name_without_extension " + _file_name_without_extension);

                                cbodatabasequery.Items.Add(_file_name_without_extension);
                                logtodbutils("[ " + _file_name_without_extension + " ] ");
                            }

                            if (cbodatabasequery.Items.Count > 0) cbodatabasequery.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabasequery.Items.Count + " ] databases found in sqlite");

                            lbldatabasequery.Text = "database [ " + cbodatabasequery.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void CboserverfromSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string _entity = cboserverfrom.Text;

                lbldatabasefrom.Text = "database from";
                cbodatabasefrom.Items.Clear();
                cbodatabasefrom.Text = "";

                switch (_entity)
                {
                    case "mssql":
                        try
                        {

                            cbodatabasefrom.Items.Clear();

                            smoapi _smoapi = new smoapi();
                            List<string> server_databases = new List<string>();
                            server_databases = _smoapi.getdatabases();

                            if (server_databases == null) return;

                            foreach (string _database_names_dto in server_databases)
                            {

                                cbodatabasefrom.Items.Add(_database_names_dto);

                            }

                            if (server_databases.Count > 0) cbodatabasefrom.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabasefrom.Items.Count + " ] databases found in mssql");

                            lbldatabasefrom.Text = "database [ " + cbodatabasefrom.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "mysql":
                        try
                        {
                            cbodatabasefrom.Items.Clear();

                            string CONNECTION_STRING = getmysqlconnectionstring();

                            string query = "SHOW databases";

                            DataTable dt = getmysqldatabasesfromschema(query, CONNECTION_STRING);

                            var _recordscount = dt.Rows.Count;

                            for (int i = 0; i < _recordscount; i++)
                            {

                                cbodatabasefrom.Items.Add(Convert.ToString(dt.Rows[i]["Database"]));

                            }

                            if (cbodatabasefrom.Items.Count > 0) cbodatabasefrom.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabasefrom.Items.Count + " ] databases found in mysql");

                            lbldatabasefrom.Text = "database [ " + cbodatabasefrom.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "postgresql":
                        try
                        {
                            cbodatabasefrom.Items.Clear();

                            string CONNECTION_STRING = getpostgresqlconnectionstring();

                            string query = "SELECT * FROM pg_catalog.pg_database";

                            DataTable dt = getpostgresqldatabasesfromschema(query, CONNECTION_STRING);

                            var _recordscount = dt.Rows.Count;

                            for (int i = 0; i < _recordscount; i++)
                            {

                                cbodatabasefrom.Items.Add(Convert.ToString(dt.Rows[i]["datname"]));

                            }

                            if (cbodatabasefrom.Items.Count > 0) cbodatabasefrom.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabasefrom.Items.Count + " ] databases found in postgresql");

                            lbldatabasefrom.Text = "database [ " + cbodatabasefrom.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "sqlite":
                        try
                        {
                            cbodatabasefrom.Items.Clear();

                            string _base_dir = Environment.CurrentDirectory;
                            Console.WriteLine("_base_dir " + _base_dir);

                            string db_path = _base_dir + Path.DirectorySeparatorChar + "databases" + Path.DirectorySeparatorChar;
                            Console.WriteLine("db_path " + db_path);

                            var dbfileNames = Directory.GetFiles(db_path, "*.sqlite3").Select(name => new FileInfo(name).FullName).ToArray();

                            foreach (var db_name in dbfileNames)
                            {

                                string[] _path_levels_arr = db_name.Split(Path.DirectorySeparatorChar);
                                int _file_name_index_in_path = _path_levels_arr.Length - 1;
                                Console.WriteLine("_file_name_index_in_path " + _file_name_index_in_path);
                                string _file_name_with_extension = _path_levels_arr[_file_name_index_in_path];
                                Console.WriteLine("_file_name_with_extension " + _file_name_with_extension);

                                string[] file_arr = _file_name_with_extension.Split('.');

                                string _file_name_without_extension = file_arr[0];
                                Console.WriteLine("_file_name_without_extension " + _file_name_without_extension);

                                cbodatabasefrom.Items.Add(_file_name_without_extension);

                            }

                            if (cbodatabasefrom.Items.Count > 0) cbodatabasefrom.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabasefrom.Items.Count + " ] databases found in sqlite");

                            lbldatabasefrom.Text = "database [ " + cbodatabasefrom.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void CboservertoSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string _entity = cboserverto.Text;

                lbldatabaseto.Text = "database to";
                cbodatabaseto.Items.Clear();
                cbodatabaseto.Text = "";

                switch (_entity)
                {
                    case "mssql":
                        try
                        {

                            cbodatabaseto.Items.Clear();

                            smoapi _smoapi = new smoapi();
                            List<string> server_databases = new List<string>();
                            server_databases = _smoapi.getdatabases();

                            if (server_databases == null) return;

                            foreach (string _database_names_dto in server_databases)
                            {

                                cbodatabaseto.Items.Add(_database_names_dto);
                                logtodbutils("[ " + _database_names_dto + " ] ");
                            }

                            if (server_databases.Count > 0) cbodatabaseto.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabaseto.Items.Count + " ] databases found in mssql");

                            lbldatabaseto.Text = "database [ " + cbodatabaseto.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "mysql":
                        try
                        {
                            cbodatabaseto.Items.Clear();

                            string CONNECTION_STRING = getmysqlconnectionstring();

                            string query = "SHOW databases";

                            DataTable dt = getmysqldatabasesfromschema(query, CONNECTION_STRING);

                            var _recordscount = dt.Rows.Count;

                            for (int i = 0; i < _recordscount; i++)
                            {

                                cbodatabaseto.Items.Add(Convert.ToString(dt.Rows[i]["Database"]));
                                logtodbutils("[ " + Convert.ToString(dt.Rows[i]["Database"]) + " ] ");
                            }

                            if (cbodatabaseto.Items.Count > 0) cbodatabaseto.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabaseto.Items.Count + " ] databases found in mysql");

                            lbldatabaseto.Text = "database [ " + cbodatabaseto.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "postgresql":
                        try
                        {
                            cbodatabaseto.Items.Clear();

                            string CONNECTION_STRING = getpostgresqlconnectionstring();

                            string query = "SELECT * FROM pg_catalog.pg_database";

                            DataTable dt = getpostgresqldatabasesfromschema(query, CONNECTION_STRING);

                            var _recordscount = dt.Rows.Count;

                            for (int i = 0; i < _recordscount; i++)
                            {

                                cbodatabaseto.Items.Add(Convert.ToString(dt.Rows[i]["datname"]));
                                logtodbutils("[ " + Convert.ToString(dt.Rows[i]["datname"]) + " ] ");
                            }

                            if (cbodatabaseto.Items.Count > 0) cbodatabaseto.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabaseto.Items.Count + " ] databases found in postgresql");

                            lbldatabaseto.Text = "database [ " + cbodatabaseto.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "sqlite":
                        try
                        {
                            cbodatabaseto.Items.Clear();

                            string _base_dir = Environment.CurrentDirectory;
                            Console.WriteLine("_base_dir " + _base_dir);

                            string db_path = _base_dir + Path.DirectorySeparatorChar + "databases" + Path.DirectorySeparatorChar;
                            Console.WriteLine("db_path " + db_path);

                            var dbfileNames = Directory.GetFiles(db_path, "*.sqlite3").Select(name => new FileInfo(name).FullName).ToArray();

                            foreach (var db_name in dbfileNames)
                            {

                                string[] _path_levels_arr = db_name.Split(Path.DirectorySeparatorChar);
                                int _file_name_index_in_path = _path_levels_arr.Length - 1;
                                Console.WriteLine("_file_name_index_in_path " + _file_name_index_in_path);
                                string _file_name_with_extension = _path_levels_arr[_file_name_index_in_path];
                                Console.WriteLine("_file_name_with_extension " + _file_name_with_extension);

                                string[] file_arr = _file_name_with_extension.Split('.');

                                string _file_name_without_extension = file_arr[0];
                                Console.WriteLine("_file_name_without_extension " + _file_name_without_extension);

                                cbodatabaseto.Items.Add(_file_name_without_extension);
                                logtodbutils("[ " + _file_name_without_extension + " ] ");
                            }

                            if (cbodatabaseto.Items.Count > 0) cbodatabaseto.SelectedIndex = 0;

                            logtodbutils("[ " + cbodatabaseto.Items.Count + " ] databases found in sqlite");

                            lbldatabaseto.Text = "database [ " + cbodatabaseto.Items.Count.ToString() + " ]";

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void populateservers()
        {
            try
            {
                string[] _entities = DBContract._entities;

                cboserverfrom.Items.AddRange(_entities);
                cboserverfrom.SelectedIndex = _entities.Length - 1;

                cboserverto.Items.AddRange(_entities);
                cboserverto.SelectedIndex = _entities.Length - 1;

                cboserverquery.Items.AddRange(_entities);
                cboserverquery.SelectedIndex = _entities.Length - 1;

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        mssqlconnectionstringdto getmssqlconnectionstringdto()
        {
            try
            {
                mssqlconnectionstringdto _connectionstringdto = new mssqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mssql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mssql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mssql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mssql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mssql_port"];

                return _connectionstringdto;

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
                return null;
            }
        }

        string buildmssqlconnectionstringfromobject(mssqlconnectionstringdto _connectionstringdto)
        {
            string CONNECTION_STRING = @"Data Source=" + _connectionstringdto.datasource + ";" +
                                        "Database=" + _connectionstringdto.database + ";" +
                                        "User Id=" + _connectionstringdto.userid + ";" +
                                        "Password=" + _connectionstringdto.password;
            return CONNECTION_STRING;
        }

        mysqlconnectionstringdto getmysqlconnectionstringdto()
        {
            try
            {
                mysqlconnectionstringdto _connectionstringdto = new mysqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mysql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mysql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mysql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mysql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mysql_port"];

                return _connectionstringdto;

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
                return null;
            }
        }

        postgresqlconnectionstringdto getpostgresqlconnectionstringdto()
        {
            try
            {
                postgresqlconnectionstringdto _connectionstringdto = new postgresqlconnectionstringdto();

                _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["postgresql_datasource"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["postgresql_database"];
                _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["postgresql_userid"];
                _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["postgresql_password"];
                _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["postgresql_port"];

                return _connectionstringdto;

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
                return null;
            }
        }

        sqliteconnectionstringdto getsqliteconnectionstringdto()
        {
            try
            {
                sqliteconnectionstringdto _connectionstringdto = new sqliteconnectionstringdto();

                _connectionstringdto.sqlite_database_path = System.Configuration.ConfigurationManager.AppSettings["sqlite_database_path"];
                _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["sqlite_database"];
                _connectionstringdto.sqlite_db_extension = System.Configuration.ConfigurationManager.AppSettings["sqlite_db_extension"];
                _connectionstringdto.sqlite_version = System.Configuration.ConfigurationManager.AppSettings["sqlite_version"];
                _connectionstringdto.sqlite_pooling = System.Configuration.ConfigurationManager.AppSettings["sqlite_pooling"];
                _connectionstringdto.sqlite_fail_if_missing = System.Configuration.ConfigurationManager.AppSettings["sqlite_fail_if_missing"];

                return _connectionstringdto;

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
                return null;
            }
        }

        string buildsqliteconnectionstringfromobject(sqliteconnectionstringdto _connectionstringdto)
        {
            string base_dir = Environment.CurrentDirectory;
            string database_dir = base_dir + _connectionstringdto.sqlite_database_path;
            string dbname = _connectionstringdto.database;
            string database_version = _connectionstringdto.sqlite_version;
            string db_extension = _connectionstringdto.sqlite_db_extension;
            dbname = dbname + "." + db_extension + database_version;

            if (!Directory.Exists(database_dir))
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite datastore path with name [ " + database_dir + " ] does not exist.", TAG));
            }
            else
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite datastore path with name [ " + _connectionstringdto.sqlite_database_path + " ] exist.", TAG));
            }

            string full_database_name_with_path = database_dir + dbname;
            string _secure_path_name_response = _connectionstringdto.sqlite_database_path + dbname;

            if (!File.Exists(full_database_name_with_path))
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite database with name [ " + _secure_path_name_response + " ] does not exist.", TAG));
            }
            else
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("sqlite database with name [ " + _secure_path_name_response + " ] exist.", TAG));
            }

            string CONNECTION_STRING = @"Data Source=" + full_database_name_with_path + ";" +
                                        "Version=" + _connectionstringdto.sqlite_version + ";" +
                                        "Pooling=" + _connectionstringdto.sqlite_pooling + ";" +
                                        "FailIfMissing=" + _connectionstringdto.sqlite_fail_if_missing;

            return CONNECTION_STRING;
        }

        void enumerate_entities_count(string _entity, string connection_string)
        {
            try
            {

                string[] _tables = DBContract.table_names_arr;
                int _entity_count = _tables.Length;
                Console.WriteLine("_entity_count [ " + _entity_count + " ]");
                int _task_count = 0;
                string query = "";
                DataTable dt;

                switch (_entity)
                {
                    case "mssql":
                        try
                        {

                            foreach (var _table in _tables)
                            {

                                switch (_table)
                                {
                                    case "tblcrops":
                                        query = DBContract.CROPS_SELECT_ALL_QUERY;

                                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] crops");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcropsvarieties":
                                        query = DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY;

                                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] crops varieties");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcropsdiseases":
                                        query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY;

                                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] diseases/pests");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblmanufacturers":
                                        query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY;

                                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] manufacturers");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblpestsinsecticides":
                                        query = DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY;

                                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] pesticides/insecticides");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblsettings":
                                        query = DBContract.SETTINGS_SELECT_ALL_QUERY;

                                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] settings");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcategories":
                                        query = DBContract.CATEGORIES_SELECT_ALL_QUERY;

                                        dt = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] categories");

                                        }
                                        _task_count++;
                                        break;

                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "mysql":
                        try
                        {

                            foreach (var _table in _tables)
                            {

                                switch (_table)
                                {
                                    case "tblcrops":
                                        query = DBContract.CROPS_SELECT_ALL_QUERY;

                                        dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] crops");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcropsvarieties":
                                        query = DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY;

                                        dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] crops varieties");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcropsdiseases":
                                        query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY;

                                        dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] diseases/pests");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblmanufacturers":
                                        query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY;

                                        dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] manufacturers");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblpestsinsecticides":
                                        query = DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY;

                                        dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] pesticides/insecticides");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblsettings":
                                        query = DBContract.SETTINGS_SELECT_ALL_QUERY;

                                        dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] settings");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcategories":
                                        query = DBContract.CATEGORIES_SELECT_ALL_QUERY;

                                        dt = mysqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] categories");

                                        }
                                        _task_count++;
                                        break;

                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "postgresql":
                        try
                        {

                            foreach (var _table in _tables)
                            {

                                switch (_table)
                                {
                                    case "tblcrops":
                                        query = DBContract.CROPS_SELECT_ALL_QUERY;

                                        dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] crops");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcropsvarieties":
                                        query = DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY;

                                        dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] crops varieties");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcropsdiseases":
                                        query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY;

                                        dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] diseases/pests");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblmanufacturers":
                                        query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY;

                                        dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] manufacturers");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblpestsinsecticides":
                                        query = DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY;

                                        dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] pesticides/insecticides");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblsettings":
                                        query = DBContract.SETTINGS_SELECT_ALL_QUERY;

                                        dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] settings");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcategories":
                                        query = DBContract.CATEGORIES_SELECT_ALL_QUERY;

                                        dt = postgresqlapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] categories");

                                        }
                                        _task_count++;
                                        break;

                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                    case "sqlite":
                        try
                        {

                            foreach (var _table in _tables)
                            {

                                switch (_table)
                                {
                                    case "tblcrops":
                                        query = DBContract.CROPS_SELECT_ALL_QUERY;

                                        dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] crops");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcropsvarieties":
                                        query = DBContract.CROPS_VARIETIES_SELECT_ALL_QUERY;

                                        dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] crops varieties");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcropsdiseases":
                                        query = DBContract.CROPS_DISEASES_SELECT_ALL_QUERY;

                                        dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] diseases/pests");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblmanufacturers":
                                        query = DBContract.MANUFACTURERS_SELECT_ALL_QUERY;

                                        dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] manufacturers");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblpestsinsecticides":
                                        query = DBContract.PESTSINSECTICIDES_SELECT_ALL_QUERY;

                                        dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] pesticides/insecticides");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblsettings":
                                        query = DBContract.SETTINGS_SELECT_ALL_QUERY;

                                        dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] settings");

                                        }
                                        _task_count++;
                                        break;
                                    case "tblcategories":
                                        query = DBContract.CATEGORIES_SELECT_ALL_QUERY;

                                        dt = sqliteapisingleton.getInstance(_notificationmessageEventname).getallrecordsglobal(query, connection_string);

                                        if (dt != null)
                                        {

                                            logtodbutils("[ " + dt.Rows.Count + " ] categories");

                                        }
                                        _task_count++;
                                        break;

                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            logtodbutils(ex.Message);
                        }
                        break;
                }


            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void CbodatabasequerySelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                string[] _entities = DBContract._entities;
                int _entity_count = _entities.Length;
                Console.WriteLine("_entity_count [ " + _entity_count + " ]");
                string _current_db = cbodatabasequery.Text.Trim();
                string connection_string = "";

                foreach (var _entity in _entities)
                {

                    switch (_entity)
                    {
                        case "mssql":

                            mssqlconnectionstringdto _mssql_connectionstring_to_dto = getmssqlconnectionstringdto();
                            _mssql_connectionstring_to_dto.database = _current_db;
                            _mssql_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildmssqlconnectionstringfromobject(_mssql_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                        case "mysql":

                            mysqlconnectionstringdto _mysql_connectionstring_to_dto = getmysqlconnectionstringdto();
                            _mysql_connectionstring_to_dto.database = _current_db;
                            _mysql_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildmysqlconnectionstringfromobject(_mysql_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                        case "postgresql":

                            postgresqlconnectionstringdto _postgresql_connectionstring_to_dto = getpostgresqlconnectionstringdto();
                            _postgresql_connectionstring_to_dto.database = _current_db;
                            _postgresql_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildpostgresqlconnectionstringfromobject(_postgresql_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                        case "sqlite":

                            sqliteconnectionstringdto _sqlite_connectionstring_to_dto = getsqliteconnectionstringdto();
                            _sqlite_connectionstring_to_dto.database = _current_db;
                            _sqlite_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildsqliteconnectionstringfromobject(_sqlite_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void CbodatabasefromSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] _entities = DBContract._entities;
                int _entity_count = _entities.Length;
                Console.WriteLine("_entity_count [ " + _entity_count + " ]");
                string _current_db = cbodatabasefrom.Text.Trim();
                string connection_string = "";

                foreach (var _entity in _entities)
                {

                    switch (_entity)
                    {
                        case "mssql":

                            mssqlconnectionstringdto _mssql_connectionstring_to_dto = getmssqlconnectionstringdto();
                            _mssql_connectionstring_to_dto.database = _current_db;
                            _mssql_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildmssqlconnectionstringfromobject(_mssql_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                        case "mysql":

                            mysqlconnectionstringdto _mysql_connectionstring_to_dto = getmysqlconnectionstringdto();
                            _mysql_connectionstring_to_dto.database = _current_db;
                            _mysql_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildmysqlconnectionstringfromobject(_mysql_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                        case "postgresql":

                            postgresqlconnectionstringdto _postgresql_connectionstring_to_dto = getpostgresqlconnectionstringdto();
                            _postgresql_connectionstring_to_dto.database = _current_db;
                            _postgresql_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildpostgresqlconnectionstringfromobject(_postgresql_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                        case "sqlite":

                            sqliteconnectionstringdto _sqlite_connectionstring_to_dto = getsqliteconnectionstringdto();
                            _sqlite_connectionstring_to_dto.database = _current_db;
                            _sqlite_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildsqliteconnectionstringfromobject(_sqlite_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void CbodatabasetoSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] _entities = DBContract._entities;
                int _entity_count = _entities.Length;
                Console.WriteLine("_entity_count [ " + _entity_count + " ]");
                string _current_db = cbodatabaseto.Text.Trim();
                string connection_string = "";

                foreach (var _entity in _entities)
                {

                    switch (_entity)
                    {
                        case "mssql":

                            mssqlconnectionstringdto _mssql_connectionstring_to_dto = getmssqlconnectionstringdto();
                            _mssql_connectionstring_to_dto.database = _current_db;
                            _mssql_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildmssqlconnectionstringfromobject(_mssql_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                        case "mysql":

                            mysqlconnectionstringdto _mysql_connectionstring_to_dto = getmysqlconnectionstringdto();
                            _mysql_connectionstring_to_dto.database = _current_db;
                            _mysql_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildmysqlconnectionstringfromobject(_mysql_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                        case "postgresql":

                            postgresqlconnectionstringdto _postgresql_connectionstring_to_dto = getpostgresqlconnectionstringdto();
                            _postgresql_connectionstring_to_dto.database = _current_db;
                            _postgresql_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildpostgresqlconnectionstringfromobject(_postgresql_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                        case "sqlite":

                            sqliteconnectionstringdto _sqlite_connectionstring_to_dto = getsqliteconnectionstringdto();
                            _sqlite_connectionstring_to_dto.database = _current_db;
                            _sqlite_connectionstring_to_dto.new_database_name = _current_db;

                            connection_string = buildsqliteconnectionstringfromobject(_sqlite_connectionstring_to_dto);

                            enumerate_entities_count(_entity, connection_string);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnstartexplorerClick(object sender, EventArgs e)
        {
            try
            {

                string _windows_explorer_path = @"C:\Windows\explorer.exe";

                var _process_info = Process.Start(_windows_explorer_path);

                logtodbutils(String.Format("successfully started process [ {0} ] with id [ {1} ] at [ {2} ] took [ {3} ] seconds.", _process_info.StartInfo.FileName, _process_info.Id, _process_info.StartTime, _process_info.TotalProcessorTime));

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnstartcommandlineinterfaceClick(object sender, EventArgs e)
        {
            try
            {

                string base_dir = Environment.CurrentDirectory;
                string process_name = "nthareneapp.exe";
                string full_process_name_with_path = base_dir + @"\" + process_name;

                string _process_path = @full_process_name_with_path;

                var _process_info = Process.Start(_process_path);

                logtodbutils(String.Format("successfully started process [ {0} ] with id [ {1} ] at [ {2} ] took [ {3} ] seconds.", _process_info.StartInfo.FileName, _process_info.Id, _process_info.StartTime, _process_info.TotalProcessorTime));

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnopenapplicationdirClick(object sender, EventArgs e)
        {
            try
            {

                string _windows_explorer_path = @"C:\Windows\explorer.exe";

                string base_dir = Environment.CurrentDirectory;

                var _process_info = Process.Start(_windows_explorer_path).StartInfo.WorkingDirectory = @base_dir;

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtnstartwebsiteClick(object sender, EventArgs e)
        {
            try
            {
                string base_dir = Environment.CurrentDirectory;
                string process_name = "nthareneapp.exe";
                string full_process_name_with_path = base_dir + @"\" + process_name;

                string _process_path = @full_process_name_with_path;

                var _process_info = Process.Start(_process_path);

                logtodbutils(String.Format("successfully started process [ {0} ] with id [ {1} ] at [ {2} ] took [ {3} ] seconds.", _process_info.StartInfo.FileName, _process_info.Id, _process_info.StartTime, _process_info.TotalProcessorTime));

            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtndeletemssqldatabaseClick(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                string _current_db = cbomssqldatabases.Text.Trim();

                if (String.IsNullOrEmpty(_current_db))
                {
                    logtodbutils("select database to delete");
                    errorProvider.SetError(cbomssqldatabases, "select database to delete");
                    return;
                }

                if (msgboxform.Show(String.Format("are you sure you want to delete database [ {0} ]", _current_db), TAG, msgtype.warn) == DialogResult.OK)
                {

                    string query = "DROP DATABASE " + _current_db;

                    mssqlconnectionstringdto _connectionstring_to_dto = getmssqlconnectionstringdto();

                    string _connection_string = buildmssqlconnectionstringfromobject(_connectionstring_to_dto);

                    int numberOfRowsAffected = mssqlapisingleton.getInstance(_notificationmessageEventname, _progressBarNotificationEventname).execute_data_manipulation_query(query, _connection_string);

                    if (numberOfRowsAffected == 7)
                    {
                        logtodbutils("successfully deleted database [ " + _current_db + " ] from server [ " + DBContract.mssql + " ]");

                        BtnloadmssqldatabasesClick(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtndeletepostgresqldatabaseClick(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                string _current_db = cbopostgresqldatabases.Text.Trim();

                if (String.IsNullOrEmpty(_current_db))
                {
                    logtodbutils("select database to delete");
                    errorProvider.SetError(cbopostgresqldatabases, "select database to delete");
                    return;
                }

                if (msgboxform.Show(String.Format("are you sure you want to delete database [ {0} ]", _current_db), TAG, msgtype.warn) == DialogResult.OK)
                {

                    string query = "DROP DATABASE " + _current_db;

                    postgresqlconnectionstringdto _connectionstring_to_dto = getpostgresqlconnectionstringdto();

                    string _connection_string = buildpostgresqlconnectionstringfromobject(_connectionstring_to_dto);

                    int numberOfRowsAffected = postgresqlapisingleton.getInstance(_notificationmessageEventname).execute_data_manipulation_query(query, _connection_string);

                    if (numberOfRowsAffected == 7)
                    {
                        logtodbutils("successfully deleted database [ " + _current_db + " ] from server [ " + DBContract.postgresql + " ]");

                        BtnloadpostgresqldatabasesClick(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtndeletemysqldatabaseClick(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                string _current_db = cbomysqldatabases.Text.Trim();

                if (String.IsNullOrEmpty(_current_db))
                {
                    logtodbutils("select database to delete");
                    errorProvider.SetError(cbomysqldatabases, "select database to delete");
                    return;
                }

                if (msgboxform.Show(String.Format("are you sure you want to delete database [ {0} ]", _current_db), TAG, msgtype.warn) == DialogResult.OK)
                {

                    string query = "DROP DATABASE " + _current_db;

                    mysqlconnectionstringdto _connectionstring_to_dto = getmysqlconnectionstringdto();

                    string _connection_string = buildmysqlconnectionstringfromobject(_connectionstring_to_dto);

                    int numberOfRowsAffected = mysqlapisingleton.getInstance(_notificationmessageEventname).execute_data_manipulation_query(query, _connection_string);

                    if (numberOfRowsAffected == 7)
                    {
                        logtodbutils("successfully deleted database [ " + _current_db + " ] from server [ " + DBContract.mysql + " ]");

                        BtnloadmysqldatabasesClick(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }

        void BtndeletesqlitedatabaseClick(object sender, EventArgs e)
        {
            errorProvider.Clear();
            try
            {
                string _current_db = cbosqlitedatabases.Text.Trim();

                if (String.IsNullOrEmpty(_current_db))
                {
                    logtodbutils("select database to delete");
                    errorProvider.SetError(cbosqlitedatabases, "select database to delete");
                    return;
                }

                if (msgboxform.Show(String.Format("are you sure you want to delete database [ {0} ]", _current_db), TAG, msgtype.warn) == DialogResult.OK)
                {

                    sqliteconnectionstringdto _sqliteconnectionstringdto = getsqliteconnectionstringdto();

                    string query = "DROP DATABASE " + _current_db;

                    sqliteconnectionstringdto _connectionstring_to_dto = sqliteapisingleton.getInstance(_notificationmessageEventname).getsqliteconnectionstringdto();

                    string _connection_string = buildsqliteconnectionstringfromobject(_connectionstring_to_dto);

                    int numberOfRowsAffected = sqliteapisingleton.getInstance(_notificationmessageEventname).execute_data_manipulation_query(query, _connection_string);

                    if (numberOfRowsAffected == 7)
                    {
                        logtodbutils("successfully deleted database [ " + _current_db + " ] from server [ " + DBContract.sqlite + " ]");

                        BtnloadsqlitedatabasesClick(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                logtodbutils(ex.Message);
            }
        }


        void process_files_in_background_worker()
        {
            if (background_worker_singleton.getInstance().get_is_backgroud_worker_running())
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("BackgroundWorker already running." + Environment.NewLine + "please wait for the worker to finish current task...", TAG));

                MessageBox.Show("BackgroundWorker already running." + Environment.NewLine + "please wait for the worker to finish current task...", "BackgroundWorker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            //reset progress controls
              
            //This allows the BackgroundWorker to be cancelled in between tasks
            bgWorker.WorkerSupportsCancellation = true;
            //This allows the worker to report progress between completion of tasks...
            //this must also be used in conjunction with the ProgressChanged event
            bgWorker.WorkerReportsProgress = true;

            //this assigns event handlers for the backgroundWorker
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.RunWorkerCompleted += bgWorker_WorkComplete;
            /* When you wish to have something occur when a change in progress
                occurs, (like the completion of a specific task) the "ProgressChanged"
                event handler is used. Note that ProgressChanged events may be invoked
                by calls to bgWorker.ReportProgress(...) only if bgWorker.WorkerReportsProgress
                is set to true. */
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;

            //tell the backgroundWorker to raise the "DoWork" event, thus starting it.
            //Check to make sure the background worker is not already running.
            if (!bgWorker.IsBusy)
                bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //this is the method that the backgroundworker will perform on in the background thread without blocking the UI.
            /* One thing to note! A try catch is not necessary as any exceptions will terminate the
            backgroundWorker and report
            the error to the "RunWorkerCompleted" event */

            background_worker_singleton.getInstance().set_is_backgroud_worker_running(true);

            //generate_playlist_for_all_media_types();
        }

        /*This is how the ProgressChanged event method signature looks like:*/
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Things to be done when a progress change has been reported
            /* The ProgressChangedEventArgs gives access to a percentage,
            allowing for easy reporting of how far along a process is*/
            int progress = e.ProgressPercentage;
        }

        private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {

            background_worker_singleton.getInstance().set_is_backgroud_worker_running(false);

            //e.Error will contain any exceptions caught by the backgroundWorker
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "BackgroundWorker", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(e.Error.Message, TAG));
            }
            else
            {
                MessageBox.Show("Task Complete!", "BackgroundWorker", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("Task Complete!", TAG));
            }
        }

         

    }


    public static class FQDN
    {
        public static string GetFQDN()
        {
            string domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            string hostName = System.Net.Dns.GetHostName();
            string fqdn = "";
            if (!hostName.Contains(domainName))
                fqdn = hostName + "." + domainName;
            else
                fqdn = hostName;
            return fqdn;
        }
    }


}







