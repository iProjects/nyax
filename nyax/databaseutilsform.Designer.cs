/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 10/13/2018
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nyax
{
	partial class databaseutilsform
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(databaseutilsform));
            this.tabControlutils = new System.Windows.Forms.TabControl();
            this.tabPagemssql = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtsysmssqlport = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnsavemssqlchanges = new System.Windows.Forms.Button();
            this.txtsysmssqlusername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtsysmssqlpassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsysmssqldatabase = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtsysmssqldatasource = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtmssqlport = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.btncheckmssqlconnection = new System.Windows.Forms.Button();
            this.txtmssqldatabasename = new System.Windows.Forms.TextBox();
            this.btncreatemssqldatabase = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcreatemssqldatabase = new System.Windows.Forms.TextBox();
            this.txtmssqlpassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmssqlusername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmssqlservername = new System.Windows.Forms.TextBox();
            this.tabPagemysql = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.txtxampserverpath = new System.Windows.Forms.TextBox();
            this.btnstartmysqlserver = new System.Windows.Forms.Button();
            this.txtsysmysqlport = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnsavemysqlchanges = new System.Windows.Forms.Button();
            this.txtsysmysqlusername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtsysmysqlpassword = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtsysmysqldatabase = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtsysmysqldatastore = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtmysqlport = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.btncheckmysqlconnection = new System.Windows.Forms.Button();
            this.txtmysqldatabasename = new System.Windows.Forms.TextBox();
            this.btncreatemysqldatabase = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtcreatemysqldatabase = new System.Windows.Forms.TextBox();
            this.txtmysqlpassword = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtmysqlusername = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtmysqlhostname = new System.Windows.Forms.TextBox();
            this.tabPagesqlite = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtsyssqlitedbextension = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtsyssqlitefailifmissing = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnsavesqlitechanges = new System.Windows.Forms.Button();
            this.txtsyssqliteversion = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtsyssqlitepooling = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtsyssqlitedatabase = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtsyssqlitedbpath = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.txtsqlitedbextension = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtsqlitefailifmissing = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.btnchecksqliteconnection = new System.Windows.Forms.Button();
            this.txtsqlitedatabasename = new System.Windows.Forms.TextBox();
            this.btncreatesqlitedatabase = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.txtcreatesqlitedatabase = new System.Windows.Forms.TextBox();
            this.txtsqlitepooling = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtsqliteversion = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtsqlitedbpath = new System.Windows.Forms.TextBox();
            this.tabPagepostgresql = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtsyspostgresqlport = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.btnsavepostgresqlchanges = new System.Windows.Forms.Button();
            this.txtsyspostgresqlusername = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtsyspostgresqlpassword = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtsyspostgresqldatabase = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtsyspostgresqldatastore = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.txtpostgresqlport = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.btncheckpostgresqlconnection = new System.Windows.Forms.Button();
            this.txtpostgresqldatabasename = new System.Windows.Forms.TextBox();
            this.btncreatepostgresqldatabase = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.txtcreatepostgresqldatabase = new System.Windows.Forms.TextBox();
            this.txtpostgresqlpassword = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtpostgresqlusername = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtpostgresqlhostname = new System.Windows.Forms.TextBox();
            this.tabPageupdateschemas = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btndeletesqlitedatabase = new System.Windows.Forms.Button();
            this.lblsqlitedbcount = new System.Windows.Forms.Label();
            this.btnupdatesqlitedatabase = new System.Windows.Forms.Button();
            this.cbosqlitedatabases = new System.Windows.Forms.ComboBox();
            this.btnloadsqlitedatabases = new System.Windows.Forms.Button();
            this.label50 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.btndeletepostgresqldatabase = new System.Windows.Forms.Button();
            this.lblpostgresqldbcount = new System.Windows.Forms.Label();
            this.btnupdatepostgresqldatabase = new System.Windows.Forms.Button();
            this.cbopostgresqldatabases = new System.Windows.Forms.ComboBox();
            this.btnloadpostgresqldatabases = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btndeletemysqldatabase = new System.Windows.Forms.Button();
            this.lblmysqldbcount = new System.Windows.Forms.Label();
            this.btnupdatemysqldatabase = new System.Windows.Forms.Button();
            this.cbomysqldatabases = new System.Windows.Forms.ComboBox();
            this.btnloadmysqldatabases = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btndeletemssqldatabase = new System.Windows.Forms.Button();
            this.lblmssqldbcount = new System.Windows.Forms.Label();
            this.btnupdatemssqldatabase = new System.Windows.Forms.Button();
            this.cbomssqldatabases = new System.Windows.Forms.ComboBox();
            this.btnloadmssqldatabases = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.tabPageutils = new System.Windows.Forms.TabPage();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.txtserveripaddress = new System.Windows.Forms.TextBox();
            this.btngetipaddress = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.btnsync = new System.Windows.Forms.Button();
            this.lbldatabaseto = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.cboserverto = new System.Windows.Forms.ComboBox();
            this.cbodatabaseto = new System.Windows.Forms.ComboBox();
            this.lbldatabasefrom = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.cboserverfrom = new System.Windows.Forms.ComboBox();
            this.cbodatabasefrom = new System.Windows.Forms.ComboBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btnexecutequery = new System.Windows.Forms.Button();
            this.lbldatabasequery = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.cboserverquery = new System.Windows.Forms.ComboBox();
            this.cbodatabasequery = new System.Windows.Forms.ComboBox();
            this.txtquery = new System.Windows.Forms.TextBox();
            this.tabPagetools = new System.Windows.Forms.TabPage();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.btnstartwebsite = new System.Windows.Forms.Button();
            this.btnopenapplicationdir = new System.Windows.Forms.Button();
            this.btnstartcommandlineinterface = new System.Windows.Forms.Button();
            this.btnstartexplorer = new System.Windows.Forms.Button();
            this.tabimageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtlog = new System.Windows.Forms.TextBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.progressBardbutils = new System.Windows.Forms.ProgressBar();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.tabControlutils.SuspendLayout();
            this.tabPagemssql.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPagemysql.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPagesqlite.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tabPagepostgresql.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPageupdateschemas.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.tabPageutils.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.tabPagetools.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox25.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlutils
            // 
            this.tabControlutils.Controls.Add(this.tabPagemssql);
            this.tabControlutils.Controls.Add(this.tabPagemysql);
            this.tabControlutils.Controls.Add(this.tabPagesqlite);
            this.tabControlutils.Controls.Add(this.tabPagepostgresql);
            this.tabControlutils.Controls.Add(this.tabPageupdateschemas);
            this.tabControlutils.Controls.Add(this.tabPageutils);
            this.tabControlutils.Controls.Add(this.tabPagetools);
            this.tabControlutils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlutils.ImageList = this.tabimageList;
            this.tabControlutils.Location = new System.Drawing.Point(3, 16);
            this.tabControlutils.Name = "tabControlutils";
            this.tabControlutils.SelectedIndex = 0;
            this.tabControlutils.Size = new System.Drawing.Size(552, 352);
            this.tabControlutils.TabIndex = 0;
            // 
            // tabPagemssql
            // 
            this.tabPagemssql.Controls.Add(this.groupBox3);
            this.tabPagemssql.ImageIndex = 0;
            this.tabPagemssql.Location = new System.Drawing.Point(4, 23);
            this.tabPagemssql.Name = "tabPagemssql";
            this.tabPagemssql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagemssql.Size = new System.Drawing.Size(544, 325);
            this.tabPagemssql.TabIndex = 0;
            this.tabPagemssql.Text = "mssql";
            this.tabPagemssql.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(538, 319);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "mssql";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtsysmssqlport);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.btnsavemssqlchanges);
            this.groupBox8.Controls.Add(this.txtsysmssqlusername);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.txtsysmssqlpassword);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.txtsysmssqldatabase);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.txtsysmssqldatasource);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(260, 16);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(275, 300);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "system defaults";
            // 
            // txtsysmssqlport
            // 
            this.txtsysmssqlport.Location = new System.Drawing.Point(81, 165);
            this.txtsysmssqlport.Name = "txtsysmssqlport";
            this.txtsysmssqlport.Size = new System.Drawing.Size(164, 20);
            this.txtsysmssqlport.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(46, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "port";
            // 
            // btnsavemssqlchanges
            // 
            this.btnsavemssqlchanges.BackColor = System.Drawing.SystemColors.Control;
            this.btnsavemssqlchanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsavemssqlchanges.ForeColor = System.Drawing.Color.Black;
            this.btnsavemssqlchanges.Image = ((System.Drawing.Image)(resources.GetObject("btnsavemssqlchanges.Image")));
            this.btnsavemssqlchanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsavemssqlchanges.Location = new System.Drawing.Point(81, 195);
            this.btnsavemssqlchanges.Name = "btnsavemssqlchanges";
            this.btnsavemssqlchanges.Size = new System.Drawing.Size(102, 28);
            this.btnsavemssqlchanges.TabIndex = 5;
            this.btnsavemssqlchanges.Text = "save changes";
            this.btnsavemssqlchanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsavemssqlchanges.UseVisualStyleBackColor = false;
            this.btnsavemssqlchanges.Click += new System.EventHandler(this.BtnsavemssqlchangesClick);
            // 
            // txtsysmssqlusername
            // 
            this.txtsysmssqlusername.Location = new System.Drawing.Point(81, 113);
            this.txtsysmssqlusername.Name = "txtsysmssqlusername";
            this.txtsysmssqlusername.Size = new System.Drawing.Size(164, 20);
            this.txtsysmssqlusername.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "username";
            // 
            // txtsysmssqlpassword
            // 
            this.txtsysmssqlpassword.Location = new System.Drawing.Point(81, 139);
            this.txtsysmssqlpassword.Name = "txtsysmssqlpassword";
            this.txtsysmssqlpassword.PasswordChar = '*';
            this.txtsysmssqlpassword.Size = new System.Drawing.Size(164, 20);
            this.txtsysmssqlpassword.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(18, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "password";
            // 
            // txtsysmssqldatabase
            // 
            this.txtsysmssqldatabase.Location = new System.Drawing.Point(81, 87);
            this.txtsysmssqldatabase.Name = "txtsysmssqldatabase";
            this.txtsysmssqldatabase.Size = new System.Drawing.Size(164, 20);
            this.txtsysmssqldatabase.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(38, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "server";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(18, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "database";
            // 
            // txtsysmssqldatasource
            // 
            this.txtsysmssqldatasource.Location = new System.Drawing.Point(81, 61);
            this.txtsysmssqldatasource.Name = "txtsysmssqldatasource";
            this.txtsysmssqldatasource.Size = new System.Drawing.Size(164, 20);
            this.txtsysmssqldatasource.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtmssqlport);
            this.groupBox7.Controls.Add(this.label43);
            this.groupBox7.Controls.Add(this.btncheckmssqlconnection);
            this.groupBox7.Controls.Add(this.txtmssqldatabasename);
            this.groupBox7.Controls.Add(this.btncreatemssqldatabase);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.txtcreatemssqldatabase);
            this.groupBox7.Controls.Add(this.txtmssqlpassword);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.txtmssqlusername);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txtmssqlservername);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(3, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(257, 300);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // txtmssqlport
            // 
            this.txtmssqlport.Location = new System.Drawing.Point(71, 228);
            this.txtmssqlport.Name = "txtmssqlport";
            this.txtmssqlport.Size = new System.Drawing.Size(168, 20);
            this.txtmssqlport.TabIndex = 6;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(36, 231);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 20);
            this.label43.TabIndex = 30;
            this.label43.Text = "port";
            // 
            // btncheckmssqlconnection
            // 
            this.btncheckmssqlconnection.BackColor = System.Drawing.SystemColors.Control;
            this.btncheckmssqlconnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncheckmssqlconnection.ForeColor = System.Drawing.Color.Black;
            this.btncheckmssqlconnection.Image = ((System.Drawing.Image)(resources.GetObject("btncheckmssqlconnection.Image")));
            this.btncheckmssqlconnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncheckmssqlconnection.Location = new System.Drawing.Point(71, 255);
            this.btncheckmssqlconnection.Name = "btncheckmssqlconnection";
            this.btncheckmssqlconnection.Size = new System.Drawing.Size(135, 37);
            this.btncheckmssqlconnection.TabIndex = 7;
            this.btncheckmssqlconnection.Text = "check connection";
            this.btncheckmssqlconnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncheckmssqlconnection.UseVisualStyleBackColor = false;
            this.btncheckmssqlconnection.Click += new System.EventHandler(this.BtncheckmssqlconnectionClick);
            // 
            // txtmssqldatabasename
            // 
            this.txtmssqldatabasename.Location = new System.Drawing.Point(71, 150);
            this.txtmssqldatabasename.Name = "txtmssqldatabasename";
            this.txtmssqldatabasename.Size = new System.Drawing.Size(168, 20);
            this.txtmssqldatabasename.TabIndex = 3;
            // 
            // btncreatemssqldatabase
            // 
            this.btncreatemssqldatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btncreatemssqldatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncreatemssqldatabase.ForeColor = System.Drawing.Color.Black;
            this.btncreatemssqldatabase.Image = ((System.Drawing.Image)(resources.GetObject("btncreatemssqldatabase.Image")));
            this.btncreatemssqldatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncreatemssqldatabase.Location = new System.Drawing.Point(71, 72);
            this.btncreatemssqldatabase.Name = "btncreatemssqldatabase";
            this.btncreatemssqldatabase.Size = new System.Drawing.Size(114, 28);
            this.btncreatemssqldatabase.TabIndex = 1;
            this.btncreatemssqldatabase.Text = "create database";
            this.btncreatemssqldatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncreatemssqldatabase.UseVisualStyleBackColor = false;
            this.btncreatemssqldatabase.Click += new System.EventHandler(this.BtncreatemssqldatabaseClick);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "database";
            // 
            // txtcreatemssqldatabase
            // 
            this.txtcreatemssqldatabase.Location = new System.Drawing.Point(71, 46);
            this.txtcreatemssqldatabase.Name = "txtcreatemssqldatabase";
            this.txtcreatemssqldatabase.Size = new System.Drawing.Size(168, 20);
            this.txtcreatemssqldatabase.TabIndex = 0;
            // 
            // txtmssqlpassword
            // 
            this.txtmssqlpassword.Location = new System.Drawing.Point(71, 202);
            this.txtmssqlpassword.Name = "txtmssqlpassword";
            this.txtmssqlpassword.PasswordChar = '*';
            this.txtmssqlpassword.Size = new System.Drawing.Size(168, 20);
            this.txtmssqlpassword.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "password";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(71, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "database name";
            // 
            // txtmssqlusername
            // 
            this.txtmssqlusername.Location = new System.Drawing.Point(71, 176);
            this.txtmssqlusername.Name = "txtmssqlusername";
            this.txtmssqlusername.Size = new System.Drawing.Size(168, 20);
            this.txtmssqlusername.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "server";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "username";
            // 
            // txtmssqlservername
            // 
            this.txtmssqlservername.Location = new System.Drawing.Point(71, 124);
            this.txtmssqlservername.Name = "txtmssqlservername";
            this.txtmssqlservername.Size = new System.Drawing.Size(168, 20);
            this.txtmssqlservername.TabIndex = 2;
            // 
            // tabPagemysql
            // 
            this.tabPagemysql.Controls.Add(this.groupBox4);
            this.tabPagemysql.ImageIndex = 1;
            this.tabPagemysql.Location = new System.Drawing.Point(4, 23);
            this.tabPagemysql.Name = "tabPagemysql";
            this.tabPagemysql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagemysql.Size = new System.Drawing.Size(544, 325);
            this.tabPagemysql.TabIndex = 1;
            this.tabPagemysql.Text = "mysql";
            this.tabPagemysql.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox10);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(538, 319);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "mysql";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox22);
            this.groupBox9.Controls.Add(this.txtsysmysqlport);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.btnsavemysqlchanges);
            this.groupBox9.Controls.Add(this.txtsysmysqlusername);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.txtsysmysqlpassword);
            this.groupBox9.Controls.Add(this.label13);
            this.groupBox9.Controls.Add(this.txtsysmysqldatabase);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.txtsysmysqldatastore);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox9.Location = new System.Drawing.Point(260, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(275, 300);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "system defaults";
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.txtxampserverpath);
            this.groupBox22.Controls.Add(this.btnstartmysqlserver);
            this.groupBox22.Location = new System.Drawing.Point(6, 205);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(263, 88);
            this.groupBox22.TabIndex = 28;
            this.groupBox22.TabStop = false;
            // 
            // txtxampserverpath
            // 
            this.txtxampserverpath.BackColor = System.Drawing.Color.Black;
            this.txtxampserverpath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtxampserverpath.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtxampserverpath.ForeColor = System.Drawing.Color.Lime;
            this.txtxampserverpath.Location = new System.Drawing.Point(84, 16);
            this.txtxampserverpath.Multiline = true;
            this.txtxampserverpath.Name = "txtxampserverpath";
            this.txtxampserverpath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtxampserverpath.Size = new System.Drawing.Size(176, 69);
            this.txtxampserverpath.TabIndex = 28;
            // 
            // btnstartmysqlserver
            // 
            this.btnstartmysqlserver.BackColor = System.Drawing.SystemColors.Control;
            this.btnstartmysqlserver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstartmysqlserver.ForeColor = System.Drawing.Color.Black;
            this.btnstartmysqlserver.Image = ((System.Drawing.Image)(resources.GetObject("btnstartmysqlserver.Image")));
            this.btnstartmysqlserver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnstartmysqlserver.Location = new System.Drawing.Point(12, 14);
            this.btnstartmysqlserver.Name = "btnstartmysqlserver";
            this.btnstartmysqlserver.Size = new System.Drawing.Size(66, 68);
            this.btnstartmysqlserver.TabIndex = 27;
            this.btnstartmysqlserver.Text = "start mysql server";
            this.btnstartmysqlserver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnstartmysqlserver.UseVisualStyleBackColor = false;
            this.btnstartmysqlserver.Click += new System.EventHandler(this.BtnstartmysqlserverClick);
            // 
            // txtsysmysqlport
            // 
            this.txtsysmysqlport.Location = new System.Drawing.Point(81, 131);
            this.txtsysmysqlport.Name = "txtsysmysqlport";
            this.txtsysmysqlport.Size = new System.Drawing.Size(164, 20);
            this.txtsysmysqlport.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(46, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "port";
            // 
            // btnsavemysqlchanges
            // 
            this.btnsavemysqlchanges.BackColor = System.Drawing.SystemColors.Control;
            this.btnsavemysqlchanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsavemysqlchanges.ForeColor = System.Drawing.Color.Black;
            this.btnsavemysqlchanges.Image = ((System.Drawing.Image)(resources.GetObject("btnsavemysqlchanges.Image")));
            this.btnsavemysqlchanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsavemysqlchanges.Location = new System.Drawing.Point(81, 161);
            this.btnsavemysqlchanges.Name = "btnsavemysqlchanges";
            this.btnsavemysqlchanges.Size = new System.Drawing.Size(102, 28);
            this.btnsavemysqlchanges.TabIndex = 5;
            this.btnsavemysqlchanges.Text = "save changes";
            this.btnsavemysqlchanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsavemysqlchanges.UseVisualStyleBackColor = false;
            this.btnsavemysqlchanges.Click += new System.EventHandler(this.BtnsavemysqlchangesClick);
            // 
            // txtsysmysqlusername
            // 
            this.txtsysmysqlusername.Location = new System.Drawing.Point(81, 79);
            this.txtsysmysqlusername.Name = "txtsysmysqlusername";
            this.txtsysmysqlusername.Size = new System.Drawing.Size(164, 20);
            this.txtsysmysqlusername.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(18, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "username";
            // 
            // txtsysmysqlpassword
            // 
            this.txtsysmysqlpassword.Location = new System.Drawing.Point(81, 105);
            this.txtsysmysqlpassword.Name = "txtsysmysqlpassword";
            this.txtsysmysqlpassword.PasswordChar = '*';
            this.txtsysmysqlpassword.Size = new System.Drawing.Size(164, 20);
            this.txtsysmysqlpassword.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(18, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 17);
            this.label13.TabIndex = 20;
            this.label13.Text = "password";
            // 
            // txtsysmysqldatabase
            // 
            this.txtsysmysqldatabase.Location = new System.Drawing.Point(81, 53);
            this.txtsysmysqldatabase.Name = "txtsysmysqldatabase";
            this.txtsysmysqldatabase.Size = new System.Drawing.Size(164, 20);
            this.txtsysmysqldatabase.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(46, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 23);
            this.label14.TabIndex = 16;
            this.label14.Text = "host";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(18, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 20);
            this.label15.TabIndex = 18;
            this.label15.Text = "database";
            // 
            // txtsysmysqldatastore
            // 
            this.txtsysmysqldatastore.Location = new System.Drawing.Point(81, 27);
            this.txtsysmysqldatastore.Name = "txtsysmysqldatastore";
            this.txtsysmysqldatastore.Size = new System.Drawing.Size(164, 20);
            this.txtsysmysqldatastore.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtmysqlport);
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Controls.Add(this.btncheckmysqlconnection);
            this.groupBox10.Controls.Add(this.txtmysqldatabasename);
            this.groupBox10.Controls.Add(this.btncreatemysqldatabase);
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Controls.Add(this.txtcreatemysqldatabase);
            this.groupBox10.Controls.Add(this.txtmysqlpassword);
            this.groupBox10.Controls.Add(this.label17);
            this.groupBox10.Controls.Add(this.label18);
            this.groupBox10.Controls.Add(this.txtmysqlusername);
            this.groupBox10.Controls.Add(this.label19);
            this.groupBox10.Controls.Add(this.label20);
            this.groupBox10.Controls.Add(this.txtmysqlhostname);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox10.Location = new System.Drawing.Point(3, 16);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(257, 300);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            // 
            // txtmysqlport
            // 
            this.txtmysqlport.Location = new System.Drawing.Point(71, 231);
            this.txtmysqlport.Name = "txtmysqlport";
            this.txtmysqlport.Size = new System.Drawing.Size(168, 20);
            this.txtmysqlport.TabIndex = 6;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(36, 234);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(29, 20);
            this.label42.TabIndex = 28;
            this.label42.Text = "port";
            // 
            // btncheckmysqlconnection
            // 
            this.btncheckmysqlconnection.BackColor = System.Drawing.SystemColors.Control;
            this.btncheckmysqlconnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncheckmysqlconnection.ForeColor = System.Drawing.Color.Black;
            this.btncheckmysqlconnection.Image = ((System.Drawing.Image)(resources.GetObject("btncheckmysqlconnection.Image")));
            this.btncheckmysqlconnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncheckmysqlconnection.Location = new System.Drawing.Point(71, 257);
            this.btncheckmysqlconnection.Name = "btncheckmysqlconnection";
            this.btncheckmysqlconnection.Size = new System.Drawing.Size(135, 37);
            this.btncheckmysqlconnection.TabIndex = 7;
            this.btncheckmysqlconnection.Text = "check connection";
            this.btncheckmysqlconnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncheckmysqlconnection.UseVisualStyleBackColor = false;
            this.btncheckmysqlconnection.Click += new System.EventHandler(this.BtncheckmysqlconnectionClick);
            // 
            // txtmysqldatabasename
            // 
            this.txtmysqldatabasename.Location = new System.Drawing.Point(71, 153);
            this.txtmysqldatabasename.Name = "txtmysqldatabasename";
            this.txtmysqldatabasename.Size = new System.Drawing.Size(168, 20);
            this.txtmysqldatabasename.TabIndex = 3;
            // 
            // btncreatemysqldatabase
            // 
            this.btncreatemysqldatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btncreatemysqldatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncreatemysqldatabase.ForeColor = System.Drawing.Color.Black;
            this.btncreatemysqldatabase.Image = ((System.Drawing.Image)(resources.GetObject("btncreatemysqldatabase.Image")));
            this.btncreatemysqldatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncreatemysqldatabase.Location = new System.Drawing.Point(71, 72);
            this.btncreatemysqldatabase.Name = "btncreatemysqldatabase";
            this.btncreatemysqldatabase.Size = new System.Drawing.Size(114, 28);
            this.btncreatemysqldatabase.TabIndex = 1;
            this.btncreatemysqldatabase.Text = "create database";
            this.btncreatemysqldatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncreatemysqldatabase.UseVisualStyleBackColor = false;
            this.btncreatemysqldatabase.Click += new System.EventHandler(this.BtncreatemysqldatabaseClick);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 20);
            this.label16.TabIndex = 14;
            this.label16.Text = "database";
            // 
            // txtcreatemysqldatabase
            // 
            this.txtcreatemysqldatabase.Location = new System.Drawing.Point(71, 46);
            this.txtcreatemysqldatabase.Name = "txtcreatemysqldatabase";
            this.txtcreatemysqldatabase.Size = new System.Drawing.Size(168, 20);
            this.txtcreatemysqldatabase.TabIndex = 0;
            // 
            // txtmysqlpassword
            // 
            this.txtmysqlpassword.Location = new System.Drawing.Point(71, 205);
            this.txtmysqlpassword.Name = "txtmysqlpassword";
            this.txtmysqlpassword.PasswordChar = '*';
            this.txtmysqlpassword.Size = new System.Drawing.Size(168, 20);
            this.txtmysqlpassword.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 206);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 17);
            this.label17.TabIndex = 12;
            this.label17.Text = "password";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(71, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 23);
            this.label18.TabIndex = 1;
            this.label18.Text = "database name";
            // 
            // txtmysqlusername
            // 
            this.txtmysqlusername.Location = new System.Drawing.Point(71, 179);
            this.txtmysqlusername.Name = "txtmysqlusername";
            this.txtmysqlusername.Size = new System.Drawing.Size(168, 20);
            this.txtmysqlusername.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(26, 124);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 23);
            this.label19.TabIndex = 1;
            this.label19.Text = "host";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 179);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 20);
            this.label20.TabIndex = 10;
            this.label20.Text = "username";
            // 
            // txtmysqlhostname
            // 
            this.txtmysqlhostname.Location = new System.Drawing.Point(71, 127);
            this.txtmysqlhostname.Name = "txtmysqlhostname";
            this.txtmysqlhostname.Size = new System.Drawing.Size(168, 20);
            this.txtmysqlhostname.TabIndex = 2;
            // 
            // tabPagesqlite
            // 
            this.tabPagesqlite.Controls.Add(this.groupBox5);
            this.tabPagesqlite.ImageIndex = 2;
            this.tabPagesqlite.Location = new System.Drawing.Point(4, 23);
            this.tabPagesqlite.Name = "tabPagesqlite";
            this.tabPagesqlite.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagesqlite.Size = new System.Drawing.Size(544, 325);
            this.tabPagesqlite.TabIndex = 2;
            this.tabPagesqlite.Text = "sqlite";
            this.tabPagesqlite.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox11);
            this.groupBox5.Controls.Add(this.groupBox12);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(538, 319);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "sqlite";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtsyssqlitedbextension);
            this.groupBox11.Controls.Add(this.label46);
            this.groupBox11.Controls.Add(this.txtsyssqlitefailifmissing);
            this.groupBox11.Controls.Add(this.label21);
            this.groupBox11.Controls.Add(this.btnsavesqlitechanges);
            this.groupBox11.Controls.Add(this.txtsyssqliteversion);
            this.groupBox11.Controls.Add(this.label22);
            this.groupBox11.Controls.Add(this.txtsyssqlitepooling);
            this.groupBox11.Controls.Add(this.label23);
            this.groupBox11.Controls.Add(this.txtsyssqlitedatabase);
            this.groupBox11.Controls.Add(this.label24);
            this.groupBox11.Controls.Add(this.label25);
            this.groupBox11.Controls.Add(this.txtsyssqlitedbpath);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(260, 16);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(275, 300);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "system defaults";
            // 
            // txtsyssqlitedbextension
            // 
            this.txtsyssqlitedbextension.Location = new System.Drawing.Point(81, 191);
            this.txtsyssqlitedbextension.Name = "txtsyssqlitedbextension";
            this.txtsyssqlitedbextension.Size = new System.Drawing.Size(164, 20);
            this.txtsyssqlitedbextension.TabIndex = 5;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(8, 194);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(67, 20);
            this.label46.TabIndex = 28;
            this.label46.Text = "db extension";
            // 
            // txtsyssqlitefailifmissing
            // 
            this.txtsyssqlitefailifmissing.Location = new System.Drawing.Point(81, 165);
            this.txtsyssqlitefailifmissing.Name = "txtsyssqlitefailifmissing";
            this.txtsyssqlitefailifmissing.Size = new System.Drawing.Size(164, 20);
            this.txtsyssqlitefailifmissing.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 168);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 20);
            this.label21.TabIndex = 26;
            this.label21.Text = "fail if missing";
            // 
            // btnsavesqlitechanges
            // 
            this.btnsavesqlitechanges.BackColor = System.Drawing.SystemColors.Control;
            this.btnsavesqlitechanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsavesqlitechanges.ForeColor = System.Drawing.Color.Black;
            this.btnsavesqlitechanges.Image = ((System.Drawing.Image)(resources.GetObject("btnsavesqlitechanges.Image")));
            this.btnsavesqlitechanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsavesqlitechanges.Location = new System.Drawing.Point(81, 225);
            this.btnsavesqlitechanges.Name = "btnsavesqlitechanges";
            this.btnsavesqlitechanges.Size = new System.Drawing.Size(102, 28);
            this.btnsavesqlitechanges.TabIndex = 6;
            this.btnsavesqlitechanges.Text = "save changes";
            this.btnsavesqlitechanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsavesqlitechanges.UseVisualStyleBackColor = false;
            this.btnsavesqlitechanges.Click += new System.EventHandler(this.BtnsavesqlitechangesClick);
            // 
            // txtsyssqliteversion
            // 
            this.txtsyssqliteversion.Location = new System.Drawing.Point(81, 113);
            this.txtsyssqliteversion.Name = "txtsyssqliteversion";
            this.txtsyssqliteversion.Size = new System.Drawing.Size(164, 20);
            this.txtsyssqliteversion.TabIndex = 2;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(18, 116);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 20);
            this.label22.TabIndex = 22;
            this.label22.Text = "db version";
            // 
            // txtsyssqlitepooling
            // 
            this.txtsyssqlitepooling.Location = new System.Drawing.Point(81, 139);
            this.txtsyssqlitepooling.Name = "txtsyssqlitepooling";
            this.txtsyssqlitepooling.Size = new System.Drawing.Size(164, 20);
            this.txtsyssqlitepooling.TabIndex = 3;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(31, 142);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 17);
            this.label23.TabIndex = 20;
            this.label23.Text = "pooling";
            // 
            // txtsyssqlitedatabase
            // 
            this.txtsyssqlitedatabase.Location = new System.Drawing.Point(81, 87);
            this.txtsyssqlitedatabase.Name = "txtsyssqlitedatabase";
            this.txtsyssqlitedatabase.Size = new System.Drawing.Size(164, 20);
            this.txtsyssqlitedatabase.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(42, 61);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 20);
            this.label24.TabIndex = 16;
            this.label24.Text = "path";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(18, 90);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 20);
            this.label25.TabIndex = 18;
            this.label25.Text = "database";
            // 
            // txtsyssqlitedbpath
            // 
            this.txtsyssqlitedbpath.Location = new System.Drawing.Point(81, 61);
            this.txtsyssqlitedbpath.Name = "txtsyssqlitedbpath";
            this.txtsyssqlitedbpath.Size = new System.Drawing.Size(164, 20);
            this.txtsyssqlitedbpath.TabIndex = 0;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.txtsqlitedbextension);
            this.groupBox12.Controls.Add(this.label45);
            this.groupBox12.Controls.Add(this.txtsqlitefailifmissing);
            this.groupBox12.Controls.Add(this.label41);
            this.groupBox12.Controls.Add(this.btnchecksqliteconnection);
            this.groupBox12.Controls.Add(this.txtsqlitedatabasename);
            this.groupBox12.Controls.Add(this.btncreatesqlitedatabase);
            this.groupBox12.Controls.Add(this.label26);
            this.groupBox12.Controls.Add(this.txtcreatesqlitedatabase);
            this.groupBox12.Controls.Add(this.txtsqlitepooling);
            this.groupBox12.Controls.Add(this.label27);
            this.groupBox12.Controls.Add(this.label28);
            this.groupBox12.Controls.Add(this.txtsqliteversion);
            this.groupBox12.Controls.Add(this.label29);
            this.groupBox12.Controls.Add(this.label30);
            this.groupBox12.Controls.Add(this.txtsqlitedbpath);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox12.Location = new System.Drawing.Point(3, 16);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(257, 300);
            this.groupBox12.TabIndex = 0;
            this.groupBox12.TabStop = false;
            // 
            // txtsqlitedbextension
            // 
            this.txtsqlitedbextension.Location = new System.Drawing.Point(71, 233);
            this.txtsqlitedbextension.Name = "txtsqlitedbextension";
            this.txtsqlitedbextension.Size = new System.Drawing.Size(168, 20);
            this.txtsqlitedbextension.TabIndex = 7;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(6, 233);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(70, 17);
            this.label45.TabIndex = 18;
            this.label45.Text = "db extension";
            // 
            // txtsqlitefailifmissing
            // 
            this.txtsqlitefailifmissing.Location = new System.Drawing.Point(71, 209);
            this.txtsqlitefailifmissing.Name = "txtsqlitefailifmissing";
            this.txtsqlitefailifmissing.Size = new System.Drawing.Size(168, 20);
            this.txtsqlitefailifmissing.TabIndex = 6;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(6, 209);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(70, 17);
            this.label41.TabIndex = 16;
            this.label41.Text = "fail if missing";
            // 
            // btnchecksqliteconnection
            // 
            this.btnchecksqliteconnection.BackColor = System.Drawing.SystemColors.Control;
            this.btnchecksqliteconnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchecksqliteconnection.ForeColor = System.Drawing.Color.Black;
            this.btnchecksqliteconnection.Image = ((System.Drawing.Image)(resources.GetObject("btnchecksqliteconnection.Image")));
            this.btnchecksqliteconnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnchecksqliteconnection.Location = new System.Drawing.Point(71, 257);
            this.btnchecksqliteconnection.Name = "btnchecksqliteconnection";
            this.btnchecksqliteconnection.Size = new System.Drawing.Size(135, 37);
            this.btnchecksqliteconnection.TabIndex = 8;
            this.btnchecksqliteconnection.Text = "check connection";
            this.btnchecksqliteconnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnchecksqliteconnection.UseVisualStyleBackColor = false;
            this.btnchecksqliteconnection.Click += new System.EventHandler(this.BtnchecksqliteconnectionClick);
            // 
            // txtsqlitedatabasename
            // 
            this.txtsqlitedatabasename.Location = new System.Drawing.Point(71, 131);
            this.txtsqlitedatabasename.Name = "txtsqlitedatabasename";
            this.txtsqlitedatabasename.Size = new System.Drawing.Size(168, 20);
            this.txtsqlitedatabasename.TabIndex = 3;
            // 
            // btncreatesqlitedatabase
            // 
            this.btncreatesqlitedatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btncreatesqlitedatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncreatesqlitedatabase.ForeColor = System.Drawing.Color.Black;
            this.btncreatesqlitedatabase.Image = ((System.Drawing.Image)(resources.GetObject("btncreatesqlitedatabase.Image")));
            this.btncreatesqlitedatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncreatesqlitedatabase.Location = new System.Drawing.Point(71, 64);
            this.btncreatesqlitedatabase.Name = "btncreatesqlitedatabase";
            this.btncreatesqlitedatabase.Size = new System.Drawing.Size(114, 28);
            this.btncreatesqlitedatabase.TabIndex = 1;
            this.btncreatesqlitedatabase.Text = "create database";
            this.btncreatesqlitedatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncreatesqlitedatabase.UseVisualStyleBackColor = false;
            this.btncreatesqlitedatabase.Click += new System.EventHandler(this.BtncreatesqlitedatabaseClick);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(11, 131);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(57, 20);
            this.label26.TabIndex = 14;
            this.label26.Text = "database";
            // 
            // txtcreatesqlitedatabase
            // 
            this.txtcreatesqlitedatabase.Location = new System.Drawing.Point(71, 38);
            this.txtcreatesqlitedatabase.Name = "txtcreatesqlitedatabase";
            this.txtcreatesqlitedatabase.Size = new System.Drawing.Size(168, 20);
            this.txtcreatesqlitedatabase.TabIndex = 0;
            // 
            // txtsqlitepooling
            // 
            this.txtsqlitepooling.Location = new System.Drawing.Point(71, 183);
            this.txtsqlitepooling.Name = "txtsqlitepooling";
            this.txtsqlitepooling.Size = new System.Drawing.Size(168, 20);
            this.txtsqlitepooling.TabIndex = 5;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(26, 183);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 17);
            this.label27.TabIndex = 12;
            this.label27.Text = "pooling";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(71, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 23);
            this.label28.TabIndex = 1;
            this.label28.Text = "database name";
            // 
            // txtsqliteversion
            // 
            this.txtsqliteversion.Location = new System.Drawing.Point(71, 157);
            this.txtsqliteversion.Name = "txtsqliteversion";
            this.txtsqliteversion.Size = new System.Drawing.Size(168, 20);
            this.txtsqliteversion.TabIndex = 4;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(39, 104);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 23);
            this.label29.TabIndex = 1;
            this.label29.Text = "path";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(6, 157);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(59, 20);
            this.label30.TabIndex = 10;
            this.label30.Text = "db version";
            // 
            // txtsqlitedbpath
            // 
            this.txtsqlitedbpath.Location = new System.Drawing.Point(71, 107);
            this.txtsqlitedbpath.Name = "txtsqlitedbpath";
            this.txtsqlitedbpath.Size = new System.Drawing.Size(168, 20);
            this.txtsqlitedbpath.TabIndex = 2;
            // 
            // tabPagepostgresql
            // 
            this.tabPagepostgresql.Controls.Add(this.groupBox6);
            this.tabPagepostgresql.ImageIndex = 3;
            this.tabPagepostgresql.Location = new System.Drawing.Point(4, 23);
            this.tabPagepostgresql.Name = "tabPagepostgresql";
            this.tabPagepostgresql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagepostgresql.Size = new System.Drawing.Size(544, 325);
            this.tabPagepostgresql.TabIndex = 3;
            this.tabPagepostgresql.Text = "postgresql";
            this.tabPagepostgresql.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox13);
            this.groupBox6.Controls.Add(this.groupBox14);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(538, 319);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "postgresql";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.txtsyspostgresqlport);
            this.groupBox13.Controls.Add(this.label31);
            this.groupBox13.Controls.Add(this.btnsavepostgresqlchanges);
            this.groupBox13.Controls.Add(this.txtsyspostgresqlusername);
            this.groupBox13.Controls.Add(this.label32);
            this.groupBox13.Controls.Add(this.txtsyspostgresqlpassword);
            this.groupBox13.Controls.Add(this.label33);
            this.groupBox13.Controls.Add(this.txtsyspostgresqldatabase);
            this.groupBox13.Controls.Add(this.label34);
            this.groupBox13.Controls.Add(this.label35);
            this.groupBox13.Controls.Add(this.txtsyspostgresqldatastore);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox13.Location = new System.Drawing.Point(260, 16);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(275, 300);
            this.groupBox13.TabIndex = 1;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "system defaults";
            // 
            // txtsyspostgresqlport
            // 
            this.txtsyspostgresqlport.Location = new System.Drawing.Point(81, 165);
            this.txtsyspostgresqlport.Name = "txtsyspostgresqlport";
            this.txtsyspostgresqlport.Size = new System.Drawing.Size(164, 20);
            this.txtsyspostgresqlport.TabIndex = 4;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(46, 168);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 20);
            this.label31.TabIndex = 26;
            this.label31.Text = "port";
            // 
            // btnsavepostgresqlchanges
            // 
            this.btnsavepostgresqlchanges.BackColor = System.Drawing.SystemColors.Control;
            this.btnsavepostgresqlchanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsavepostgresqlchanges.ForeColor = System.Drawing.Color.Black;
            this.btnsavepostgresqlchanges.Image = ((System.Drawing.Image)(resources.GetObject("btnsavepostgresqlchanges.Image")));
            this.btnsavepostgresqlchanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsavepostgresqlchanges.Location = new System.Drawing.Point(81, 195);
            this.btnsavepostgresqlchanges.Name = "btnsavepostgresqlchanges";
            this.btnsavepostgresqlchanges.Size = new System.Drawing.Size(102, 28);
            this.btnsavepostgresqlchanges.TabIndex = 5;
            this.btnsavepostgresqlchanges.Text = "save changes";
            this.btnsavepostgresqlchanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsavepostgresqlchanges.UseVisualStyleBackColor = false;
            this.btnsavepostgresqlchanges.Click += new System.EventHandler(this.BtnsavepostgresqlchangesClick);
            // 
            // txtsyspostgresqlusername
            // 
            this.txtsyspostgresqlusername.Location = new System.Drawing.Point(81, 113);
            this.txtsyspostgresqlusername.Name = "txtsyspostgresqlusername";
            this.txtsyspostgresqlusername.Size = new System.Drawing.Size(164, 20);
            this.txtsyspostgresqlusername.TabIndex = 2;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(18, 116);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(57, 20);
            this.label32.TabIndex = 22;
            this.label32.Text = "username";
            // 
            // txtsyspostgresqlpassword
            // 
            this.txtsyspostgresqlpassword.Location = new System.Drawing.Point(81, 139);
            this.txtsyspostgresqlpassword.Name = "txtsyspostgresqlpassword";
            this.txtsyspostgresqlpassword.PasswordChar = '*';
            this.txtsyspostgresqlpassword.Size = new System.Drawing.Size(164, 20);
            this.txtsyspostgresqlpassword.TabIndex = 3;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(18, 142);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(57, 17);
            this.label33.TabIndex = 20;
            this.label33.Text = "password";
            // 
            // txtsyspostgresqldatabase
            // 
            this.txtsyspostgresqldatabase.Location = new System.Drawing.Point(81, 87);
            this.txtsyspostgresqldatabase.Name = "txtsyspostgresqldatabase";
            this.txtsyspostgresqldatabase.Size = new System.Drawing.Size(164, 20);
            this.txtsyspostgresqldatabase.TabIndex = 1;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(38, 61);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(36, 20);
            this.label34.TabIndex = 16;
            this.label34.Text = "host";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(18, 87);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(57, 20);
            this.label35.TabIndex = 18;
            this.label35.Text = "database";
            // 
            // txtsyspostgresqldatastore
            // 
            this.txtsyspostgresqldatastore.Location = new System.Drawing.Point(81, 61);
            this.txtsyspostgresqldatastore.Name = "txtsyspostgresqldatastore";
            this.txtsyspostgresqldatastore.Size = new System.Drawing.Size(164, 20);
            this.txtsyspostgresqldatastore.TabIndex = 0;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.txtpostgresqlport);
            this.groupBox14.Controls.Add(this.label44);
            this.groupBox14.Controls.Add(this.btncheckpostgresqlconnection);
            this.groupBox14.Controls.Add(this.txtpostgresqldatabasename);
            this.groupBox14.Controls.Add(this.btncreatepostgresqldatabase);
            this.groupBox14.Controls.Add(this.label36);
            this.groupBox14.Controls.Add(this.txtcreatepostgresqldatabase);
            this.groupBox14.Controls.Add(this.txtpostgresqlpassword);
            this.groupBox14.Controls.Add(this.label37);
            this.groupBox14.Controls.Add(this.label38);
            this.groupBox14.Controls.Add(this.txtpostgresqlusername);
            this.groupBox14.Controls.Add(this.label39);
            this.groupBox14.Controls.Add(this.label40);
            this.groupBox14.Controls.Add(this.txtpostgresqlhostname);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox14.Location = new System.Drawing.Point(3, 16);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(257, 300);
            this.groupBox14.TabIndex = 0;
            this.groupBox14.TabStop = false;
            // 
            // txtpostgresqlport
            // 
            this.txtpostgresqlport.Location = new System.Drawing.Point(71, 231);
            this.txtpostgresqlport.Name = "txtpostgresqlport";
            this.txtpostgresqlport.Size = new System.Drawing.Size(168, 20);
            this.txtpostgresqlport.TabIndex = 6;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(36, 234);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(29, 20);
            this.label44.TabIndex = 30;
            this.label44.Text = "port";
            // 
            // btncheckpostgresqlconnection
            // 
            this.btncheckpostgresqlconnection.BackColor = System.Drawing.SystemColors.Control;
            this.btncheckpostgresqlconnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncheckpostgresqlconnection.ForeColor = System.Drawing.Color.Black;
            this.btncheckpostgresqlconnection.Image = ((System.Drawing.Image)(resources.GetObject("btncheckpostgresqlconnection.Image")));
            this.btncheckpostgresqlconnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncheckpostgresqlconnection.Location = new System.Drawing.Point(71, 257);
            this.btncheckpostgresqlconnection.Name = "btncheckpostgresqlconnection";
            this.btncheckpostgresqlconnection.Size = new System.Drawing.Size(135, 37);
            this.btncheckpostgresqlconnection.TabIndex = 7;
            this.btncheckpostgresqlconnection.Text = "check connection";
            this.btncheckpostgresqlconnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncheckpostgresqlconnection.UseVisualStyleBackColor = false;
            this.btncheckpostgresqlconnection.Click += new System.EventHandler(this.BtncheckpostgresqlconnectionClick);
            // 
            // txtpostgresqldatabasename
            // 
            this.txtpostgresqldatabasename.Location = new System.Drawing.Point(71, 153);
            this.txtpostgresqldatabasename.Name = "txtpostgresqldatabasename";
            this.txtpostgresqldatabasename.Size = new System.Drawing.Size(168, 20);
            this.txtpostgresqldatabasename.TabIndex = 3;
            // 
            // btncreatepostgresqldatabase
            // 
            this.btncreatepostgresqldatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btncreatepostgresqldatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncreatepostgresqldatabase.ForeColor = System.Drawing.Color.Black;
            this.btncreatepostgresqldatabase.Image = ((System.Drawing.Image)(resources.GetObject("btncreatepostgresqldatabase.Image")));
            this.btncreatepostgresqldatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncreatepostgresqldatabase.Location = new System.Drawing.Point(71, 72);
            this.btncreatepostgresqldatabase.Name = "btncreatepostgresqldatabase";
            this.btncreatepostgresqldatabase.Size = new System.Drawing.Size(114, 28);
            this.btncreatepostgresqldatabase.TabIndex = 1;
            this.btncreatepostgresqldatabase.Text = "create database";
            this.btncreatepostgresqldatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncreatepostgresqldatabase.UseVisualStyleBackColor = false;
            this.btncreatepostgresqldatabase.Click += new System.EventHandler(this.BtncreatepostgresqldatabaseClick);
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(8, 152);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(57, 21);
            this.label36.TabIndex = 14;
            this.label36.Text = "database";
            // 
            // txtcreatepostgresqldatabase
            // 
            this.txtcreatepostgresqldatabase.Location = new System.Drawing.Point(71, 46);
            this.txtcreatepostgresqldatabase.Name = "txtcreatepostgresqldatabase";
            this.txtcreatepostgresqldatabase.Size = new System.Drawing.Size(168, 20);
            this.txtcreatepostgresqldatabase.TabIndex = 0;
            // 
            // txtpostgresqlpassword
            // 
            this.txtpostgresqlpassword.Location = new System.Drawing.Point(71, 205);
            this.txtpostgresqlpassword.Name = "txtpostgresqlpassword";
            this.txtpostgresqlpassword.PasswordChar = '*';
            this.txtpostgresqlpassword.Size = new System.Drawing.Size(168, 20);
            this.txtpostgresqlpassword.TabIndex = 5;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(8, 206);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(57, 17);
            this.label37.TabIndex = 12;
            this.label37.Text = "password";
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(71, 16);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(80, 23);
            this.label38.TabIndex = 1;
            this.label38.Text = "database name";
            // 
            // txtpostgresqlusername
            // 
            this.txtpostgresqlusername.Location = new System.Drawing.Point(71, 179);
            this.txtpostgresqlusername.Name = "txtpostgresqlusername";
            this.txtpostgresqlusername.Size = new System.Drawing.Size(168, 20);
            this.txtpostgresqlusername.TabIndex = 4;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(26, 124);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(30, 23);
            this.label39.TabIndex = 1;
            this.label39.Text = "host";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(8, 179);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(57, 20);
            this.label40.TabIndex = 10;
            this.label40.Text = "username";
            // 
            // txtpostgresqlhostname
            // 
            this.txtpostgresqlhostname.Location = new System.Drawing.Point(71, 127);
            this.txtpostgresqlhostname.Name = "txtpostgresqlhostname";
            this.txtpostgresqlhostname.Size = new System.Drawing.Size(168, 20);
            this.txtpostgresqlhostname.TabIndex = 2;
            // 
            // tabPageupdateschemas
            // 
            this.tabPageupdateschemas.Controls.Add(this.groupBox18);
            this.tabPageupdateschemas.Controls.Add(this.groupBox17);
            this.tabPageupdateschemas.Controls.Add(this.groupBox16);
            this.tabPageupdateschemas.Controls.Add(this.groupBox15);
            this.tabPageupdateschemas.ImageIndex = 4;
            this.tabPageupdateschemas.Location = new System.Drawing.Point(4, 23);
            this.tabPageupdateschemas.Name = "tabPageupdateschemas";
            this.tabPageupdateschemas.Size = new System.Drawing.Size(544, 325);
            this.tabPageupdateschemas.TabIndex = 4;
            this.tabPageupdateschemas.Text = "schemas";
            this.tabPageupdateschemas.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.BackColor = System.Drawing.Color.Wheat;
            this.groupBox18.Controls.Add(this.btndeletesqlitedatabase);
            this.groupBox18.Controls.Add(this.lblsqlitedbcount);
            this.groupBox18.Controls.Add(this.btnupdatesqlitedatabase);
            this.groupBox18.Controls.Add(this.cbosqlitedatabases);
            this.groupBox18.Controls.Add(this.btnloadsqlitedatabases);
            this.groupBox18.Controls.Add(this.label50);
            this.groupBox18.Location = new System.Drawing.Point(284, 172);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(239, 140);
            this.groupBox18.TabIndex = 3;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "sqlite";
            // 
            // btndeletesqlitedatabase
            // 
            this.btndeletesqlitedatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btndeletesqlitedatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletesqlitedatabase.ForeColor = System.Drawing.Color.Black;
            this.btndeletesqlitedatabase.Image = ((System.Drawing.Image)(resources.GetObject("btndeletesqlitedatabase.Image")));
            this.btndeletesqlitedatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndeletesqlitedatabase.Location = new System.Drawing.Point(140, 47);
            this.btndeletesqlitedatabase.Name = "btndeletesqlitedatabase";
            this.btndeletesqlitedatabase.Size = new System.Drawing.Size(76, 42);
            this.btndeletesqlitedatabase.TabIndex = 7;
            this.btndeletesqlitedatabase.Text = "delete";
            this.btndeletesqlitedatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndeletesqlitedatabase.UseVisualStyleBackColor = false;
            this.btndeletesqlitedatabase.Click += new System.EventHandler(this.BtndeletesqlitedatabaseClick);
            // 
            // lblsqlitedbcount
            // 
            this.lblsqlitedbcount.Location = new System.Drawing.Point(190, 108);
            this.lblsqlitedbcount.Name = "lblsqlitedbcount";
            this.lblsqlitedbcount.Size = new System.Drawing.Size(26, 23);
            this.lblsqlitedbcount.TabIndex = 5;
            this.lblsqlitedbcount.Text = "0";
            // 
            // btnupdatesqlitedatabase
            // 
            this.btnupdatesqlitedatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btnupdatesqlitedatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdatesqlitedatabase.ForeColor = System.Drawing.Color.Black;
            this.btnupdatesqlitedatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnupdatesqlitedatabase.Image")));
            this.btnupdatesqlitedatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdatesqlitedatabase.Location = new System.Drawing.Point(15, 47);
            this.btnupdatesqlitedatabase.Name = "btnupdatesqlitedatabase";
            this.btnupdatesqlitedatabase.Size = new System.Drawing.Size(119, 43);
            this.btnupdatesqlitedatabase.TabIndex = 2;
            this.btnupdatesqlitedatabase.Text = "update schema";
            this.btnupdatesqlitedatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnupdatesqlitedatabase.UseVisualStyleBackColor = false;
            this.btnupdatesqlitedatabase.Click += new System.EventHandler(this.BtnupdatesqlitedatabaseClick);
            // 
            // cbosqlitedatabases
            // 
            this.cbosqlitedatabases.BackColor = System.Drawing.Color.Black;
            this.cbosqlitedatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbosqlitedatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbosqlitedatabases.ForeColor = System.Drawing.Color.White;
            this.cbosqlitedatabases.FormattingEnabled = true;
            this.cbosqlitedatabases.Location = new System.Drawing.Point(11, 108);
            this.cbosqlitedatabases.Name = "cbosqlitedatabases";
            this.cbosqlitedatabases.Size = new System.Drawing.Size(172, 21);
            this.cbosqlitedatabases.TabIndex = 0;
            // 
            // btnloadsqlitedatabases
            // 
            this.btnloadsqlitedatabases.BackColor = System.Drawing.SystemColors.Control;
            this.btnloadsqlitedatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloadsqlitedatabases.ForeColor = System.Drawing.Color.Black;
            this.btnloadsqlitedatabases.Image = ((System.Drawing.Image)(resources.GetObject("btnloadsqlitedatabases.Image")));
            this.btnloadsqlitedatabases.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnloadsqlitedatabases.Location = new System.Drawing.Point(15, 15);
            this.btnloadsqlitedatabases.Name = "btnloadsqlitedatabases";
            this.btnloadsqlitedatabases.Size = new System.Drawing.Size(201, 28);
            this.btnloadsqlitedatabases.TabIndex = 1;
            this.btnloadsqlitedatabases.Text = "load";
            this.btnloadsqlitedatabases.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnloadsqlitedatabases.UseVisualStyleBackColor = false;
            this.btnloadsqlitedatabases.Click += new System.EventHandler(this.BtnloadsqlitedatabasesClick);
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(11, 89);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(80, 23);
            this.label50.TabIndex = 3;
            this.label50.Text = "database name";
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.Wheat;
            this.groupBox17.Controls.Add(this.btndeletepostgresqldatabase);
            this.groupBox17.Controls.Add(this.lblpostgresqldbcount);
            this.groupBox17.Controls.Add(this.btnupdatepostgresqldatabase);
            this.groupBox17.Controls.Add(this.cbopostgresqldatabases);
            this.groupBox17.Controls.Add(this.btnloadpostgresqldatabases);
            this.groupBox17.Controls.Add(this.label49);
            this.groupBox17.Location = new System.Drawing.Point(284, 19);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(239, 146);
            this.groupBox17.TabIndex = 2;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "postgresql";
            // 
            // btndeletepostgresqldatabase
            // 
            this.btndeletepostgresqldatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btndeletepostgresqldatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletepostgresqldatabase.ForeColor = System.Drawing.Color.Black;
            this.btndeletepostgresqldatabase.Image = ((System.Drawing.Image)(resources.GetObject("btndeletepostgresqldatabase.Image")));
            this.btndeletepostgresqldatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndeletepostgresqldatabase.Location = new System.Drawing.Point(144, 52);
            this.btndeletepostgresqldatabase.Name = "btndeletepostgresqldatabase";
            this.btndeletepostgresqldatabase.Size = new System.Drawing.Size(76, 42);
            this.btndeletepostgresqldatabase.TabIndex = 7;
            this.btndeletepostgresqldatabase.Text = "delete";
            this.btndeletepostgresqldatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndeletepostgresqldatabase.UseVisualStyleBackColor = false;
            this.btndeletepostgresqldatabase.Click += new System.EventHandler(this.BtndeletepostgresqldatabaseClick);
            // 
            // lblpostgresqldbcount
            // 
            this.lblpostgresqldbcount.Location = new System.Drawing.Point(179, 119);
            this.lblpostgresqldbcount.Name = "lblpostgresqldbcount";
            this.lblpostgresqldbcount.Size = new System.Drawing.Size(26, 23);
            this.lblpostgresqldbcount.TabIndex = 5;
            this.lblpostgresqldbcount.Text = "0";
            // 
            // btnupdatepostgresqldatabase
            // 
            this.btnupdatepostgresqldatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btnupdatepostgresqldatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdatepostgresqldatabase.ForeColor = System.Drawing.Color.Black;
            this.btnupdatepostgresqldatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnupdatepostgresqldatabase.Image")));
            this.btnupdatepostgresqldatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdatepostgresqldatabase.Location = new System.Drawing.Point(15, 51);
            this.btnupdatepostgresqldatabase.Name = "btnupdatepostgresqldatabase";
            this.btnupdatepostgresqldatabase.Size = new System.Drawing.Size(124, 43);
            this.btnupdatepostgresqldatabase.TabIndex = 2;
            this.btnupdatepostgresqldatabase.Text = "update schema";
            this.btnupdatepostgresqldatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnupdatepostgresqldatabase.UseVisualStyleBackColor = false;
            this.btnupdatepostgresqldatabase.Click += new System.EventHandler(this.BtnupdatepostgresqldatabaseClick);
            // 
            // cbopostgresqldatabases
            // 
            this.cbopostgresqldatabases.BackColor = System.Drawing.Color.Black;
            this.cbopostgresqldatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopostgresqldatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbopostgresqldatabases.ForeColor = System.Drawing.Color.White;
            this.cbopostgresqldatabases.FormattingEnabled = true;
            this.cbopostgresqldatabases.Location = new System.Drawing.Point(6, 119);
            this.cbopostgresqldatabases.Name = "cbopostgresqldatabases";
            this.cbopostgresqldatabases.Size = new System.Drawing.Size(172, 21);
            this.cbopostgresqldatabases.TabIndex = 0;
            // 
            // btnloadpostgresqldatabases
            // 
            this.btnloadpostgresqldatabases.BackColor = System.Drawing.SystemColors.Control;
            this.btnloadpostgresqldatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloadpostgresqldatabases.ForeColor = System.Drawing.Color.Black;
            this.btnloadpostgresqldatabases.Image = ((System.Drawing.Image)(resources.GetObject("btnloadpostgresqldatabases.Image")));
            this.btnloadpostgresqldatabases.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnloadpostgresqldatabases.Location = new System.Drawing.Point(15, 15);
            this.btnloadpostgresqldatabases.Name = "btnloadpostgresqldatabases";
            this.btnloadpostgresqldatabases.Size = new System.Drawing.Size(205, 30);
            this.btnloadpostgresqldatabases.TabIndex = 1;
            this.btnloadpostgresqldatabases.Text = "load";
            this.btnloadpostgresqldatabases.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnloadpostgresqldatabases.UseVisualStyleBackColor = false;
            this.btnloadpostgresqldatabases.Click += new System.EventHandler(this.BtnloadpostgresqldatabasesClick);
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(6, 100);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(80, 23);
            this.label49.TabIndex = 3;
            this.label49.Text = "database name";
            // 
            // groupBox16
            // 
            this.groupBox16.BackColor = System.Drawing.Color.Wheat;
            this.groupBox16.Controls.Add(this.btndeletemysqldatabase);
            this.groupBox16.Controls.Add(this.lblmysqldbcount);
            this.groupBox16.Controls.Add(this.btnupdatemysqldatabase);
            this.groupBox16.Controls.Add(this.cbomysqldatabases);
            this.groupBox16.Controls.Add(this.btnloadmysqldatabases);
            this.groupBox16.Controls.Add(this.label48);
            this.groupBox16.Location = new System.Drawing.Point(12, 172);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(266, 140);
            this.groupBox16.TabIndex = 1;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "mysql";
            // 
            // btndeletemysqldatabase
            // 
            this.btndeletemysqldatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btndeletemysqldatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletemysqldatabase.ForeColor = System.Drawing.Color.Black;
            this.btndeletemysqldatabase.Image = ((System.Drawing.Image)(resources.GetObject("btndeletemysqldatabase.Image")));
            this.btndeletemysqldatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndeletemysqldatabase.Location = new System.Drawing.Point(140, 48);
            this.btndeletemysqldatabase.Name = "btndeletemysqldatabase";
            this.btndeletemysqldatabase.Size = new System.Drawing.Size(76, 42);
            this.btndeletemysqldatabase.TabIndex = 7;
            this.btndeletemysqldatabase.Text = "delete";
            this.btndeletemysqldatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndeletemysqldatabase.UseVisualStyleBackColor = false;
            this.btndeletemysqldatabase.Click += new System.EventHandler(this.BtndeletemysqldatabaseClick);
            // 
            // lblmysqldbcount
            // 
            this.lblmysqldbcount.Location = new System.Drawing.Point(193, 113);
            this.lblmysqldbcount.Name = "lblmysqldbcount";
            this.lblmysqldbcount.Size = new System.Drawing.Size(26, 23);
            this.lblmysqldbcount.TabIndex = 4;
            this.lblmysqldbcount.Text = "0";
            // 
            // btnupdatemysqldatabase
            // 
            this.btnupdatemysqldatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btnupdatemysqldatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdatemysqldatabase.ForeColor = System.Drawing.Color.Black;
            this.btnupdatemysqldatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnupdatemysqldatabase.Image")));
            this.btnupdatemysqldatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdatemysqldatabase.Location = new System.Drawing.Point(15, 47);
            this.btnupdatemysqldatabase.Name = "btnupdatemysqldatabase";
            this.btnupdatemysqldatabase.Size = new System.Drawing.Size(119, 43);
            this.btnupdatemysqldatabase.TabIndex = 2;
            this.btnupdatemysqldatabase.Text = "update schema";
            this.btnupdatemysqldatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnupdatemysqldatabase.UseVisualStyleBackColor = false;
            this.btnupdatemysqldatabase.Click += new System.EventHandler(this.BtnupdatemysqldatabaseClick);
            // 
            // cbomysqldatabases
            // 
            this.cbomysqldatabases.BackColor = System.Drawing.Color.Black;
            this.cbomysqldatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomysqldatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbomysqldatabases.ForeColor = System.Drawing.Color.White;
            this.cbomysqldatabases.FormattingEnabled = true;
            this.cbomysqldatabases.Location = new System.Drawing.Point(15, 113);
            this.cbomysqldatabases.Name = "cbomysqldatabases";
            this.cbomysqldatabases.Size = new System.Drawing.Size(172, 21);
            this.cbomysqldatabases.TabIndex = 0;
            // 
            // btnloadmysqldatabases
            // 
            this.btnloadmysqldatabases.BackColor = System.Drawing.SystemColors.Control;
            this.btnloadmysqldatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloadmysqldatabases.ForeColor = System.Drawing.Color.Black;
            this.btnloadmysqldatabases.Image = ((System.Drawing.Image)(resources.GetObject("btnloadmysqldatabases.Image")));
            this.btnloadmysqldatabases.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnloadmysqldatabases.Location = new System.Drawing.Point(15, 15);
            this.btnloadmysqldatabases.Name = "btnloadmysqldatabases";
            this.btnloadmysqldatabases.Size = new System.Drawing.Size(201, 28);
            this.btnloadmysqldatabases.TabIndex = 1;
            this.btnloadmysqldatabases.Text = "load";
            this.btnloadmysqldatabases.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnloadmysqldatabases.UseVisualStyleBackColor = false;
            this.btnloadmysqldatabases.Click += new System.EventHandler(this.BtnloadmysqldatabasesClick);
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(15, 94);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(80, 23);
            this.label48.TabIndex = 3;
            this.label48.Text = "database name";
            // 
            // groupBox15
            // 
            this.groupBox15.BackColor = System.Drawing.Color.Wheat;
            this.groupBox15.Controls.Add(this.btndeletemssqldatabase);
            this.groupBox15.Controls.Add(this.lblmssqldbcount);
            this.groupBox15.Controls.Add(this.btnupdatemssqldatabase);
            this.groupBox15.Controls.Add(this.cbomssqldatabases);
            this.groupBox15.Controls.Add(this.btnloadmssqldatabases);
            this.groupBox15.Controls.Add(this.label47);
            this.groupBox15.Location = new System.Drawing.Point(12, 19);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(266, 146);
            this.groupBox15.TabIndex = 0;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "mssql";
            // 
            // btndeletemssqldatabase
            // 
            this.btndeletemssqldatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btndeletemssqldatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeletemssqldatabase.ForeColor = System.Drawing.Color.Black;
            this.btndeletemssqldatabase.Image = ((System.Drawing.Image)(resources.GetObject("btndeletemssqldatabase.Image")));
            this.btndeletemssqldatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndeletemssqldatabase.Location = new System.Drawing.Point(140, 49);
            this.btndeletemssqldatabase.Name = "btndeletemssqldatabase";
            this.btndeletemssqldatabase.Size = new System.Drawing.Size(76, 42);
            this.btndeletemssqldatabase.TabIndex = 6;
            this.btndeletemssqldatabase.Text = "delete";
            this.btndeletemssqldatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndeletemssqldatabase.UseVisualStyleBackColor = false;
            this.btndeletemssqldatabase.Click += new System.EventHandler(this.BtndeletemssqldatabaseClick);
            // 
            // lblmssqldbcount
            // 
            this.lblmssqldbcount.Location = new System.Drawing.Point(193, 122);
            this.lblmssqldbcount.Name = "lblmssqldbcount";
            this.lblmssqldbcount.Size = new System.Drawing.Size(26, 23);
            this.lblmssqldbcount.TabIndex = 5;
            this.lblmssqldbcount.Text = "0";
            // 
            // btnupdatemssqldatabase
            // 
            this.btnupdatemssqldatabase.BackColor = System.Drawing.SystemColors.Control;
            this.btnupdatemssqldatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdatemssqldatabase.ForeColor = System.Drawing.Color.Black;
            this.btnupdatemssqldatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnupdatemssqldatabase.Image")));
            this.btnupdatemssqldatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnupdatemssqldatabase.Location = new System.Drawing.Point(6, 48);
            this.btnupdatemssqldatabase.Name = "btnupdatemssqldatabase";
            this.btnupdatemssqldatabase.Size = new System.Drawing.Size(128, 45);
            this.btnupdatemssqldatabase.TabIndex = 2;
            this.btnupdatemssqldatabase.Text = "update schema";
            this.btnupdatemssqldatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnupdatemssqldatabase.UseVisualStyleBackColor = false;
            this.btnupdatemssqldatabase.Click += new System.EventHandler(this.BtnupdatemssqldatabaseClick);
            // 
            // cbomssqldatabases
            // 
            this.cbomssqldatabases.BackColor = System.Drawing.Color.Black;
            this.cbomssqldatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomssqldatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbomssqldatabases.ForeColor = System.Drawing.Color.White;
            this.cbomssqldatabases.FormattingEnabled = true;
            this.cbomssqldatabases.Location = new System.Drawing.Point(15, 119);
            this.cbomssqldatabases.Name = "cbomssqldatabases";
            this.cbomssqldatabases.Size = new System.Drawing.Size(172, 21);
            this.cbomssqldatabases.TabIndex = 0;
            // 
            // btnloadmssqldatabases
            // 
            this.btnloadmssqldatabases.BackColor = System.Drawing.SystemColors.Control;
            this.btnloadmssqldatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloadmssqldatabases.ForeColor = System.Drawing.Color.Black;
            this.btnloadmssqldatabases.Image = ((System.Drawing.Image)(resources.GetObject("btnloadmssqldatabases.Image")));
            this.btnloadmssqldatabases.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnloadmssqldatabases.Location = new System.Drawing.Point(6, 19);
            this.btnloadmssqldatabases.Name = "btnloadmssqldatabases";
            this.btnloadmssqldatabases.Size = new System.Drawing.Size(210, 26);
            this.btnloadmssqldatabases.TabIndex = 1;
            this.btnloadmssqldatabases.Text = "load";
            this.btnloadmssqldatabases.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnloadmssqldatabases.UseVisualStyleBackColor = false;
            this.btnloadmssqldatabases.Click += new System.EventHandler(this.BtnloadmssqldatabasesClick);
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(15, 100);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(80, 23);
            this.label47.TabIndex = 3;
            this.label47.Text = "database name";
            // 
            // tabPageutils
            // 
            this.tabPageutils.Controls.Add(this.groupBox23);
            this.tabPageutils.Controls.Add(this.groupBox19);
            this.tabPageutils.ImageIndex = 5;
            this.tabPageutils.Location = new System.Drawing.Point(4, 23);
            this.tabPageutils.Name = "tabPageutils";
            this.tabPageutils.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageutils.Size = new System.Drawing.Size(544, 325);
            this.tabPageutils.TabIndex = 5;
            this.tabPageutils.Text = "utils";
            this.tabPageutils.UseVisualStyleBackColor = true;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.groupBox20);
            this.groupBox23.Controls.Add(this.groupBox21);
            this.groupBox23.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox23.Location = new System.Drawing.Point(3, 157);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(538, 165);
            this.groupBox23.TabIndex = 6;
            this.groupBox23.TabStop = false;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.txtserveripaddress);
            this.groupBox20.Controls.Add(this.btngetipaddress);
            this.groupBox20.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox20.Location = new System.Drawing.Point(3, 16);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(166, 146);
            this.groupBox20.TabIndex = 2;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "server ip address";
            // 
            // txtserveripaddress
            // 
            this.txtserveripaddress.BackColor = System.Drawing.Color.Black;
            this.txtserveripaddress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtserveripaddress.ForeColor = System.Drawing.Color.Lime;
            this.txtserveripaddress.Location = new System.Drawing.Point(3, 67);
            this.txtserveripaddress.Multiline = true;
            this.txtserveripaddress.Name = "txtserveripaddress";
            this.txtserveripaddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtserveripaddress.Size = new System.Drawing.Size(160, 76);
            this.txtserveripaddress.TabIndex = 6;
            // 
            // btngetipaddress
            // 
            this.btngetipaddress.BackColor = System.Drawing.SystemColors.Control;
            this.btngetipaddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.btngetipaddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngetipaddress.ForeColor = System.Drawing.Color.Black;
            this.btngetipaddress.Image = ((System.Drawing.Image)(resources.GetObject("btngetipaddress.Image")));
            this.btngetipaddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngetipaddress.Location = new System.Drawing.Point(3, 16);
            this.btngetipaddress.Name = "btngetipaddress";
            this.btngetipaddress.Size = new System.Drawing.Size(160, 42);
            this.btngetipaddress.TabIndex = 6;
            this.btngetipaddress.Text = "get ip address";
            this.btngetipaddress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btngetipaddress.UseVisualStyleBackColor = false;
            this.btngetipaddress.Click += new System.EventHandler(this.BtngetipaddressClick);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.btnsync);
            this.groupBox21.Controls.Add(this.lbldatabaseto);
            this.groupBox21.Controls.Add(this.label56);
            this.groupBox21.Controls.Add(this.cboserverto);
            this.groupBox21.Controls.Add(this.cbodatabaseto);
            this.groupBox21.Controls.Add(this.lbldatabasefrom);
            this.groupBox21.Controls.Add(this.label54);
            this.groupBox21.Controls.Add(this.cboserverfrom);
            this.groupBox21.Controls.Add(this.cbodatabasefrom);
            this.groupBox21.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox21.Location = new System.Drawing.Point(176, 16);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(359, 146);
            this.groupBox21.TabIndex = 7;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "sync data between datastores";
            // 
            // btnsync
            // 
            this.btnsync.BackColor = System.Drawing.SystemColors.Control;
            this.btnsync.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnsync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsync.ForeColor = System.Drawing.Color.Black;
            this.btnsync.Image = ((System.Drawing.Image)(resources.GetObject("btnsync.Image")));
            this.btnsync.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsync.Location = new System.Drawing.Point(3, 97);
            this.btnsync.Name = "btnsync";
            this.btnsync.Size = new System.Drawing.Size(353, 46);
            this.btnsync.TabIndex = 13;
            this.btnsync.Text = "sync";
            this.btnsync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsync.UseVisualStyleBackColor = false;
            this.btnsync.Click += new System.EventHandler(this.BtnsyncClick);
            // 
            // lbldatabaseto
            // 
            this.lbldatabaseto.Location = new System.Drawing.Point(179, 55);
            this.lbldatabaseto.Name = "lbldatabaseto";
            this.lbldatabaseto.Size = new System.Drawing.Size(51, 31);
            this.lbldatabaseto.TabIndex = 12;
            this.lbldatabaseto.Text = "database to";
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(179, 22);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(54, 20);
            this.label56.TabIndex = 11;
            this.label56.Text = "server to";
            // 
            // cboserverto
            // 
            this.cboserverto.BackColor = System.Drawing.Color.Black;
            this.cboserverto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboserverto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboserverto.ForeColor = System.Drawing.Color.White;
            this.cboserverto.FormattingEnabled = true;
            this.cboserverto.Location = new System.Drawing.Point(239, 21);
            this.cboserverto.Name = "cboserverto";
            this.cboserverto.Size = new System.Drawing.Size(96, 21);
            this.cboserverto.TabIndex = 10;
            this.cboserverto.SelectedIndexChanged += new System.EventHandler(this.CboservertoSelectedIndexChanged);
            // 
            // cbodatabaseto
            // 
            this.cbodatabaseto.BackColor = System.Drawing.Color.Black;
            this.cbodatabaseto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodatabaseto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbodatabaseto.ForeColor = System.Drawing.Color.White;
            this.cbodatabaseto.FormattingEnabled = true;
            this.cbodatabaseto.Location = new System.Drawing.Point(239, 57);
            this.cbodatabaseto.Name = "cbodatabaseto";
            this.cbodatabaseto.Size = new System.Drawing.Size(96, 21);
            this.cbodatabaseto.TabIndex = 9;
            this.cbodatabaseto.SelectedIndexChanged += new System.EventHandler(this.CbodatabasetoSelectedIndexChanged);
            // 
            // lbldatabasefrom
            // 
            this.lbldatabasefrom.Location = new System.Drawing.Point(8, 53);
            this.lbldatabasefrom.Name = "lbldatabasefrom";
            this.lbldatabasefrom.Size = new System.Drawing.Size(51, 29);
            this.lbldatabasefrom.TabIndex = 8;
            this.lbldatabasefrom.Text = "database from";
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(8, 19);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(51, 34);
            this.label54.TabIndex = 7;
            this.label54.Text = "server from";
            // 
            // cboserverfrom
            // 
            this.cboserverfrom.BackColor = System.Drawing.Color.Black;
            this.cboserverfrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboserverfrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboserverfrom.ForeColor = System.Drawing.Color.White;
            this.cboserverfrom.FormattingEnabled = true;
            this.cboserverfrom.Location = new System.Drawing.Point(68, 19);
            this.cboserverfrom.Name = "cboserverfrom";
            this.cboserverfrom.Size = new System.Drawing.Size(96, 21);
            this.cboserverfrom.TabIndex = 6;
            this.cboserverfrom.SelectedIndexChanged += new System.EventHandler(this.CboserverfromSelectedIndexChanged);
            // 
            // cbodatabasefrom
            // 
            this.cbodatabasefrom.BackColor = System.Drawing.Color.Black;
            this.cbodatabasefrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodatabasefrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbodatabasefrom.ForeColor = System.Drawing.Color.White;
            this.cbodatabasefrom.FormattingEnabled = true;
            this.cbodatabasefrom.Location = new System.Drawing.Point(68, 55);
            this.cbodatabasefrom.Name = "cbodatabasefrom";
            this.cbodatabasefrom.Size = new System.Drawing.Size(96, 21);
            this.cbodatabasefrom.TabIndex = 5;
            this.cbodatabasefrom.SelectedIndexChanged += new System.EventHandler(this.CbodatabasefromSelectedIndexChanged);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btnexecutequery);
            this.groupBox19.Controls.Add(this.lbldatabasequery);
            this.groupBox19.Controls.Add(this.label51);
            this.groupBox19.Controls.Add(this.cboserverquery);
            this.groupBox19.Controls.Add(this.cbodatabasequery);
            this.groupBox19.Controls.Add(this.txtquery);
            this.groupBox19.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox19.Location = new System.Drawing.Point(3, 3);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(538, 151);
            this.groupBox19.TabIndex = 0;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "execute query against a connection";
            // 
            // btnexecutequery
            // 
            this.btnexecutequery.BackColor = System.Drawing.SystemColors.Control;
            this.btnexecutequery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnexecutequery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexecutequery.ForeColor = System.Drawing.Color.Black;
            this.btnexecutequery.Image = ((System.Drawing.Image)(resources.GetObject("btnexecutequery.Image")));
            this.btnexecutequery.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexecutequery.Location = new System.Drawing.Point(3, 111);
            this.btnexecutequery.Name = "btnexecutequery";
            this.btnexecutequery.Size = new System.Drawing.Size(532, 37);
            this.btnexecutequery.TabIndex = 5;
            this.btnexecutequery.Text = "execute query";
            this.btnexecutequery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexecutequery.UseVisualStyleBackColor = false;
            this.btnexecutequery.Click += new System.EventHandler(this.BtnexecutequeryClick);
            // 
            // lbldatabasequery
            // 
            this.lbldatabasequery.Location = new System.Drawing.Point(256, 67);
            this.lbldatabasequery.Name = "lbldatabasequery";
            this.lbldatabasequery.Size = new System.Drawing.Size(54, 32);
            this.lbldatabasequery.TabIndex = 4;
            this.lbldatabasequery.Text = "database";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(11, 72);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(41, 23);
            this.label51.TabIndex = 3;
            this.label51.Text = "server";
            // 
            // cboserverquery
            // 
            this.cboserverquery.BackColor = System.Drawing.Color.Black;
            this.cboserverquery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboserverquery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboserverquery.ForeColor = System.Drawing.Color.White;
            this.cboserverquery.FormattingEnabled = true;
            this.cboserverquery.Location = new System.Drawing.Point(58, 72);
            this.cboserverquery.Name = "cboserverquery";
            this.cboserverquery.Size = new System.Drawing.Size(172, 21);
            this.cboserverquery.TabIndex = 2;
            this.cboserverquery.SelectedIndexChanged += new System.EventHandler(this.CboserverquerySelectedIndexChanged);
            // 
            // cbodatabasequery
            // 
            this.cbodatabasequery.BackColor = System.Drawing.Color.Black;
            this.cbodatabasequery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodatabasequery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbodatabasequery.ForeColor = System.Drawing.Color.White;
            this.cbodatabasequery.FormattingEnabled = true;
            this.cbodatabasequery.Location = new System.Drawing.Point(316, 69);
            this.cbodatabasequery.Name = "cbodatabasequery";
            this.cbodatabasequery.Size = new System.Drawing.Size(172, 21);
            this.cbodatabasequery.TabIndex = 1;
            this.cbodatabasequery.SelectedIndexChanged += new System.EventHandler(this.CbodatabasequerySelectedIndexChanged);
            // 
            // txtquery
            // 
            this.txtquery.BackColor = System.Drawing.Color.Black;
            this.txtquery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtquery.ForeColor = System.Drawing.Color.Lime;
            this.txtquery.Location = new System.Drawing.Point(3, 16);
            this.txtquery.Multiline = true;
            this.txtquery.Name = "txtquery";
            this.txtquery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtquery.Size = new System.Drawing.Size(508, 41);
            this.txtquery.TabIndex = 0;
            // 
            // tabPagetools
            // 
            this.tabPagetools.Controls.Add(this.groupBox24);
            this.tabPagetools.ImageIndex = 6;
            this.tabPagetools.Location = new System.Drawing.Point(4, 23);
            this.tabPagetools.Name = "tabPagetools";
            this.tabPagetools.Size = new System.Drawing.Size(544, 325);
            this.tabPagetools.TabIndex = 6;
            this.tabPagetools.Text = "tools";
            this.tabPagetools.UseVisualStyleBackColor = true;
            // 
            // groupBox24
            // 
            this.groupBox24.BackColor = System.Drawing.Color.Wheat;
            this.groupBox24.Controls.Add(this.btnstartwebsite);
            this.groupBox24.Controls.Add(this.btnopenapplicationdir);
            this.groupBox24.Controls.Add(this.btnstartcommandlineinterface);
            this.groupBox24.Controls.Add(this.btnstartexplorer);
            this.groupBox24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox24.Location = new System.Drawing.Point(0, 0);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(544, 325);
            this.groupBox24.TabIndex = 0;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "tools";
            // 
            // btnstartwebsite
            // 
            this.btnstartwebsite.BackColor = System.Drawing.SystemColors.Control;
            this.btnstartwebsite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstartwebsite.ForeColor = System.Drawing.Color.Black;
            this.btnstartwebsite.Image = ((System.Drawing.Image)(resources.GetObject("btnstartwebsite.Image")));
            this.btnstartwebsite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnstartwebsite.Location = new System.Drawing.Point(32, 203);
            this.btnstartwebsite.Name = "btnstartwebsite";
            this.btnstartwebsite.Size = new System.Drawing.Size(183, 46);
            this.btnstartwebsite.TabIndex = 35;
            this.btnstartwebsite.Text = "start website";
            this.btnstartwebsite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnstartwebsite.UseVisualStyleBackColor = false;
            this.btnstartwebsite.Click += new System.EventHandler(this.BtnstartwebsiteClick);
            // 
            // btnopenapplicationdir
            // 
            this.btnopenapplicationdir.BackColor = System.Drawing.SystemColors.Control;
            this.btnopenapplicationdir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnopenapplicationdir.ForeColor = System.Drawing.Color.Black;
            this.btnopenapplicationdir.Image = ((System.Drawing.Image)(resources.GetObject("btnopenapplicationdir.Image")));
            this.btnopenapplicationdir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnopenapplicationdir.Location = new System.Drawing.Point(32, 151);
            this.btnopenapplicationdir.Name = "btnopenapplicationdir";
            this.btnopenapplicationdir.Size = new System.Drawing.Size(183, 46);
            this.btnopenapplicationdir.TabIndex = 34;
            this.btnopenapplicationdir.Text = "open application directory";
            this.btnopenapplicationdir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnopenapplicationdir.UseVisualStyleBackColor = false;
            this.btnopenapplicationdir.Click += new System.EventHandler(this.BtnopenapplicationdirClick);
            // 
            // btnstartcommandlineinterface
            // 
            this.btnstartcommandlineinterface.BackColor = System.Drawing.SystemColors.Control;
            this.btnstartcommandlineinterface.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstartcommandlineinterface.ForeColor = System.Drawing.Color.Black;
            this.btnstartcommandlineinterface.Image = ((System.Drawing.Image)(resources.GetObject("btnstartcommandlineinterface.Image")));
            this.btnstartcommandlineinterface.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnstartcommandlineinterface.Location = new System.Drawing.Point(32, 99);
            this.btnstartcommandlineinterface.Name = "btnstartcommandlineinterface";
            this.btnstartcommandlineinterface.Size = new System.Drawing.Size(183, 46);
            this.btnstartcommandlineinterface.TabIndex = 33;
            this.btnstartcommandlineinterface.Text = "start command line interface";
            this.btnstartcommandlineinterface.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnstartcommandlineinterface.UseVisualStyleBackColor = false;
            this.btnstartcommandlineinterface.Click += new System.EventHandler(this.BtnstartcommandlineinterfaceClick);
            // 
            // btnstartexplorer
            // 
            this.btnstartexplorer.BackColor = System.Drawing.SystemColors.Control;
            this.btnstartexplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstartexplorer.ForeColor = System.Drawing.Color.Black;
            this.btnstartexplorer.Image = ((System.Drawing.Image)(resources.GetObject("btnstartexplorer.Image")));
            this.btnstartexplorer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnstartexplorer.Location = new System.Drawing.Point(32, 47);
            this.btnstartexplorer.Name = "btnstartexplorer";
            this.btnstartexplorer.Size = new System.Drawing.Size(183, 46);
            this.btnstartexplorer.TabIndex = 32;
            this.btnstartexplorer.Text = "start windows explorer";
            this.btnstartexplorer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnstartexplorer.UseVisualStyleBackColor = false;
            this.btnstartexplorer.Click += new System.EventHandler(this.BtnstartexplorerClick);
            // 
            // tabimageList
            // 
            this.tabimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabimageList.ImageStream")));
            this.tabimageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabimageList.Images.SetKeyName(0, "ssms.ico");
            this.tabimageList.Images.SetKeyName(1, "mysql.ico");
            this.tabimageList.Images.SetKeyName(2, "sqlite.ico");
            this.tabimageList.Images.SetKeyName(3, "postgresql.ico");
            this.tabimageList.Images.SetKeyName(4, "updateschema.png");
            this.tabimageList.Images.SetKeyName(5, "utils.png");
            this.tabimageList.Images.SetKeyName(6, "settings.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox25);
            this.groupBox1.Controls.Add(this.btnexit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 162);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // txtlog
            // 
            this.txtlog.AcceptsReturn = true;
            this.txtlog.AcceptsTab = true;
            this.txtlog.BackColor = System.Drawing.Color.Black;
            this.txtlog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtlog.ForeColor = System.Drawing.Color.Lime;
            this.txtlog.Location = new System.Drawing.Point(3, 16);
            this.txtlog.Multiline = true;
            this.txtlog.Name = "txtlog";
            this.txtlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtlog.Size = new System.Drawing.Size(484, 82);
            this.txtlog.TabIndex = 9;
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.SystemColors.Control;
            this.btnexit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnexit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.ForeColor = System.Drawing.Color.Black;
            this.btnexit.Image = ((System.Drawing.Image)(resources.GetObject("btnexit.Image")));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.Location = new System.Drawing.Point(499, 16);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(56, 143);
            this.btnexit.TabIndex = 8;
            this.btnexit.Text = "exit";
            this.btnexit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.BtnexitClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControlutils);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 371);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.groupBox26);
            this.groupBox25.Controls.Add(this.progressBardbutils);
            this.groupBox25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox25.Location = new System.Drawing.Point(3, 16);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(496, 143);
            this.groupBox25.TabIndex = 10;
            this.groupBox25.TabStop = false;
            // 
            // progressBardbutils
            // 
            this.progressBardbutils.BackColor = System.Drawing.Color.Black;
            this.progressBardbutils.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBardbutils.Location = new System.Drawing.Point(3, 117);
            this.progressBardbutils.Name = "progressBardbutils";
            this.progressBardbutils.Size = new System.Drawing.Size(490, 23);
            this.progressBardbutils.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBardbutils.TabIndex = 10;
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.txtlog);
            this.groupBox26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox26.Location = new System.Drawing.Point(3, 16);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(490, 101);
            this.groupBox26.TabIndex = 11;
            this.groupBox26.TabStop = false;
            // 
            // databaseutilsform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 533);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "databaseutilsform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "utils";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DatabaseutilsformFormClosing);
            this.Load += new System.EventHandler(this.DatabaseutilsformLoad);
            this.tabControlutils.ResumeLayout(false);
            this.tabPagemssql.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPagemysql.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabPagesqlite.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.tabPagepostgresql.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.tabPageupdateschemas.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.tabPageutils.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.tabPagetools.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox25.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button btndeletemssqldatabase;
		private System.Windows.Forms.Button btndeletemysqldatabase;
		private System.Windows.Forms.Button btndeletepostgresqldatabase;
		private System.Windows.Forms.Button btndeletesqlitedatabase;
		private System.Windows.Forms.GroupBox groupBox24;
		private System.Windows.Forms.TabPage tabPagetools;
		private System.Windows.Forms.Button btnstartwebsite;
		private System.Windows.Forms.Button btnopenapplicationdir;
		private System.Windows.Forms.Button btnstartcommandlineinterface;
		private System.Windows.Forms.Button btnstartexplorer;
		private System.Windows.Forms.GroupBox groupBox23;
		private System.Windows.Forms.TextBox txtxampserverpath;
		private System.Windows.Forms.GroupBox groupBox22;
		private System.Windows.Forms.TextBox txtserveripaddress;
		private System.Windows.Forms.ComboBox cbodatabasefrom;
		private System.Windows.Forms.ComboBox cboserverfrom;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.ComboBox cbodatabaseto;
		private System.Windows.Forms.ComboBox cboserverto;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label lbldatabaseto;
		private System.Windows.Forms.ComboBox cboserverquery;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label lbldatabasequery;
		private System.Windows.Forms.Button btnexecutequery;
		private System.Windows.Forms.Button btngetipaddress;
		private System.Windows.Forms.GroupBox groupBox20;
		private System.Windows.Forms.Label lbldatabasefrom;
		private System.Windows.Forms.Button btnsync;
		private System.Windows.Forms.GroupBox groupBox21;
		private System.Windows.Forms.ComboBox cbodatabasequery;
		private System.Windows.Forms.TextBox txtquery;
		private System.Windows.Forms.GroupBox groupBox19;
		private System.Windows.Forms.TabPage tabPageutils;
		private System.Windows.Forms.Button btnstartmysqlserver;
		private System.Windows.Forms.Label lblmssqldbcount;
		private System.Windows.Forms.Label lblmysqldbcount;
		private System.Windows.Forms.Label lblpostgresqldbcount;
		private System.Windows.Forms.Label lblsqlitedbcount;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Button btnloadmysqldatabases;
		private System.Windows.Forms.ComboBox cbomysqldatabases;
		private System.Windows.Forms.Button btnupdatemysqldatabase;
		private System.Windows.Forms.GroupBox groupBox16;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Button btnloadpostgresqldatabases;
		private System.Windows.Forms.ComboBox cbopostgresqldatabases;
		private System.Windows.Forms.Button btnupdatepostgresqldatabase;
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Button btnloadsqlitedatabases;
		private System.Windows.Forms.ComboBox cbosqlitedatabases;
		private System.Windows.Forms.Button btnupdatesqlitedatabase;
		private System.Windows.Forms.GroupBox groupBox18;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Button btnloadmssqldatabases;
		private System.Windows.Forms.ComboBox cbomssqldatabases;
		private System.Windows.Forms.Button btnupdatemssqldatabase;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.TabPage tabPageupdateschemas;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.TextBox txtsqlitedbextension;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.TextBox txtsyssqlitedbextension;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox txtpostgresqlport;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox txtmysqlport;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox txtmssqlport;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.TextBox txtsqlitefailifmissing;
		private System.Windows.Forms.TextBox txtpostgresqlhostname;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox txtpostgresqlusername;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox txtpostgresqlpassword;
		private System.Windows.Forms.TextBox txtcreatepostgresqldatabase;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Button btncreatepostgresqldatabase;
		private System.Windows.Forms.TextBox txtpostgresqldatabasename;
		private System.Windows.Forms.Button btncheckpostgresqlconnection;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.TextBox txtsyspostgresqldatastore;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox txtsyspostgresqldatabase;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox txtsyspostgresqlpassword;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox txtsyspostgresqlusername;
		private System.Windows.Forms.Button btnsavepostgresqlchanges;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox txtsyspostgresqlport;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.TextBox txtsqlitedbpath;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox txtsqliteversion;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox txtsqlitepooling;
		private System.Windows.Forms.TextBox txtcreatesqlitedatabase;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Button btncreatesqlitedatabase;
		private System.Windows.Forms.TextBox txtsqlitedatabasename;
		private System.Windows.Forms.Button btnchecksqliteconnection;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.TextBox txtsyssqlitedbpath;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox txtsyssqlitedatabase;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtsyssqlitepooling;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox txtsyssqliteversion;
		private System.Windows.Forms.Button btnsavesqlitechanges;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox txtsyssqlitefailifmissing;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.TextBox txtmysqlhostname;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtmysqlusername;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtmysqlpassword;
		private System.Windows.Forms.TextBox txtcreatemysqldatabase;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button btncreatemysqldatabase;
		private System.Windows.Forms.TextBox txtmysqldatabasename;
		private System.Windows.Forms.Button btncheckmysqlconnection;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox txtsysmysqldatastore;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtsysmysqldatabase;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtsysmysqlpassword;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtsysmysqlusername;
		private System.Windows.Forms.Button btnsavemysqlchanges;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtsysmysqlport;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.ImageList tabimageList;
		private System.Windows.Forms.TextBox txtsysmssqldatasource;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtsysmssqldatabase;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtsysmssqlpassword;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtsysmssqlusername;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtsysmssqlport;
		private System.Windows.Forms.TextBox txtlog;
		private System.Windows.Forms.TextBox txtmssqlservername;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtmssqlusername;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtmssqlpassword;
		private System.Windows.Forms.TextBox txtcreatemssqldatabase;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btncreatemssqldatabase;
		private System.Windows.Forms.TextBox txtmssqldatabasename;
		private System.Windows.Forms.Button btncheckmssqlconnection;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Button btnsavemssqlchanges;
		private System.Windows.Forms.Button btnexit;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tabPagepostgresql;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TabPage tabPagesqlite;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TabPage tabPagemysql;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TabPage tabPagemssql;
		private System.Windows.Forms.TabControl tabControlutils;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.ProgressBar progressBardbutils;
	}
}
